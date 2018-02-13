using System;

namespace MiffyLiye.Snowflake
{
    internal class SystemClock : IClock
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
