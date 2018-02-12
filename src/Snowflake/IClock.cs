using System;

namespace MiffyLiye.Snowflake
{
    public interface IClock
    {
        DateTime UtcNow { get; }
    }
}