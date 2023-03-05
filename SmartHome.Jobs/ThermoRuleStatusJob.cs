using Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartHome.Application;
using SmartHome.Jobs.Core;
using SmartHome.Repository;

namespace SmartHome.Jobs
{
    public class ThermoRuleStatusJob : HostedJob
    {
        private readonly IServiceProvider _serviceProvider;

        public ThermoRuleStatusJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            var _uow = _serviceProvider.GetRequiredService<IUoW>();

            try
            {
                ;
                var paramService = _serviceProvider.GetRequiredService<IConfiguration>();
                var parameters = paramService.GetRequiredSection("Params").Get<Params>();

                var job = parameters?.Jobs?.ThermoRuleStatus;

                if (job == null)
                {
                    _uow.LogEx.AddLog(new Models.LogAddModel {  
                        Description = null,
                        Message = "ThermoRuleStatus can not be started, because params is not set",
                        Type = SmartHomeLogTypes.ERROR,
                        Section = SmartHomeSections.JOB_THERMO_RULE_SATUS
                    });

                    return;
                }

                DueTime = JobStartCalculator.GetNextTimeSpan(DateTime.Now, job.StartHour, job.StartMinute);
                Period = TimeSpan.FromSeconds(job.Period);

                _uow.LogEx.AddLog(new Models.LogAddModel
                {
                    Description = null,
                    Message = $"ThermoRuleStatus job has started, next run in: {DueTime}",
                    Type = SmartHomeLogTypes.INFO,
                    Section = SmartHomeSections.JOB_THERMO_RULE_SATUS
                });
            }
            catch (Exception ex)
            {
                _uow.LogEx.AddLog(new Models.LogAddModel
                {
                    Description = ex.Message + Environment.NewLine + ex.InnerException?.Message,
                    Message = "ThermoRuleStatus can not be started, because of internal error",
                    Type = SmartHomeLogTypes.ERROR,
                    Section = SmartHomeSections.JOB_THERMO_RULE_SATUS
                });
            }

            _uow.CommitSM();
        }

        public override async Task Callback(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _uow = scope.ServiceProvider.GetRequiredService<IUoW>();
                var thermoRules = await _uow.ThermoRuleEx.GetThermoRulesAsync();
                DateTime actualDateTime = DateTime.Now;
                int dayOfWeek = (int)actualDateTime.DayOfWeek;

                foreach (var thermoRule in thermoRules.Where(p => p.WeekDay == dayOfWeek))
                {
                    DateTime trStart = new DateTime(actualDateTime.Year, actualDateTime.Month, actualDateTime.Day, int.Parse(thermoRule.Start.Split(":")[0]), int.Parse(thermoRule.Start.Split(":")[1]), 0);
                    DateTime trEnd = new DateTime(actualDateTime.Year, actualDateTime.Month, actualDateTime.Day, int.Parse(thermoRule.End.Split(":")[0]), int.Parse(thermoRule.End.Split(":")[1]), 0);

                    thermoRule.IntervalSatus = false;
                    if (actualDateTime > trStart && actualDateTime <= trEnd)
                    {
                        thermoRule.IntervalSatus = true;
                    }

                    thermoRule.LastUpdate = actualDateTime;
                    await _uow.ThermoRule.UpdateAsync(thermoRule);
                    await _uow.CommitSMAsync();
                }
            }
        }
    }
}
