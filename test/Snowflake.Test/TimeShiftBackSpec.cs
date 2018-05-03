using System;
using System.Linq;
using FluentAssertions;
using Moq;
using Xunit;

namespace MiffyLiye.Snowflake.Test
{
    public class TimeShiftBackSpec : SpecBase
    {
        [Fact]
        public void should_generate_equal_or_greater_timestamp_in_id_when_clock_shifted_back()
        {
            var now = DateTime.UtcNow;
            var clockMock = new Mock<IClock>();
            clockMock.SetupSequence(c => c.UtcNow)
                .Returns(now)
                .Returns(now.AddSeconds(-1));
            var snowflake = new Snowflake(clock: clockMock.Object, timestampOffset: now.AddMinutes(-1));

            var firstId = snowflake.Next();
            var lastId = snowflake.Next();

            (lastId & TimestampMask).Should().BeGreaterOrEqualTo(firstId & TimestampMask);
        }
    }
}
