using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace MiffyLiye.Snowflake.Test
{
    public class PerformanceSpec : SpecBase
    {
        [Fact]
        public void should_generate_one_id_in_less_than_one_millisecond()
        {
            var snowflake = new Snowflake();
            // ReSharper disable once UnusedVariable
            var warmupId = snowflake.Next();
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            // ReSharper disable once UnusedVariable
            var id = snowflake.Next();
            var elapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds;

#if DEBUG
            var limit = 3;
#else
            var limit = 1;
#endif
            elapsedMilliseconds.Should().BeLessThan(limit);
        }

        [Fact]
        public void should_generate_4096_unique_ids_in_less_than_100_millisecond()
        {
            var snowflake = new Snowflake();
            // ReSharper disable once UnusedVariable
            var warmupId = snowflake.Next();
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var ids = Enumerable.Range(1, 4096)
                .Select(i => snowflake.Next())
                .AsParallel()
                .ToArray();
            var elapsed = stopwatch.Elapsed;

#if DEBUG
            var limit = 200;
#else
            var limit = 100;
#endif
            elapsed.TotalMilliseconds.Should().BeLessThan(limit);
            var distinctIds = ids.Distinct();
            distinctIds.Count().Should().Be(4096);
        }
    }
}
