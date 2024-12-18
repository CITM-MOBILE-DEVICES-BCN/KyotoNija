using System;
using ROBOTIN.TimerModule;
namespace ROBOTIN
{
    namespace TimerModule
    {
        public class DateTimeProvider : IDateTimeProvider
        {
            public DateTime UtcNow => DateTime.UtcNow;
        }
    }

}