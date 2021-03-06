using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Xunit;

namespace MiffyLiye.Snowflake.Test
{
    public class MachineIdSpec : SpecBase
    {
        [Fact]
        public void should_have_same_machine_id_in_all_generated_ids()
        {
            var snowflake = new Snowflake();

            var lastId = snowflake.Next();
            var nextId = snowflake.Next();

            var lastMachineId = lastId & MachineIdMask;
            var nextMachineId = nextId & MachineIdMask;

            nextMachineId.Should().Be(lastMachineId);
        }
        
        [Theory]
        [InlineData("0")]
        [InlineData("9")]
        [InlineData("1 << ((new MiffyLiye.Snowflake.Snowflake()).MachineIdLength - 1)")]
        public async Task should_have_same_specified_machine_id_in_all_generated_ids(string machineIdScript)
        {
            var machineId = await CSharpScript.EvaluateAsync<int>(machineIdScript,
                ScriptOptions.Default.WithReferences(typeof(Snowflake).Assembly));
            var snowflake = new Snowflake(machineId);

            var lastId = snowflake.Next();
            var nextId = snowflake.Next();

            var idWithOnlyMachineId = ((long) machineId) << (64 - MachineIdOffset - MachineIdLength);

            (lastId & MachineIdMask).Should().Be(idWithOnlyMachineId);
            (nextId & MachineIdMask).Should().Be(idWithOnlyMachineId);
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("1 << 31")]
        [InlineData("1 << (new MiffyLiye.Snowflake.Snowflake()).MachineIdLength")]
        public async Task should_throw_if_machine_id_is_longer_than_machine_id_length(string machineIdScript)
        {
            var machineId = await CSharpScript.EvaluateAsync<int>(machineIdScript,
                ScriptOptions.Default.WithReferences(typeof(Snowflake).Assembly));
            ((Action) (() =>
                {
                    var snowflake = new Snowflake(machineId);
                })).Should().Throw<ArgumentException>()
                .WithMessage($"Machine ID should not be longer than {MachineIdLength} bits.");
        }
    }
}
