using System.ComponentModel.DataAnnotations.Schema;
using TownOfStettler.Data;

namespace TownOfStettler.Models
{
    public partial class InuseMonitor
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public int MonitorId { get; set; }

        public virtual DeviceInformation Device { get; set; } = null!;
        public virtual DisplayMonitor Monitor { get; set; } = null!;

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
        public string MonitorIdWithName
        {
            get
            {
                string result = "ID#" + MonitorId.ToString();
                using (DatabaseContext __dbcntxt = new DatabaseContext())
                {
                    result += " [ " + __dbcntxt.DeviceInformations.Single(item => (item.Id == MonitorId)).TosNumber + " ]";
                }
                return result;
            }
        }

    }
}
