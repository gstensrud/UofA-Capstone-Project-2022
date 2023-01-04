using System.ComponentModel.DataAnnotations.Schema;

namespace TownOfStettler.Models
{
    public partial class HardwareDevice
    {
        public HardwareDevice()
        {
            DeviceInformations = new HashSet<DeviceInformation>();
            Histories = new HashSet<History>();
        }

        public int Id { get; set; }
        public string TypeOfHardware { get; set; } = null!;

        public virtual ICollection<DeviceInformation> DeviceInformations { get; set; }
        public virtual ICollection<History> Histories { get; set; }

        [NotMapped]
        public string HardDevice => Id + " - " + TypeOfHardware;

    }
}
