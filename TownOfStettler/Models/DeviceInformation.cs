using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TownOfStettler.Data;

namespace TownOfStettler.Models
{
    public partial class DeviceInformation
    {
        public DeviceInformation()
        {
            EthernetNetworks = new HashSet<EthernetNetwork>();
            HardDrives = new HashSet<HardDrive>();
            Histories = new HashSet<History>();
            InstalledSoftwares = new HashSet<InstalledSoftware>();
            InuseMonitors = new HashSet<InuseMonitor>();
            Parts = new HashSet<Part>();
            Printers = new HashSet<Printer>();
            Processors = new HashSet<Processor>();
            Rams = new HashSet<Ram>();
            MiscellaneousDrives = new HashSet<MiscellaneousDrive>();
            SoundCards = new HashSet<SoundCard>();
            VideoCards = new HashSet<VideoCard>();
            Warranties = new HashSet<Warranty>();
        }

        public int Id { get; set; }
        public int DeviceTypeId { get; set; }
        public int OwnerLocation { get; set; }
        public string TosNumber { get; set; } = null!;
        public string SerialNumber { get; set; } = null!;
        public string ModelNumber { get; set; } = null!;
        public string? PowerSupply { get; set; }
        public string PurchaseStore { get; set; } = null!;
        public decimal PurchasePrice { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly PurchaseDate { get; set; }
        public string OperatingSystem { get; set; } = null!;
        public bool Destroyed { get; set; }
        public string? Notes { get; set; }

        public virtual HardwareDevice DeviceType { get; set; } = null!;
        public virtual OwnerLocation OwnerLocationNavigation { get; set; } = null!;
        public virtual ICollection<EthernetNetwork> EthernetNetworks { get; set; }
        public virtual ICollection<HardDrive> HardDrives { get; set; }
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<InstalledSoftware> InstalledSoftwares { get; set; }
        public virtual ICollection<InuseMonitor> InuseMonitors { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
        public virtual ICollection<Printer> Printers { get; set; }
        public virtual ICollection<Processor> Processors { get; set; }
        public virtual ICollection<Ram> Rams { get; set; }
        public virtual ICollection<MiscellaneousDrive> MiscellaneousDrives { get; set; }
        public virtual ICollection<SoundCard> SoundCards { get; set; }
        public virtual ICollection<VideoCard> VideoCards { get; set; }
        public virtual ICollection<Warranty> Warranties { get; set; }

        [NotMapped]
        public string StrIntDate
        {
            get
            {
                return (PurchaseDate.ToString("yyyy-MM-dd"));

            }
        }


        //[NotMapped]
        //public string IdTos => DeviceTypeId + "-" + TosNumber;

        [NotMapped]
        public string DeviceTypeIdWithName
        {
            get
            {
                string result = "ID#" + DeviceTypeId.ToString();
                using (DatabaseContext __dbcntxt = new())
                {
                    result += (" [ " + __dbcntxt.HardwareDevices.Single(item => (item.Id == DeviceTypeId)).TypeOfHardware + " ]");
                }
                return result;
            }

        }


        [NotMapped]
        public string OwnerLocationIdWithName
        {
            get
            {
                string result = "ID#" + OwnerLocation.ToString();
                using (DatabaseContext __dbcntxt = new())
                {
                    result += (" [ " + __dbcntxt.OwnerLocations.Single(item => (item.Id == OwnerLocation)).Name + " ]");
                }
                return result;
            }

        }

    }
}
