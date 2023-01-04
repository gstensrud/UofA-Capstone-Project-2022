using System.ComponentModel.DataAnnotations.Schema;
using TownOfStettler.Data;

namespace TownOfStettler.Models
{
    public partial class Modification
    {
        public Modification()
        {
            Histories = new HashSet<History>();
        }

        public int Id { get; set; }
        public int? ProcessorId { get; set; }
        public int? RamId { get; set; }
        public int? HardDriveId { get; set; }
        public int? MiscellaneousDriveId { get; set; }
        public int? SoundCardId { get; set; }
        public int? VideoCardId { get; set; }
        public string? Notes { get; set; }

        public virtual HardDrive? HardDrive { get; set; }
        public virtual Processor? Processor { get; set; }
        public virtual Ram? Ram { get; set; }
        public virtual MiscellaneousDrive? MiscellaneousDrive { get; set; }
        public virtual SoundCard? SoundCard { get; set; }
        public virtual VideoCard? VideoCard { get; set; }
        public virtual ICollection<History> Histories { get; set; }

        [NotMapped]
        public string ProcessorIdWithName
        {
            get
            {
                string result = "ID#" + ProcessorId.ToString();
                using (DatabaseContext __dbcntxt = new())
                {
                    result += (" [ " + __dbcntxt.Processors.Single(item => (item.Id == ProcessorId)).Type + " ]");
                }
                return result;
            }
        }

        [NotMapped]
        public string RamIdWithName
        {
            get
            {
                string result = "ID#" + RamId.ToString();
                using (DatabaseContext __dbcntxt = new())
                {
                    result += (" [ " + __dbcntxt.Rams.Single(item => (item.Id == RamId)).Type + " ]");
                }
                return result;
            }
        }

        [NotMapped]
        public string HardDriveIdWithName
        {
            get
            {
                string result = "ID#" + HardDriveId.ToString();
                using (DatabaseContext __dbcntxt = new())
                {
                    result += (" [ " + __dbcntxt.HardDrives.Single(item => (item.Id == HardDriveId)).Type + " ]");
                }
                return result;
            }
        }

        [NotMapped]
        public string DriveReaderIdWithName
        {
            get
            {
                string result = "ID#" + MiscellaneousDriveId.ToString();
                using (DatabaseContext __dbcntxt = new())
                {
                    result += (" [ " + __dbcntxt.MiscellaneousDrives.Single(item => (item.Id == MiscellaneousDriveId)).Type + " ]");
                }
                return result;
            }
        }

        [NotMapped]
        public string VideoCardIdWithName
        {
            get
            {
                string result = "ID-" + VideoCardId.ToString();
                using (DatabaseContext __dbcntxt = new())
                {
                    result += (" [ " + __dbcntxt.VideoCards.Single(item => (item.Id == VideoCardId)).Brand + " ]");
                }
                return result;
            }
        }


    }
}
