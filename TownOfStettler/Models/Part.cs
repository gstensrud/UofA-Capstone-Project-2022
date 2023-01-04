using System.ComponentModel.DataAnnotations.Schema;
using TownOfStettler.Data;

namespace TownOfStettler.Models
{
    public partial class Part
    {
        public int Id { get; set; }
        public int OriginalDeviceId { get; set; }
        public int DeviceHistoryId { get; set; }
        public int? RamId { get; set; }
        public int? HardDriveId { get; set; }
        public int? MiscellaneousDriveId { get; set; }
        public int? VideoCardId { get; set; }
        public int? SoundCardId { get; set; }
        public string? Notes { get; set; }

        public virtual History DeviceHistory { get; set; } = null!;
        public virtual HardDrive? HardDrive { get; set; }
        public virtual DeviceInformation OriginalDevice { get; set; } = null!;
        public virtual Ram? Ram { get; set; }
        public virtual MiscellaneousDrive? MiscellaneousDrive { get; set; }
        public virtual SoundCard? SoundCard { get; set; }
        public virtual VideoCard? VideoCard { get; set; }

        [NotMapped]
        public string VideosIdWithName
        {
            get
            {
                string result = "ID#" + VideoCardId.ToString();
                using (DatabaseContext __dbcntxt = new())
                {
                    result += (" [ " + __dbcntxt.VideoCards.Single(item => (item.Id == VideoCardId)).Brand + " ]");
                }
                return result;
            }

        }

        [NotMapped]
        public string OriginalDeviceIdWithName
        {
            get
            {
                string result = "ID#" + OriginalDeviceId.ToString();
                using (DatabaseContext __dbcntxt = new())
                {
                    result += (" [ " + __dbcntxt.DeviceInformations.Single(item => (item.Id == OriginalDeviceId)).TosNumber + " ]");
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
        public string HDDIdWithName
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
        public string MiscIdWithName
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



    }
}
