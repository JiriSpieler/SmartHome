using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartHome.Application;
using SmartHome.Application.Services;
using SmartHome.Jobs.Core;
using SmartHome.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Jobs
{
    public class ThermoRuleStatusJob : HostedJob
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUoW _uow;
        public ThermoRuleStatusJob(IServiceProvider serviceProvider, IUoW uow)
        {
            _serviceProvider = serviceProvider;
            _uow = uow;

            try
            {
                var paramService = _serviceProvider.GetRequiredService<IConfiguration>();
                var parameters = paramService.GetRequiredSection("Params").Get<Params>();

                var job = parameters?.Jobs?.ThermoRuleStatus;

                if (job == null)
                {
                    return;
                }

                DueTime = JobStartCalculator.GetNextTimeSpan(DateTime.Now, job.StartHour, job.StartMinute);
                Period = TimeSpan.FromSeconds(job.Period);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public override async Task Callback(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                // Load services
                //var appSettingsService = scope.ServiceProvider.GetRequiredService<IAppSettingsService>();
                Debug.WriteLine("a");

                var a = await _uow.OutputEx.GetOutputsAsync();
            }
        }
    }
}
