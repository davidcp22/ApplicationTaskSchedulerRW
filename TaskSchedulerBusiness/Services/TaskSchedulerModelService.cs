using Quartz;
using Quartz.Impl;
using TaskSchedulerBusinessRW.Helpers;
using TaskSchedulerBusinessRW.Interface;
using TaskSchedulerBusinessRW.Models;

namespace TaskSchedulerBusinessRW.Services
{
    public class TaskSchedulerModelService : ITaskSchedulerService
    {
        private IScheduler _scheduler;

        public TaskSchedulerModelService(ISchedulerFactory schedulerFactory)
        {
            _scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();
            _scheduler.Start().GetAwaiter().GetResult();
        }

        public async Task<string> TaskSchedulerAsync(TaskSchedulerModel taskSchedulerModel)
        {
            try
            {
               
                CronExpression cronExpression = new CronExpression(taskSchedulerModel.CronExpression);
                
                IJobDetail job = JobBuilder.Create<ScrapeWebsiteJob>()
                    .WithIdentity("scrapeJob", "group1")
                    .UsingJobData("Url", taskSchedulerModel.Url)
                    .Build();

                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("scrapeTrigger", "group1")
                    .WithSchedule(CronScheduleBuilder.CronSchedule(cronExpression))
                    .Build();
               
                await _scheduler.ScheduleJob(job, trigger);

                return "Tarea programada exitosamente.";
            }
            catch (Exception ex)
            {
                return $"Error al programar la tarea: {ex.Message}";
            }
        }
    }
}
