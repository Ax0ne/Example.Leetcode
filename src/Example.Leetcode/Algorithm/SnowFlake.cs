using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Leetcode.Algorithm
{
    /// <summary>
    /// 雪花算法
    /// </summary>
    public class SnowFlake
    {
        private const long _tmsp = 1288834974657L;
        private const int SequenceBits = 12; // 序列号占用的位数
        private const int MachineBits = 5;  // 机器标识占用的位数
        private const int DatacenterBits = 5; // 数据中心占用的位数
        private const long MaxDatacenterCount = -1L ^ (-1L << DatacenterBits); // 最大数据中心数量
        private const long MaxMachineCount = -1L ^ (-1L << MachineBits); // 最大机器数量
        private const long MaxSequence = -1L ^ (-1L << SequenceBits); // 12位能存储的最大数
        private const int MachineLeft = SequenceBits; // 机器标志较序列号的偏移量
        private const int DatacenterLeft = SequenceBits + MachineBits; // 数据中心较机器标志的偏移量
        private const int TimestampLeft = SequenceBits + MachineBits + DatacenterBits; // 时间戳较数据中心的偏移量
        public long DataCenterId { get; protected set; } // 当前数据中心的id
        public long MachineId { get; protected set; } // 当前机器的id
        public long SequenceId { get; private set; } // 序列id
        private static long LastTimeStamp { get; set; } // 最后的时间戳
        private static SnowFlake _snowflake;

        private readonly object _lock = new object();
        private static readonly object SnowflakeLock = new object();
        public SnowFlake(long machineId, long datacenterId, long sequenceId = 0)
        {
            MachineId = machineId;
            DataCenterId = datacenterId;
            SequenceId = sequenceId;
        }

        public static SnowFlake Instance()
        {
            lock (SnowflakeLock)
            {
                if (_snowflake != null)
                    return _snowflake;
                var random = new Random();
                if (!int.TryParse(Environment.GetEnvironmentVariable("SF_MACHINEID", EnvironmentVariableTarget.Machine), out var machineId))
                {
                    machineId = random.Next((int)MaxMachineCount);
                }

                if (!int.TryParse(Environment.GetEnvironmentVariable("SF_DATACENTERID", EnvironmentVariableTarget.Machine), out var datacenterId))
                {
                    datacenterId = random.Next((int)MaxDatacenterCount);
                }

                return _snowflake = new SnowFlake(machineId, datacenterId);
            }
        }

        public long NextId()
        {
            lock (_lock)
            {
                var timestamp = GetTimestamp();
                if (timestamp < LastTimeStamp)
                    throw new Exception("系统时间异常，有可能是变慢了");
                if (timestamp == LastTimeStamp)
                {
                    SequenceId = (SequenceId + 1) & MaxSequence;
                    if (SequenceId == 0L)
                        timestamp = GetNextTimestamp();
                }
                else
                    SequenceId = 0L;

                LastTimeStamp = timestamp;

                return (timestamp - _tmsp) << TimestampLeft // 时间戳部分
                       | DataCenterId << DatacenterLeft     // 数据中心部分
                       | MachineId << MachineLeft           // 机器标识部分
                       | SequenceId;                        // 序列号部分
            }
        }
        private long GetNextTimestamp()
        {
            var timestamp = GetTimestamp();
            while (timestamp <= LastTimeStamp)
            {
                timestamp = GetTimestamp();
            }
            return timestamp;
        }
        private long GetTimestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }
    }
}
