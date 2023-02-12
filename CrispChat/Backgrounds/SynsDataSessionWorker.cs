using CrispChat.Entities;
using CrispChat.HttpClients;
using CrispChat.Repositories;
using CrispChat.Services;
using NCrontab;
using System.Text.Json;

namespace CrispChat.Backgrounds
{
    public class SynsDataSessionWorker : BackgroundService
    {
        private readonly IConversationsService conversationsService;
        private CrontabSchedule _schedule;
        private DateTime _nextRun;

        public SynsDataSessionWorker(IConversationsService conversationsService)
        {
            _schedule = CrontabSchedule.Parse("*/15 * * * *");
            _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
            this.conversationsService = conversationsService;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                var now = DateTime.Now;
                _schedule.GetNextOccurrence(now);
                if (now > _nextRun)
                {
                    await conversationsService.HandleSyncSession();
                    _nextRun = _schedule.GetNextOccurrence(now);
                }
                await Task.Delay(5000, stoppingToken);
            }
            while (!stoppingToken.IsCancellationRequested);
        }
    }
}
