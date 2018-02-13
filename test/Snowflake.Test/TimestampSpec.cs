using System;
using FluentAssertions;
using Moq;
using Xunit;

namespace MiffyLiye.Snowflake.Test
{
    public class TimestampSpec : SpecBase
    {
        [Fact]
        public void should_generate_larger_next_id_when_the_last_id_was_generated_two_millisecond_ago()
        {
            var now = DateTime.UtcNow;
            var lastTimestamp = now;
            var nextTimestamp = now.AddMilliseconds(2);
            var clockMock = new Mock<IClock>();
            clockMock.SetupSequence(c => c.UtcNow)
                .Returns(lastTimestamp)
                .Returns(nextTimestamp);
            var snowflake = new Snowflake(clock: clockMock.Object, timestampOffset: now);

            var lastId = snowflake.Next();
            var nextId = snowflake.Next();

            nextId.Should().BeGreaterThan(lastId);
        }

        [Fact]
        public void should_generate_larger_next_id_when_the_last_id_was_generated_100_years_ago()
        {
            var now = DateTime.UtcNow;
            var lastTimestamp = now;
            var nextTimestamp = now.AddYears(100);
            var clockMock = new Mock<IClock>();
            clockMock.SetupSequence(c => c.UtcNow)
                .Returns(lastTimestamp)
                .Returns(nextTimestamp);
            var snowflake = new Snowflake(clock: clockMock.Object, timestampOffset: now);

            var lastId = snowflake.Next();
            var nextId = snowflake.Next();

            nextId.Should().BeGreaterThan(lastId);
        }
    }
}
