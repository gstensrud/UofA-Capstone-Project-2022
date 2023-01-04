using System.ComponentModel.DataAnnotations.Schema;
using TownOfStettler.Data;

namespace TownOfStettler.Models
{
    public partial class EthernetNetwork
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string Speed { get; set; } = null!;
        public bool Wireless { get; set; }
        public bool Bluetooth { get; set; }
        public string SerialNumber { get; set; } = null!;
        public bool Destroyed { get; set; }
        public string? Notes { get; set; }

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

        public virtual DeviceInformation Device { get; set; } = null!;
    }
}
