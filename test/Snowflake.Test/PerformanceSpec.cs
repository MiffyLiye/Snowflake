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
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            elapsedMilliseconds.Should().BeLessThan(1);
        }

        [Fact]
        public async Task should_generate_4096_unique_ids_in_less_than_one_second()
        {
            var snowflake = new Snowflake();
            // ReSharper disable once UnusedVariable
            var warmupId = snowflake.Next();
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var tasks = Enumerable.Range(1, 4096).Select(async s => await Task.FromResult(snowflake.Next()).ConfigureAwait(false)).ToArray();
            await Task.WhenAll(tasks);
            var elapsedSeconds = stopwatch.Elapsed.Seconds;

            elapsedSeconds.Should().BeLessThan(1);
            var ids = tasks.Select(t => t.Result).Distinct();
            ids.Count().Should().Be(4096);
        }
    }
}
