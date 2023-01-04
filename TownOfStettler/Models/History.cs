using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TownOfStettler.Data;

namespace TownOfStettler.Models
{
    public partial class History
    {
        public History()
        {
            DisplayMonitors = new HashSet<DisplayMonitor>();
            OtherHardwares = new HashSet<OtherHardware>();
            Parts = new HashSet<Part>();
            Printers = new HashSet<Printer>();
        }

        public int Id { get; set; }
        public int DeviceTypeId { get; set; }
        public int? DeviceId { get; set; }
        public int? PartsChanged { get; set; }
        public int? PastOwnerS { get; set; }
        public bool? Wiped { get; set; }
        public int? PartsRemoved { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly DateOfChanges { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly? OutOfServiceDate { get; set; }
        public string? Notes { get; set; }

        public virtual DeviceInformation? Device { get; set; }
        public virtual HardwareDevice DeviceType { get; set; } = null!;
        public virtual Modification? PartsChangedNavigation { get; set; }
        public virtual OwnerLocation? PastOwnerSNavigation { get; set; }
        public virtual ICollection<DisplayMonitor> DisplayMonitors { get; set; }
        public virtual ICollection<OtherHardware> OtherHardwares { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
        public virtual ICollection<Printer> Printers { get; set; }

        [NotMapped]
        public string StrDoC
        {
            get
            {
                return (DateOfChanges.ToString("yyyy-MM-dd"));
            }
        }

        [NotMapped]
        public string StrOoS
        {
            get
            {
                    if (OutOfServiceDate == null)
                {
                    return "";
                }
                else
                {
                    return (OutOfServiceDate?.ToString("yyyy-MM-dd"));
                }

            }
        }

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

        [NotMapped]
        public string DeviceTypeIdWithName
        {
            get
            {
                string result = "ID#" + DeviceTypeId.ToString();
                using (DatabaseContext __dbcntxt = new DatabaseContext())
                {

                    result += (" [ " + __dbcntxt.HardwareDevices.Single(item => (item.Id == DeviceTypeId)).TypeOfHardware + " ]");
                }
                return result;
            }
        }

    }
}
