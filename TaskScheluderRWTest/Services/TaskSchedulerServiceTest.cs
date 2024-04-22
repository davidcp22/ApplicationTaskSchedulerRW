using Moq;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSchedulerBusinessRW.Interface;
using TaskSchedulerBusinessRW.Models;
using TaskSchedulerBusinessRW.Services;
using Xunit;

namespace TaskScheluderRWTest.Services
{
    public class TaskSchedulerServiceTest
    {
        private readonly ITaskSchedulerService _taskSchedulerService;
        private readonly Mock<ISchedulerFactory> schedulerFactoryMock;
        private readonly Mock<IScheduler> schedulerMock;
        public TaskSchedulerServiceTest()
        {
            schedulerFactoryMock = new Mock<ISchedulerFactory>();
            schedulerMock = new Mock<IScheduler>();

            schedulerFactoryMock
                .Setup(f => f.GetScheduler(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(schedulerMock.Object));
            _taskSchedulerService =  new TaskSchedulerModelService(schedulerFactoryMock.Object);
        }
        [Fact]
        public async Task TaskSchedulerAsync_WithValidInput_ShouldScheduleJob()
        {
            // Arrange

            var model = new TaskSchedulerModel
            {
                CronExpression = "0 0 * * * ?", // Every hour
                Url = "https://example.com"
            };

            // Act
            var result = await _taskSchedulerService.TaskSchedulerAsync(model);

            // Assert
            Assert.Equal("Tarea programada exitosamente.", result);
        }

        [Fact]
        public async Task TaskSchedulerAsync_WithInvalidCronExpression_ShouldReturnErrorMessage()
        {
            // Arrange
            var model = new TaskSchedulerModel
            {
                CronExpression = "invalid_cron_expression",
                Url = "https://example.com"
            };

            // Act
            var result = await _taskSchedulerService.TaskSchedulerAsync(model);

            // Assert
            Assert.StartsWith("Error al programar la tarea:", result);
        }
    }
}
