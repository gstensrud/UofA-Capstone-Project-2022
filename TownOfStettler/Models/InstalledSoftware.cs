using System.ComponentModel.DataAnnotations.Schema;
using TownOfStettler.Data;

namespace TownOfStettler.Models
{
    public partial class InstalledSoftware
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public int SoftwareId { get; set; }

        public virtual DeviceInformation Device { get; set; } = null!;
        public virtual Software Software { get; set; } = null!;

        [NotMapped]
        public string DeviceIdWithName
        {
            get
            {
                string result = "ID#" + DeviceId.ToString();
                using (DatabaseContext __dbcntxt = new DatabaseContext())
                {
                    result += " [ " + __dbcntxt.DeviceInformations.Single(item => (item.Id == DeviceId)).TosNumber + " ]";
                }
                return result;
            }
        }

        [NotMapped]
        public string SoftwareIdWithName
        {
            get
            {
                string result = "ID#" + SoftwareId.ToString();
                using (DatabaseContext __dbcntxt = new DatabaseContext())
                {
                    result += " [ " + __dbcntxt.DeviceInformations.Single(item => (item.Id == SoftwareId)).TosNumber + " ]";
                }
                return result;
            }
        }

    }
}
