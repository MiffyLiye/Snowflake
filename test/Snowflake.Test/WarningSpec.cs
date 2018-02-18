using System;
using FluentAssertions;
using Moq;
using Xunit;

namespace MiffyLiye.Snowflake.Test
{
    public class WarningSpec : SpecBase
    {
        [Fact]
        public void should_stop_generate_ids_when_less_than_ten_years_left_before_timestamp_overflow()
        {
            var now = DateTime.UtcNow;
            var nextTimestamp = now
                .AddMilliseconds(2 * Math.Pow(2, MachineIdOffset - 1))
                .AddYears(-9);
            var clockMock = new Mock<IClock>();
            clockMock.SetupSequence(c => c.UtcNow)
                .Returns(nextTimestamp);
            var snowflake = new Snowflake(clock: clockMock.Object, timestampOffset: now);

            snowflake.Invoking(s => s.Next())
                .Should().Throw<InvalidOperationException>()
                .WithMessage("ID will overflow in less than 10 years.");
        }

        [Fact]
        public void should_ignore_warning_generate_ids_when_less_than_ten_years_left_before_timestamp_overflow()
        {
            var now = DateTime.UtcNow;
            var nextTimestamp = now
                .AddMilliseconds(2 * Math.Pow(2, MachineIdOffset - 1))
                .AddYears(-9);
            var clockMock = new Mock<IClock>();
            clockMock.SetupSequence(c => c.UtcNow)
                .Returns(nextTimestamp);
            var snowflake = new Snowflake(
                clock: clockMock.Object,
                timestampOffset: now,
                ignoreWarning: true);

            snowflake.Invoking(s => s.Next())
                .Should().NotThrow();
        }
    }
}
