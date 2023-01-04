using System.ComponentModel.DataAnnotations.Schema;
using TownOfStettler.Data;

namespace TownOfStettler.Models
{
    public partial class VideoCard
    {
        public VideoCard()
        {
            Modifications = new HashSet<Modification>();
            Outputs = new HashSet<Output>();
            Parts = new HashSet<Part>();
        }

        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string? Brand { get; set; }
        public int RamSizeGb { get; set; }
        public string SerialNumber { get; set; } = null!;
        public bool Destroyed { get; set; }
        public string? Notes { get; set; }

        public virtual DeviceInformation Device { get; set; } = null!;
        public virtual ICollection<Modification> Modifications { get; set; }
        public virtual ICollection<Output> Outputs { get; set; }
        public virtual ICollection<Part> Parts { get; set; }

        [NotMapped]
        public string DeviceIdWithName
        {
            get
            {
                string result = "ID#" + DeviceId.ToString();
                using (DatabaseContext __dbcntxt = new())
                {
                    result += (" [ " + __dbcntxt.DeviceInformations.Single(item => (item.Id == DeviceId)).TosNumber + " ]");
                }
                return result;
            }

        }

    }
}
