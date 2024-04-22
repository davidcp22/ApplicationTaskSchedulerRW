using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerBusinessRW.Models
{
    public class TaskSchedulerModel
    {
        public string Url { get; set; }
        public string CronExpression { get; set; }
    }
}
