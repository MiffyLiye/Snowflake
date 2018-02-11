using System;
using System.Security.Cryptography;

namespace MiffyLiye.Snowflake
{
    public class Snowflake
    {
        public int MachineIdOffset { get; } = 42;
        public int MachineIdLength { get; } = 10;
        private long IdWithOnlyMachineId { get; }

        private long TimestampMask { get; }
        private long MachineIdMask { get; }
        private long RandomNumberMask { get; }

        private RandomNumberGenerator Random { get; }

        public Snowflake() : this(0)
        {
        }

        public Snowflake(int machineId)
        {
            MachineIdMask =
                Convert.ToInt64(
                    new string('0', MachineIdOffset) +
                    new string('1', MachineIdLength) +
                    new string('0', 64 - MachineIdOffset - MachineIdLength),
                    2);
            var idWithOnlyUnmaskedMachineId = (((long) machineId) << (64 - MachineIdOffset - MachineIdLength));
            IdWithOnlyMachineId = idWithOnlyUnmaskedMachineId & MachineIdMask;
            if (IdWithOnlyMachineId != idWithOnlyUnmaskedMachineId)
            {
                throw new InvalidOperationException($"Machine ID should not be longer than {MachineIdLength} bits.");
            }

            TimestampMask = Convert.ToInt64(
                new string('0', 1) +
                new string('1', MachineIdOffset - 1) +
                new string('0', MachineIdLength) +
                new string('0', 64 - MachineIdOffset - MachineIdLength),
                2);
            RandomNumberMask =
                Convert.ToInt64(
                    new string('0', MachineIdOffset) +
                    new string('0', MachineIdLength) +
                    new string('1', 64 - MachineIdOffset - MachineIdLength),
                    2);
            Random = RandomNumberGenerator.Create();
        }

        public long Next()
        {
            var idWithOnlyTimeStamp = (DateTime.UtcNow.Ticks << 8) & TimestampMask;
            var randomBytes = new byte[2];
            Random.GetBytes(randomBytes);
            var idWithOnlyRandomNumber = ((long) BitConverter.ToInt16(randomBytes, 0)) & RandomNumberMask;
            return idWithOnlyTimeStamp | IdWithOnlyMachineId | idWithOnlyRandomNumber;
        }
    }
}
