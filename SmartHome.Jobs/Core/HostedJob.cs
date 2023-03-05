using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartHome.Jobs.Core
{
    public abstract class HostedJob : IHostedService
    {
        private Timer? _timer;

        /// <summary>
        /// Za jak dlouho spustit od spusteni aplikace
        /// </summary>
        public TimeSpan? DueTime;

        /// <summary>
        /// Jak casto perioditcky spoustet
        /// </summary>
        public TimeSpan? Period;

        protected HostedJob()
        {
        }

        protected HostedJob(TimeSpan dueTime, TimeSpan period)
        {
            DueTime = dueTime;
            Period = period;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            if (DueTime.HasValue && Period.HasValue)
            {
                _timer = new Timer(state => Callback(state), null, DueTime.Value, Period.Value);
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            if (_timer == null)
            {
                return Task.CompletedTask;
            }

            _timer.Change(Timeout.Infinite, 0);
            _timer.Dispose();

            return Task.CompletedTask;
        }

        public abstract Task Callback(object state);
    }
}
