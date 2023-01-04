using System.ComponentModel.DataAnnotations.Schema;
using TownOfStettler.Data;

namespace TownOfStettler.Models
{
    public partial class Printer
    {
        public int Id { get; set; }
        public string TosNumber { get; set; } = null!;
        public int OwnerLocation { get; set; }
        public int? DeviceId { get; set; }
        public string Type { get; set; } = null!;
        public string ConnectionType { get; set; } = null!;
        public int? History { get; set; }
        public string? Notes { get; set; }

        public virtual DeviceInformation? Device { get; set; }
        public virtual History? HistoryNavigation { get; set; }
        public virtual OwnerLocation OwnerLocationNavigation { get; set; } = null!;

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
