using System;

namespace MiffyLiye.Snowflake.Test
{
    public abstract class SpecBase
    {
        protected int MachineIdOffset { get; }
        protected int MachineIdLength { get; }
        protected long TimestampMask { get; }
        protected long MachineIdMask { get; }

        protected SpecBase()
        {
            var snowflake = new Snowflake();
            MachineIdOffset = snowflake.MachineIdOffset;
            MachineIdLength = snowflake.MachineIdLength;
            TimestampMask = Convert.ToInt64(
                new string('0', 1) +
                new string('1', MachineIdOffset - 1) +
                new string('0', MachineIdLength) +
                new string('0', 64 - MachineIdOffset - MachineIdLength),
                2);
            MachineIdMask = Convert.ToInt64(
                new string('0', MachineIdOffset) +
                new string('1', MachineIdLength) +
                new string('0', 64 - MachineIdOffset - MachineIdLength),
                2);
        }
    }
}