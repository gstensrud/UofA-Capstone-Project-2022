namespace TownOfStettler.Models
{
    public partial class OwnerLocation
    {
        public OwnerLocation()
        {
            DeviceInformations = new HashSet<DeviceInformation>();
            Histories = new HashSet<History>();
            OtherHardwares = new HashSet<OtherHardware>();
            Printers = new HashSet<Printer>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Notes { get; set; }

        public virtual ICollection<DeviceInformation> DeviceInformations { get; set; }
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<OtherHardware> OtherHardwares { get; set; }
        public virtual ICollection<Printer> Printers { get; set; }
    }
}
