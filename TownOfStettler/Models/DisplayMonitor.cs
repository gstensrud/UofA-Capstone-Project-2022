namespace TownOfStettler.Models
{
    public partial class DisplayMonitor
    {
        public DisplayMonitor()
        {
            InuseMonitors = new HashSet<InuseMonitor>();
        }

        public int Id { get; set; }
        public string TosNumber { get; set; } = null!;
        public decimal ViewSizeInches { get; set; }
        public string ViewType { get; set; } = null!;
        public string? Resolution { get; set; }
        public int? RefreshRateHz { get; set; }
        public string SerialNumber { get; set; } = null!;
        public string? OutputType { get; set; }
        public int? NumberOfOutputs { get; set; }
        public int? History { get; set; }
        public string? Notes { get; set; }

        public virtual History? HistoryNavigation { get; set; }
        public virtual ICollection<InuseMonitor> InuseMonitors { get; set; }
    }
}
