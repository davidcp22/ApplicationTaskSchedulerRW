using TaskSchedulerBusinessRW.Models;

namespace TaskSchedulerBusinessRW.Interface
{
    public interface ITaskSchedulerService
    {
        Task<string> TaskSchedulerAsync(TaskSchedulerModel taskSchedulerModel);
    }
}
