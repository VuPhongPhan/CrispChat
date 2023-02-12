using CrispChat.HttpClients;
using CrispChat.Services;
using NCrontab;

namespace CrispChat.Backgrounds
{
    public class SynsConversationsWorker : BackgroundService
    {
        private CrontabSchedule _schedule;
        private DateTime _nextRun;
        private readonly IConversationsService conversationsService;

        public SynsConversationsWorker(IConversationsService conversationsService)
        {
            _schedule = CrontabSchedule.Parse("1 0 * * *");
            //_schedule = CrontabSchedule.Parse("*/1 * * * *");
            _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
            this.conversationsService = conversationsService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                var now = DateTime.Now;
                _schedule.GetNextOccurrence(now);
                if (now > _nextRun)
                {
                    await HandleSynsConversation();
                    _nextRun = _schedule.GetNextOccurrence(now);
                }
                await Task.Delay(5000, stoppingToken);
            }
            while (!stoppingToken.IsCancellationRequested);
        }

        private async Task HandleSynsConversation()
        {
            var dateNow = DateTime.Now;
            var start = dateNow.Date.AddDays(-1);
            var end = dateNow.Date;
            await conversationsService.GetConversationsAsync(start, end);
            await conversationsService.GetPeoplesAsync(start, end);
            await conversationsService.GetVisitorsAsync();
        }
    }
}
