using FluentAssertions;
using Xunit;

namespace MiffyLiye.Snowflake.Test
{
    public class DefaultSpec : SpecBase
    {
        [Fact]
        public void should_generate_different_ids_in_a_short_period()
        {
            var snowflake = new Snowflake();

            var lastId = snowflake.Next();
            var nextId = snowflake.Next();

            nextId.Should().NotBe(lastId);
        }
        
        [Fact]
        public void should_generate_positive_number()
        {
            var snowflake = new Snowflake();
            
            var nextId = snowflake.Next();

            nextId.Should().BeGreaterThan(0);
        }
    }
}
