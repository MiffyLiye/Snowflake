using System;

namespace MiffyLiye.Snowflake
{
    public class SystemClock : IClock
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
