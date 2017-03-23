using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Business Object representation of System.Diagnostics.Eventing.EventRecord. Created primarily so that the EventRecord description is persisted
    /// </summary>
    public class LogEvent
    {
        public int Id { get; set; }
        public Guid? ProviderId { get; set; }
        public string TaskDisplayName { get; set; }
        public string OpcodeDisplayName { get; set; }
        public string LevelDisplayName { get; set; }
        public int? Qualifiers { get; set; }
        public Guid? RelatedActivityId { get; set; }
        public Guid? ActivityId { get; set; }
        public DateTime? TimeCreated { get; set; }
        public string UserId { get; set; }
        public string MachineName { get; set; }
        public int? ThreadId { get; set; }
        public int? ProcessId { get; set; }
        public string LogName { get; set; }
        public string ProviderName { get; set; }
        public long? RecordId { get; set; }
        public long? Keywords { get; set; }
        public short? Opcode { get; set; }
        public int? Task { get; set; }
        public byte? Level { get; set; }
        public byte? Version { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Implicit operator used to map an EventRecord to a LogEvent
        /// </summary>
        /// <param name="record"></param>
        public static implicit operator LogEvent(EventRecord record)
        {
            return new LogEvent()
            {
                Id = record.Id,
                ProviderId = record.ProviderId,
                TaskDisplayName = record.TaskDisplayName,
                OpcodeDisplayName = record.OpcodeDisplayName,
                LevelDisplayName = record.LevelDisplayName,
                Qualifiers = record.Qualifiers,
                RelatedActivityId = record.RelatedActivityId,
                ActivityId = record.ActivityId,
                TimeCreated = record.TimeCreated,
                UserId = record.UserId == null ? "" : record.UserId.Value,
                MachineName = record.MachineName,
                ThreadId = record.ThreadId,
                ProcessId = record.ProcessId,
                LogName = record.LogName,
                ProviderName = record.ProviderName,
                RecordId = record.RecordId,
                Keywords = record.Keywords,
                Opcode = record.Opcode,
                Task = record.Task,
                Level = record.Level,
                Version = record.Version,
                Description = record.FormatDescription()
            };
        }
    }
}
