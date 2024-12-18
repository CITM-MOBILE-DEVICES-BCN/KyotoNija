using System;

namespace ROBOTIN
{
    namespace TimerModule
    {
        public interface IDateTimeProvider
        {
            DateTime UtcNow { get; }
        }
    }
}