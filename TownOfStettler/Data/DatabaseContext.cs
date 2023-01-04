using Microsoft.EntityFrameworkCore;
using TownOfStettler.Models;

namespace TownOfStettler.Data
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DeviceInformation> DeviceInformations { get; set; } = null!;
        public virtual DbSet<DisplayMonitor> DisplayMonitors { get; set; } = null!;
        public virtual DbSet<EthernetNetwork> EthernetNetworks { get; set; } = null!;
        public virtual DbSet<HardDrive> HardDrives { get; set; } = null!;
        public virtual DbSet<HardwareDevice> HardwareDevices { get; set; } = null!;
        public virtual DbSet<History> Histories { get; set; } = null!;
        public virtual DbSet<InstalledSoftware> InstalledSoftwares { get; set; } = null!;
        public virtual DbSet<InuseMonitor> InuseMonitors { get; set; } = null!;
        public virtual DbSet<Modification> Modifications { get; set; } = null!;
        public virtual DbSet<OtherHardware> OtherHardwares { get; set; } = null!;
        public virtual DbSet<Output> Outputs { get; set; } = null!;
        public virtual DbSet<OwnerLocation> OwnerLocations { get; set; } = null!;
        public virtual DbSet<Part> Parts { get; set; } = null!;
        public virtual DbSet<Printer> Printers { get; set; } = null!;
        public virtual DbSet<Processor> Processors { get; set; } = null!;
        public virtual DbSet<Ram> Rams { get; set; } = null!;
        public virtual DbSet<MiscellaneousDrive> MiscellaneousDrives { get; set; } = null!;
        public virtual DbSet<Software> Softwares { get; set; } = null!;
        public virtual DbSet<SoundCard> SoundCards { get; set; } = null!;
        public virtual DbSet<VideoCard> VideoCards { get; set; } = null!;
        public virtual DbSet<Warranty> Warranties { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;database=town_of_stettler_computer_inventory", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.24-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<DeviceInformation>(entity =>
            {
                entity.ToTable("device information");

                entity.HasIndex(e => e.DeviceTypeId, "device information_ibfk_1");

                entity.HasIndex(e => e.OwnerLocation, "device information_ibfk_2");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.DeviceTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Device Type ID");

                entity.Property(e => e.ModelNumber)
                    .HasMaxLength(50)
                    .HasColumnName("Model Number");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.OperatingSystem)
                    .HasMaxLength(30)
                    .HasColumnName("Operating System");

                entity.Property(e => e.OwnerLocation)
                    .HasColumnType("int(11)")
                    .HasColumnName("Owner/Location");

                entity.Property(e => e.PowerSupply)
                    .HasMaxLength(75)
                    .HasColumnName("Power Supply");

                entity.Property(e => e.PurchaseDate).HasColumnName("Purchase Date");

                entity.Property(e => e.PurchasePrice)
                    .HasPrecision(6, 2)
                    .HasColumnName("Purchase Price");

                entity.Property(e => e.PurchaseStore)
                    .HasMaxLength(30)
                    .HasColumnName("Purchase Store");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(30)
                    .HasColumnName("Serial Number");

                entity.Property(e => e.TosNumber)
                    .HasMaxLength(25)
                    .HasColumnName("TOS Number");

                entity.HasOne(d => d.DeviceType)
                    .WithMany(p => p.DeviceInformations)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("device information_ibfk_1");

                entity.HasOne(d => d.OwnerLocationNavigation)
                    .WithMany(p => p.DeviceInformations)
                    .HasForeignKey(d => d.OwnerLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("device information_ibfk_2");
            });

            modelBuilder.Entity<DeviceInformation>().HasData(
            new DeviceInformation
            {
                Id = 1,
                DeviceTypeId = 1,
                OwnerLocation = 1,
                TosNumber = " TOS0705C",
                SerialNumber = "NA",
                ModelNumber = "NA",
                PurchaseStore = "NA",
                PurchasePrice = 3594.00m,
                PurchaseDate = new DateOnly(2007, 05, 01),
                OperatingSystem = "Windows 2003 Server - Standard",
                Destroyed = false,
                Notes = "Dell Poweredge 840 Dual Core Xeon 2.13 Ghz",
            },
            new DeviceInformation
            {
                Id = 2,
                DeviceTypeId = 2,
                OwnerLocation = 2,
                TosNumber = "TOSO703AA",
                SerialNumber = "NA",
                ModelNumber = "NA",
                PurchaseStore = "NA",
                PurchasePrice = 1.00m,
                PurchaseDate = new DateOnly(2007, 03, 01),
                OperatingSystem = "unknown",
                Destroyed = false,
                Notes = "Dell Dimension E520/EQT5131",
            },
            new DeviceInformation
            {
                Id = 3,
                DeviceTypeId = 1,
                OwnerLocation = 4,
                TosNumber = "TOS0805D",
                SerialNumber = "NA",
                ModelNumber = "NA",
                PowerSupply = "Redundant Power Supply",
                PurchaseStore = "NA",
                PurchasePrice = 7085.00m,
                PurchaseDate = new DateOnly(2008, 05, 01),
                OperatingSystem = "Windows 2008 Server w/Downgrade Windows Server 2003 SP2 32 bit X64",
                Destroyed = false,
                Notes = "Dell Poweredge 2900/EQT5134/Spare",
            },
            new DeviceInformation
            {
                Id = 4,
                DeviceTypeId = 3,
                OwnerLocation = 3,
                TosNumber = "TOSL0907B",
                SerialNumber = "unknown",
                ModelNumber = "unknown",
                PowerSupply = "6 Cell Lithium Ion Battery",
                PurchaseStore = "unknown",
                PurchasePrice = 964.00m,
                PurchaseDate = new DateOnly(2009, 07, 01),
                OperatingSystem = "Windows Vista Buisness",
                Destroyed = true,
                Notes = "Dell Vostro 1520 Celeron 575/EQT5136/Disposed in 2018",
            },
            new DeviceInformation
            {
                Id = 5,
                DeviceTypeId = 3,
                OwnerLocation = 3,
                TosNumber = "TOSL0907C",
                SerialNumber = "unknown",
                ModelNumber = "unknown",
                PowerSupply = "6 Cell Lithium Ion Battery",
                PurchaseStore = "unknown",
                PurchasePrice = 964.00m,
                PurchaseDate = new DateOnly(2009, 07, 01),
                OperatingSystem = "Windows Vista Buisness",
                Destroyed = true,
                Notes = "Dell Vostro 1520 Celeron 575/EQT5136/Disposed in 2018",
            },
            new DeviceInformation
            {
                Id = 6,
                DeviceTypeId = 3,
                OwnerLocation = 3,
                TosNumber = "TOSL0907E",
                SerialNumber = "unknown",
                ModelNumber = "unknown",
                PowerSupply = "6 Cell Lithium Ion Battery",
                PurchaseStore = "unknown",
                PurchasePrice = 964.00m,
                PurchaseDate = new DateOnly(2009, 07, 01),
                OperatingSystem = "Windows Vista Buisness",
                Destroyed = true,
                Notes = "Dell Vostro 1520 Celeron 575/EQT5136/Disposed in 2018",
            },
            new DeviceInformation
            {
                Id = 7,
                DeviceTypeId = 2,
                OwnerLocation = 5,
                TosNumber = "TOS0912",
                SerialNumber = "unknown",
                ModelNumber = "unknown",
                PurchaseStore = "unknown",
                PurchasePrice = 1.00m,
                PurchaseDate = new DateOnly(2009, 12, 01),
                OperatingSystem = "Windows 7 Pro 64 bit",
                Destroyed = false,
                Notes = "EQT5145/Motherboard-ASUS P6T6 WS Revolution X58 ATX",
            },
            new DeviceInformation
            {
                Id = 8,
                DeviceTypeId = 3,
                OwnerLocation = 6,
                TosNumber = "TOSL1004",
                SerialNumber = "unknown",
                ModelNumber = "unknown",
                PowerSupply = "Battery",
                PurchaseStore = "unknown",
                PurchasePrice = 1.00m,
                PurchaseDate = new DateOnly(2010, 06, 15),
                OperatingSystem = "Windows 7 pro",
                Destroyed = false,
                Notes = "TOSL1005B/Dell Precision M6400",
            },
            new DeviceInformation
            {
                Id = 9,
                DeviceTypeId = 1,
                OwnerLocation = 7,
                TosNumber = "TOS",
                SerialNumber = "unknown",
                ModelNumber = "unknown",
                PowerSupply = "Redundant 570 Watt",
                PurchaseStore = "unknown",
                PurchasePrice = 15000.00m,
                PurchaseDate = new DateOnly(2010, 02, 01),
                OperatingSystem = "Windows 2008 Small Business SErver Standard w/5 CAL",
                Destroyed = false,
                Notes = "Spare/EQT5148/Dell Poweredge R710/VMWare Server/8M Cache/Turbo/HT/1066MHz Max Mem/1333 MHZ Dual Ranked RDIMMs/iDRAC6 Enterprise/Ultra 320 SCSI PCI3 Host Adapter",
            },
            new DeviceInformation
            {
                Id = 10,
                DeviceTypeId = 3,
                OwnerLocation = 8,
                TosNumber = "TOSL1103",
                SerialNumber = "CNU1080527",
                ModelNumber = "unknown",
                PowerSupply = "Battery",
                PurchaseStore = "unknown",
                PurchasePrice = 1300.00m,
                PurchaseDate = new DateOnly(2011, 03, 01),
                OperatingSystem = "Windows 7 Pro 64 Bit",
                Destroyed = false,
                Notes = "HP ProBook 6500B WX303UT/EQT5153",
            },
            new DeviceInformation
            {
                Id = 11,
                DeviceTypeId = 3,
                OwnerLocation = 3,
                TosNumber = "TOS1111C",
                SerialNumber = "unknown",
                ModelNumber = "unknown",
                PowerSupply = "Battery",
                PurchaseStore = "unknown",
                PurchasePrice = 1730.00m,
                PurchaseDate = new DateOnly(2011, 11, 01),
                OperatingSystem = "Windows 7 PRo 64 Bit",
                Destroyed = true,
                Notes = "EQT5153/Touch Intel P-Series/Speakers/Mouse/Keyboard",
            },
            new DeviceInformation
            {
                Id = 12,
                DeviceTypeId = 3,
                OwnerLocation = 3,
                TosNumber = "TOS1111D",
                SerialNumber = "unknown",
                ModelNumber = "unknown",
                PowerSupply = "Battery",
                PurchaseStore = "unknown",
                PurchasePrice = 1730.00m,
                PurchaseDate = new DateOnly(2011, 11, 01),
                OperatingSystem = "Windows 7 PRo 64 Bit",
                Destroyed = true,
                Notes = "EQT5153/Touch Intel P-Series/Speakers/Mouse/Keyboard",
            },
            new DeviceInformation
            {
                Id = 13,
                DeviceTypeId = 3,
                OwnerLocation = 3,
                TosNumber = "TOS1111B",
                SerialNumber = "124973",
                ModelNumber = "V1116390",
                PowerSupply = "Battery",
                PurchaseStore = "unknown",
                PurchasePrice = 1843.00m,
                PurchaseDate = new DateOnly(2011, 11, 01),
                OperatingSystem = "Windows 7 PRo 64 Bit",
                Destroyed = true,
                Notes = "EQT5153/Touch Intel P-Series/Speakers/Mouse/Keyboard",
            },
            new DeviceInformation
            {
                Id = 14,
                DeviceTypeId = 3,
                OwnerLocation = 3,
                TosNumber = "TOS1111A",
                SerialNumber = "124974",
                ModelNumber = "V1116391",
                PowerSupply = "Battery",
                PurchaseStore = "unknown",
                PurchasePrice = 1627.00m,
                PurchaseDate = new DateOnly(2011, 11, 01),
                OperatingSystem = "Windows 7 PRo 64 Bit",
                Destroyed = true,
                Notes = "EQT5153/Touch Intel P-Series/Speakers/Mouse/Keyboard",
            },
            new DeviceInformation
            {
                Id = 15,
                DeviceTypeId = 3,
                OwnerLocation = 1,
                TosNumber = "TOS1111E",
                SerialNumber = "124975",
                ModelNumber = "V1116380",
                PurchaseStore = "unknown",
                PurchasePrice = 1726.00m,
                PurchaseDate = new DateOnly(2011, 11, 01),
                OperatingSystem = "Windows 7 Pro 64 Bit",
                Destroyed = false,
                Notes = "EQT5153/Touch Intel P-Series/Speakers/Mouse/Keyboard",
            },
            new DeviceInformation
            {
                Id = 16,
                DeviceTypeId = 3,
                OwnerLocation = 8,
                TosNumber = "TOS1205",
                SerialNumber = "125409",
                ModelNumber = "V1210920",
                PurchaseStore = "unknown",
                PurchasePrice = 1703.00m,
                PurchaseDate = new DateOnly(2011, 11, 01),
                OperatingSystem = "Windows 7 Pro 64 Bit",
                Destroyed = false,
                Notes = "EQT5160/Touch Intel P-Series/Mouse/Keyboard",
            },
            new DeviceInformation
            {
                Id = 17,
                DeviceTypeId = 6,
                OwnerLocation = 9,
                TosNumber = "TOS1210",
                SerialNumber = "unknown",
                ModelNumber = "unknown",
                PurchaseStore = "unknown",
                PurchasePrice = 710.00m,
                PurchaseDate = new DateOnly(2012, 10, 01),
                OperatingSystem = "iOS",
                Destroyed = false,
                Notes = "EQT5160/Apple iPad3 w/wifi/Black/Front&Rear Cameras/Smart Cover&Logitech wireless keyboard w/stand",
                //},
                //new DeviceInformation
                //{
                //    Id = 18,  //int PK
                //    DeviceTypeId = 2,  //int FK
                //    OwnerLocation = 8,  //int FK
                //    TosNumber = "TOS1211A", //varchar(25)
                //    SerialNumber = "unknown",  //varchar(30)
                //    ModelNumber = "unknown",  //varchar(50)
                //    PowerSupply = "",  //varchar(75) (nullable)
                //    PurchaseStore = "unknown",  //varchar(30)
                //    PurchasePrice = m,  //decimal(6,2)
                //    PurchaseDate = new DateOnly(),  //date
                //    OperatingSystem = "",  //varchar(30)
                //    Destroyed = ,  //bool
                //    Notes = "EQT5160/Wiped",  //text (nullable)

                // *******NOT MAPPED PROPERTIES********
                //    InstalledSoftware = ,
                //    InuseMonitors = ,  
            }
            //new DeviceInformation
            //{
            //    Id = ,  //int PK
            //    DeviceTypeId = ,  //int FK
            //    OwnerLocation = ,  //int FK
            //    TosNumber = "TOS", //varchar(25)
            //    DisplayMonitor = ,  //int FK (nullable)
            //    SerialNumber = "unknown",  //varchar(30)
            //    ModelNumber = "unknown",  //varchar(50)
            //    PowerSupply = "",  //varchar(75) (nullable)
            //    PurchaseStore = "unknown",  //varchar(30)
            //    PurchasePrice = m,  //decimal(6,2)
            //    PurchaseDate = new DateOnly(),  //date
            //    OperatingSystem = "",  //varchar(30)
            //    Destroyed = ,  //bool
            //    Notes = "",  //text (nullable)
            //}
            );

            modelBuilder.Entity<DisplayMonitor>(entity =>
            {
                entity.ToTable("display monitors");

                entity.HasIndex(e => e.History, "History");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.History).HasColumnType("int(11)");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.NumberOfOutputs)
                    .HasColumnType("int(11)")
                    .HasColumnName("Number of Outputs");

                entity.Property(e => e.OutputType)
                    .HasMaxLength(10)
                    .HasColumnName("Output Type");

                entity.Property(e => e.RefreshRateHz)
                    .HasColumnType("int(3)")
                    .HasColumnName("Refresh Rate (Hz)");

                entity.Property(e => e.Resolution).HasMaxLength(20);

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(50)
                    .HasColumnName("Serial Number");

                entity.Property(e => e.TosNumber)
                    .HasMaxLength(25)
                    .HasColumnName("TOS Number");

                entity.Property(e => e.ViewSizeInches)
                    .HasPrecision(3, 2)
                    .HasColumnName("View Size (Inches)");

                entity.Property(e => e.ViewType)
                    .HasMaxLength(30)
                    .HasColumnName("View Type");

                entity.HasOne(d => d.HistoryNavigation)
                    .WithMany(p => p.DisplayMonitors)
                    .HasForeignKey(d => d.History)
                    .HasConstraintName("display monitors_ibfk_2");
            });

            modelBuilder.Entity<DisplayMonitor>().HasData(
            new DisplayMonitor
            {
                Id = 1,
                TosNumber = "unknown",
                ViewSizeInches = 15.4m,
                ViewType = "LCD ",
                Resolution = "NA",
                RefreshRateHz = 0,
                SerialNumber = "unknown",
                OutputType = "Unknown",
                NumberOfOutputs = 1,
                Notes = "WXGA Anti Glare",
            },
            new DisplayMonitor
            {
                Id = 2,
                TosNumber = "unknown",
                ViewSizeInches = 17.0m,
                ViewType = "monitor",
                SerialNumber = "unknown",
                Notes = "NA",
            },
            new DisplayMonitor
            {
                Id = 3,
                TosNumber = "unknown",
                ViewSizeInches = 15.6m,
                ViewType = "LED",
                Resolution = "1366 x 768",
                SerialNumber = "unknown",
                RefreshRateHz = 0,
                Notes = "NA",
            },
            new DisplayMonitor
            {
                Id = 4,
                TosNumber = "unknown",
                ViewSizeInches = 9.7m,
                ViewType = "Retina",
                Resolution = "2048x1536",
                SerialNumber = "unknown",
                Notes = "NA",
            }
            //new DisplayMonitor
            //{
            //    Id = , //int PK
            //    TosNumber = "unknown", //varchar(25)
            //    ViewSizeInches = ,  //decimal (3,2)
            //    ViewType = "",  //varchar (30)
            //    Resolution = "",  //varchar(20) (nullable)
            //    RefreshRateHz = ,  //int(3) (nullable)
            //    SerialNumber = "",  //varchar(50)
            //    OutputType = "",  //varchar(10) (nullable)
            //    NumberOfOutputs = ,  //int (nullable)
            //    History = ,  //int FK(nullable)
            //    Notes = "",  //text (nullable)
            //},
            );

            modelBuilder.Entity<EthernetNetwork>(entity =>
            {
                entity.ToTable("ethernet/network");

                entity.HasIndex(e => e.DeviceId, "ethernet/network_ibfk_1");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.DeviceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Device ID");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(30)
                    .HasColumnName("Serial Number");

                entity.Property(e => e.Speed).HasMaxLength(30);

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.EthernetNetworks)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ethernet/network_ibfk_1");
            });

            modelBuilder.Entity<EthernetNetwork>().HasData(
            new EthernetNetwork
            {
                Id = 1,
                DeviceId = 3,
                Speed = "1000",
                Wireless = false,
                Bluetooth = false,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "NA",
            },
            new EthernetNetwork
            {
                Id = 2,
                DeviceId = 3,
                Speed = "1000",
                Wireless = false,
                Bluetooth = false,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "NA",
            },
            new EthernetNetwork
            {
                Id = 3,
                DeviceId = 9,
                Speed = "",
                Wireless = false,
                Bluetooth = false,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "Broadcom NetXtreme II 5709 Gigabit Ethernet NIC",
            },
            new EthernetNetwork
            {
                Id = 4,
                DeviceId = 10,
                Speed = "10/100/1000 LAN",
                Wireless = true,
                Bluetooth = true,
                SerialNumber = "Unknown",
                Destroyed = false,
                Notes = "NA",
            },
            new EthernetNetwork
            {
                Id = 5,
                DeviceId = 11,
                Speed = "10/100/1000 LAN",
                Wireless = true,
                Bluetooth = true,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "NA",
            },
            new EthernetNetwork
            {
                Id = 6,
                DeviceId = 12,
                Speed = "10/100/1000 LAN",
                Wireless = true,
                Bluetooth = true,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "NA",
            },
            new EthernetNetwork
            {
                Id = 7,
                DeviceId = 13,
                Speed = "10/100/1000 LAN",
                Wireless = true,
                Bluetooth = true,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "NA",
            },
            new EthernetNetwork
            {
                Id = 8,
                DeviceId = 14,
                Speed = "10/100/1000 LAN",
                Wireless = true,
                Bluetooth = true,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "NA",
            },
            new EthernetNetwork
            {
                Id = 9,
                DeviceId = 15,
                Speed = "10/100/1000 LAN",
                Wireless = true,
                Bluetooth = true,
                SerialNumber = "Unknown",
                Destroyed = false,
                Notes = "NA",
            },
            new EthernetNetwork
            {
                Id = 10,
                DeviceId = 16,
                Speed = "10/100/1000 LAN",
                Wireless = true,
                Bluetooth = true,
                SerialNumber = "Unknown",
                Destroyed = false,
                Notes = "NA",
            }
            //new EthernetNetwork
            //{
            //    Id = ,  //int PK
            //    DeviceId = ,  //int FK
            //    Speed = "",  //varchar (30)
            //    Wireless = ,  //bool
            //    Bluetooth = ,  //bool
            //    SerialNumber = "Unknown",  //varchar(30)
            //    Destroyed = ,  //bool
            //    Notes = "NA",  //text (nullable)
            //}                
            );

            modelBuilder.Entity<HardDrive>(entity =>
            {
                entity.ToTable("hard drive");

                entity.HasIndex(e => e.DeviceId, "hard drive_ibfk_1");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.DeviceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Device ID");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(30)
                    .HasColumnName("Serial Number");

                entity.Property(e => e.SizeGb)
                    .HasColumnType("int(7)")
                    .HasColumnName("Size (Gb)");

                entity.Property(e => e.Type).HasMaxLength(20);

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.HardDrives)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("hard drive_ibfk_1");
            });

            modelBuilder.Entity<HardDrive>().HasData(
            new HardDrive
            {
                Id = 1,
                DeviceId = 1,
                Type = "Unknown",
                SizeGb = 160,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "NA"
            },
            new HardDrive
            {
                Id = 2,
                DeviceId = 1,
                Type = "Raid",
                SizeGb = 160,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "NA"
            },
            new HardDrive
            {
                Id = 3,
                DeviceId = 3,
                Type = "Hot Swap",
                SizeGb = 73,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "OS"
            },
            new HardDrive
            {
                Id = 4,
                DeviceId = 3,
                Type = "Hot Swap",
                SizeGb = 73,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "OS"
            },
            new HardDrive
            {
                Id = 5,
                DeviceId = 3,
                Type = "Hot Swap",
                SizeGb = 300,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "Data   15K RPM"
            },
            new HardDrive
            {
                Id = 6,
                DeviceId = 3,
                Type = "Hot Swap",
                SizeGb = 300,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "Data   15K RPM"
            },
            new HardDrive
            {
                Id = 7,
                DeviceId = 3,
                Type = "Hot Swap",
                SizeGb = 300,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "Data   15K RPM"
            },
            new HardDrive
            {
                Id = 8,
                DeviceId = 4,
                Type = "SATA",
                SizeGb = 160,
                SerialNumber = "unknown",
                Destroyed = true,
                Notes = "5400rpm/"
            },
            new HardDrive
            {
                Id = 9,
                DeviceId = 5,
                Type = "SATA",
                SizeGb = 160,
                SerialNumber = "unknown",
                Destroyed = true,
                Notes = "5400rpm/"
            },
            new HardDrive
            {
                Id = 10,
                DeviceId = 6,
                Type = "SATA",
                SizeGb = 160,
                SerialNumber = "unknown",
                Destroyed = true,
                Notes = "5400rpm/"
            },
            new HardDrive
            {
                Id = 11,
                DeviceId = 7,
                Type = "SATA",
                SizeGb = 1000,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "7200rpm/"
            },
            new HardDrive
            {
                Id = 12,
                DeviceId = 7,
                Type = "SATA 2",
                SizeGb = 300,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "Digital VelociRaptor 10000"
            },
            new HardDrive
            {
                Id = 13,
                DeviceId = 8,
                Type = "unknown",
                SizeGb = 150,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "NA"
            },
            new HardDrive
            {
                Id = 14,
                DeviceId = 9,
                Type = "RAID",
                SizeGb = 500,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "7200rpm/Near Line SAS 3.5'' Hot Plug"
            },
            new HardDrive
            {
                Id = 15,
                DeviceId = 9,
                Type = "RAID",
                SizeGb = 500,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "7200rpm/Near Line SAS 3.5'' Hot Plug"
            },
            new HardDrive
            {
                Id = 16,
                DeviceId = 9,
                Type = "RAID",
                SizeGb = 500,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "7200rpm/Near Line SAS 3.5'' Hot Plug"
            },
            new HardDrive
            {
                Id = 17,
                DeviceId = 9,
                Type = "RAID",
                SizeGb = 500,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "7200rpm/Near Line SAS 3.5'' Hot Plug"
            },
            new HardDrive
            {
                Id = 18,
                DeviceId = 10,
                Type = "SATA II",
                SizeGb = 320,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "7200rpm"
            },
            new HardDrive
            {
                Id = 19,
                DeviceId = 11,
                Type = "SATA",
                SizeGb = 250,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "NA"
            },
            new HardDrive
            {
                Id = 20,
                DeviceId = 12,
                Type = "SATA",
                SizeGb = 250,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "NA"
            },
            new HardDrive
            {
                Id = 21,
                DeviceId = 13,
                Type = "SATA",
                SizeGb = 300,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "NA"
            },
            new HardDrive
            {
                Id = 22,
                DeviceId = 14,
                Type = "SATA",
                SizeGb = 300,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "NA"
            },
            new HardDrive
            {
                Id = 23,
                DeviceId = 15,
                Type = "SATA",
                SizeGb = 250,
                SerialNumber = "Unknown",
                Destroyed = false,
                Notes = "NA"
            },
            new HardDrive
            {
                Id = 24,
                DeviceId = 16,
                Type = "SATA",
                SizeGb = 320,
                SerialNumber = "Unknown",
                Destroyed = false,
                Notes = "NA"
            },
            new HardDrive
            {
                Id = 25,
                DeviceId = 17,
                Type = "Apple",
                SizeGb = 16,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "NA"
            }
            //new HardDrive
            //{
            //    Id = ,  //int PK
            //    DeviceId = ,  //int FK
            //    Type = ,  //varchar(20)
            //    SizeGb = ,  //int(7)
            //    SerialNumber = "",  //varchar(30)
            //    Destroyed = ,  //bool
            //    Notes = "NA"  //text (nullable)
            //}
            );

            modelBuilder.Entity<HardwareDevice>(entity =>
            {
                entity.ToTable("hardware device");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.TypeOfHardware)
                    .HasMaxLength(20)
                    .HasColumnName("Type of Hardware");
            });

            modelBuilder.Entity<HardwareDevice>().HasData(
            new HardwareDevice
            {
                Id = 1,
                TypeOfHardware = "Server",
            },
            new HardwareDevice
            {
                Id = 2,
                TypeOfHardware = "Desktop",
            },
            new HardwareDevice
            {
                Id = 3,
                TypeOfHardware = "Laptop",
            },
            new HardwareDevice
            {
                Id = 4,
                TypeOfHardware = "Monitor",
            },
            new HardwareDevice
            {
                Id = 5,
                TypeOfHardware = "Printer",
            },
            new HardwareDevice
            {
                Id = 6,
                TypeOfHardware = "Misc. Devices",
            }
            //new HardwareDevice
            //{
            //    Id = ,  //int PK
            //    TypeOfHardware = "",  //varchar(20)
            //}
            );

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("history");

                entity.HasIndex(e => e.DeviceTypeId, "Device Type ID");

                entity.HasIndex(e => e.DeviceId, "history_ibfk_1");

                entity.HasIndex(e => e.PastOwnerS, "history_ibfk_2");

                entity.HasIndex(e => e.PartsChanged, "history_ibfk_3");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.DateOfChanges).HasColumnName("Date of Changes");

                entity.Property(e => e.DeviceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Device ID");

                entity.Property(e => e.DeviceTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Device Type ID");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.OutOfServiceDate).HasColumnName("Out of Service Date");

                entity.Property(e => e.PartsChanged)
                    .HasColumnType("int(11)")
                    .HasColumnName("Parts Changed");

                entity.Property(e => e.PartsRemoved)
                    .HasColumnType("int(11)")
                    .HasColumnName("Parts Removed");

                entity.Property(e => e.PastOwnerS)
                    .HasColumnType("int(11)")
                    .HasColumnName("Past Owner(s)");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.DeviceId)
                    .HasConstraintName("history_ibfk_1");

                entity.HasOne(d => d.DeviceType)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("history_ibfk_4");

                entity.HasOne(d => d.PartsChangedNavigation)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.PartsChanged)
                    .HasConstraintName("history_ibfk_3");

                entity.HasOne(d => d.PastOwnerSNavigation)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.PastOwnerS)
                    .HasConstraintName("history_ibfk_2");
            });

            modelBuilder.Entity<History>().HasData(
            new History
            {
                Id = 1,
                DeviceTypeId = 2,
                DeviceId = 2,
                Wiped = true,
                Notes = "Dell Dimension E520",
            },
            new History
            {
                Id = 2,
                DeviceTypeId = 3,
                DeviceId = 4,
                OutOfServiceDate = new DateOnly(2018, 07, 01),
                Notes = "NA",
            },
            new History
            {
                Id = 3,
                DeviceTypeId = 3,
                DeviceId = 5,
                OutOfServiceDate = new DateOnly(2018, 07, 01),
                Notes = "NA",
            },
            new History
            {
                Id = 4,
                DeviceTypeId = 3,
                DeviceId = 6,
                OutOfServiceDate = new DateOnly(2018, 07, 01),
                Notes = "NA",
            },
            new History
            {
                Id = 5,
                DeviceTypeId = 3,
                DeviceId = 10,
                Wiped = true,
                Notes = "NA",
            },
            new History
            {
                Id = 6,
                DeviceTypeId = 3,
                DeviceId = 11,
                OutOfServiceDate = new DateOnly(2018, 07, 01),
                Notes = "NA",
            },
            new History
            {
                Id = 7,
                DeviceTypeId = 3,
                DeviceId = 12,
                OutOfServiceDate = new DateOnly(2018, 07, 01),
                Notes = "NA",
            },
            new History
            {
                Id = 8,
                DeviceTypeId = 3,
                DeviceId = 13,
                OutOfServiceDate = new DateOnly(2018, 07, 01),
                Notes = "NA",
            },
            new History
            {
                Id = 9,
                DeviceTypeId = 3,
                DeviceId = 14,
                OutOfServiceDate = new DateOnly(2018, 07, 01),
                Notes = "NA",
            },
            new History
            {
                Id = 10,
                DeviceTypeId = 3,
                DeviceId = 16,
                Wiped = true,
                Notes = "NA",
            }
            //new History
            //{
            //    Id = 1,  //int PK
            //    DeviceTypeId = ,  //int FK
            //    DeviceId = ,  //int FK (nullable)
            //    PartsChanged = ,  //int FK (nullable)
            //    PastOwnerS = ,  //int FK (nullable)
            //    Wiped = ,  //bool (nullable)
            //    PartsRemoved = ,  //int FK (nullable)
            //    DateOfChanges = new DateOnly(),  //date (nullable)
            //    OutOfServiceDate = new DateOnly(),  //date (nullable)
            //    Notes = "NA",  //text (nullable)
            //},
            );

            modelBuilder.Entity<InstalledSoftware>(entity =>
            {
                entity.ToTable("installed software");

                entity.HasIndex(e => e.DeviceId, "Device ID");

                entity.HasIndex(e => e.SoftwareId, "Software ID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.DeviceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Device ID");

                entity.Property(e => e.SoftwareId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Software ID");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.InstalledSoftwares)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("installed software_ibfk_1");

                entity.HasOne(d => d.Software)
                    .WithMany(p => p.InstalledSoftwares)
                    .HasForeignKey(d => d.SoftwareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("installed software_ibfk_2");
            });

            modelBuilder.Entity<InstalledSoftware>().HasData(
                new InstalledSoftware
                {
                    Id = 1,
                    DeviceId = 1,
                    SoftwareId = 1,
                },
                new InstalledSoftware
                {
                    Id = 2,
                    DeviceId = 1,
                    SoftwareId = 4,
                },
                new InstalledSoftware
                {
                    Id = 3,
                    DeviceId = 1,
                    SoftwareId = 5,
                },
                new InstalledSoftware
                {
                    Id = 4,
                    DeviceId = 3,
                    SoftwareId = 1,
                },
                new InstalledSoftware
                {
                    Id = 5,
                    DeviceId = 1,
                    SoftwareId = 3,
                },
                new InstalledSoftware
                {
                    Id = 6,
                    DeviceId = 5,
                    SoftwareId = 3,
                },
                new InstalledSoftware
                {
                    Id = 7,
                    DeviceId = 6,
                    SoftwareId = 3,
                },
                new InstalledSoftware
                {
                    Id = 8,
                    DeviceId = 8,
                    SoftwareId = 6,
                },
                new InstalledSoftware
                {
                    Id = 9,
                    DeviceId = 8,
                    SoftwareId = 8,
                },
                new InstalledSoftware
                {
                    Id = 10,
                    DeviceId = 9,
                    SoftwareId = 9,
                },
                new InstalledSoftware
                {
                    Id = 11,
                    DeviceId = 9,
                    SoftwareId = 10,
                },
                new InstalledSoftware
                {
                    Id = 12,
                    DeviceId = 10,
                    SoftwareId = 6,
                },
                new InstalledSoftware
                {
                    Id = 13,
                    DeviceId = 10,
                    SoftwareId = 11,
                },
                new InstalledSoftware
                {
                    Id = 14,
                    DeviceId = 11,
                    SoftwareId = 6,
                },
                new InstalledSoftware
                {
                    Id = 15,
                    DeviceId = 11,
                    SoftwareId = 11,
                },
                new InstalledSoftware
                {
                    Id = 16,
                    DeviceId = 12,
                    SoftwareId = 6,
                },
                new InstalledSoftware
                {
                    Id = 17,
                    DeviceId = 12,
                    SoftwareId = 11,
                },
                new InstalledSoftware
                {
                    Id = 18,
                    DeviceId = 13,
                    SoftwareId = 6,
                },
                new InstalledSoftware
                {
                    Id = 19,
                    DeviceId = 13,
                    SoftwareId = 11,
                },
                new InstalledSoftware
                {
                    Id = 20,
                    DeviceId = 14,
                    SoftwareId = 6,
                },
                new InstalledSoftware
                {
                    Id = 21,
                    DeviceId = 14,
                    SoftwareId = 11,
                },
                new InstalledSoftware
                {
                    Id = 22,
                    DeviceId = 15,
                    SoftwareId = 6,
                },
                new InstalledSoftware
                {
                    Id = 23,
                    DeviceId = 15,
                    SoftwareId = 11,
                },
                new InstalledSoftware
                {
                    Id = 24,
                    DeviceId = 16,
                    SoftwareId = 6,
                },
                new InstalledSoftware
                {
                    Id = 25,
                    DeviceId = 16,
                    SoftwareId = 11,
                }
                //new InstalledSoftware
                //{
                //    Id = ,  //int FK
                //    DeviceId = ,  //int FK
                //    SoftwareId = ,  //int FK
                //}
                );

            modelBuilder.Entity<InuseMonitor>(entity =>
            {
                entity.ToTable("inuse monitors");

                entity.HasIndex(e => e.DeviceId, "Device ID");

                entity.HasIndex(e => e.MonitorId, "Monitor ID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.DeviceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Device ID");

                entity.Property(e => e.MonitorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Monitor ID");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.InuseMonitors)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("inuse monitors_ibfk_1");

                entity.HasOne(d => d.Monitor)
                    .WithMany(p => p.InuseMonitors)
                    .HasForeignKey(d => d.MonitorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("inuse monitors_ibfk_2");
            });

            modelBuilder.Entity<InuseMonitor>().HasData(
            new InuseMonitor
            {
                Id = 1,
                DeviceId = 4,
                MonitorId = 1,
            },
            new InuseMonitor
            {
                Id = 2,
                DeviceId = 5,
                MonitorId = 1,
            },
            new InuseMonitor
            {
                Id = 3,
                DeviceId = 6,
                MonitorId = 1,
            },
            new InuseMonitor
            {
                Id = 4,
                DeviceId = 8,
                MonitorId = 2,
            },
            new InuseMonitor
            {
                Id = 5,
                DeviceId = 10,
                MonitorId = 3,
            },
            new InuseMonitor
            {
                Id = 6,
                DeviceId = 17,
                MonitorId = 4,
            }
            //new InuseMonitor
            //{
            //    Id = ,  //int PK
            //    DeviceId = ,  //int FK
            //    MonitorId = ,  //int FK
            //},
            );

            modelBuilder.Entity<Modification>(entity =>
            {
                entity.ToTable("modifications");

                entity.HasIndex(e => e.HardDriveId, "modifications_ibfk_1");

                entity.HasIndex(e => e.ProcessorId, "modifications_ibfk_2");

                entity.HasIndex(e => e.RamId, "modifications_ibfk_3");

                entity.HasIndex(e => e.MiscellaneousDriveId, "modifications_ibfk_4");

                entity.HasIndex(e => e.SoundCardId, "modifications_ibfk_5");

                entity.HasIndex(e => e.VideoCardId, "modifications_ibfk_6");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.HardDriveId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Hard Drive ID");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.ProcessorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Processor ID");

                entity.Property(e => e.RamId)
                    .HasColumnType("int(11)")
                    .HasColumnName("RAM ID");

                entity.Property(e => e.MiscellaneousDriveId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Miscellaneous Drive ID");

                entity.Property(e => e.SoundCardId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Sound Card ID");

                entity.Property(e => e.VideoCardId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Video Card ID");

                entity.HasOne(d => d.HardDrive)
                    .WithMany(p => p.Modifications)
                    .HasForeignKey(d => d.HardDriveId)
                    .HasConstraintName("modifications_ibfk_1");

                entity.HasOne(d => d.Processor)
                    .WithMany(p => p.Modifications)
                    .HasForeignKey(d => d.ProcessorId)
                    .HasConstraintName("modifications_ibfk_2");

                entity.HasOne(d => d.Ram)
                    .WithMany(p => p.Modifications)
                    .HasForeignKey(d => d.RamId)
                    .HasConstraintName("modifications_ibfk_3");

                entity.HasOne(d => d.MiscellaneousDrive)
                    .WithMany(p => p.Modifications)
                    .HasForeignKey(d => d.MiscellaneousDriveId)
                    .HasConstraintName("modifications_ibfk_4");

                entity.HasOne(d => d.SoundCard)
                    .WithMany(p => p.Modifications)
                    .HasForeignKey(d => d.SoundCardId)
                    .HasConstraintName("modifications_ibfk_5");

                entity.HasOne(d => d.VideoCard)
                    .WithMany(p => p.Modifications)
                    .HasForeignKey(d => d.VideoCardId)
                    .HasConstraintName("modifications_ibfk_6");
            });

            // modelBuilder.Entity<Modification>().HasData(
            //new Modification
            //{
            //    Id = 1,
            //    ProcessorId = ,
            //    RamId = ,
            //    HardDriveId = ,
            //    MiscellaneousDriveId = ,
            //    SoundCardId = ,
            //    VideoCardId  = ,
            //    Notes = "NA",
            //}
            //new Modification
            //{
            //    Id = ,  //int PK
            //    ProcessorId = ,  //int FK (nullable)
            //    RamId = ,  //int FK (nullable)
            //    HardDriveId = ,  //int FK (nullable)
            //    MiscellaneousDriveId = ,  //int FK (nullable)
            //    SoundCardId = ,  //int FK (nullable)
            //    VideoCardId  = ,  //int FK (nullable)
            //    Notes = "NA",//text (nullable)
            //}
            //);

            modelBuilder.Entity<OtherHardware>(entity =>
            {
                entity.ToTable("other hardware");

                entity.HasIndex(e => e.History, "History1");

                entity.HasIndex(e => e.OwnerLocation, "other hardware_ibfk_1");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.History).HasColumnType("int(11)");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.OwnerLocation)
                    .HasColumnType("int(11)")
                    .HasColumnName("Owner/Location");

                entity.Property(e => e.TosNumber)
                    .HasMaxLength(20)
                    .HasColumnName("TOS Number");

                entity.Property(e => e.TypeOfDevice).HasMaxLength(40);

                entity.HasOne(d => d.HistoryNavigation)
                    .WithMany(p => p.OtherHardwares)
                    .HasForeignKey(d => d.History)
                    .HasConstraintName("other hardware_ibfk_2");

                entity.HasOne(d => d.OwnerLocationNavigation)
                    .WithMany(p => p.OtherHardwares)
                    .HasForeignKey(d => d.OwnerLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("other hardware_ibfk_1");
            });

            modelBuilder.Entity<OtherHardware>().HasData(
            new OtherHardware
            {
                Id = 1,
                OwnerLocation = 1,
                TosNumber = "unknown",
                TypeOfDevice = "Keyboard",
                Destroyed = false,
                Notes = "NA",
            },
            new OtherHardware
            {
                Id = 2,
                OwnerLocation = 1,
                TosNumber = "unknown",
                TypeOfDevice = "Mouse",
                Destroyed = false,
                Notes = "NA",
            },
            new OtherHardware
            {
                Id = 3,
                OwnerLocation = 1,
                TosNumber = "unknown",
                TypeOfDevice = "Network Switch",
                Destroyed = false,
                Notes = "NA",
            }
            //new OtherHardware
            //{
            //  Id = ,  //int PK
            //  OwnerLocation = "",  //int FK
            //  TosNumber = "",  //varchar(20)
            //  TypeOfDevice = "",  //varchar(40)
            //  Destroyed = ,  //bool
            //  History = ,  //int FK (nullable)
            //  Notes = "NA",  //text (nullable)
            //}
            );

            modelBuilder.Entity<Output>(entity =>
            {
                entity.HasKey(e => e.Type)
                    .HasName("PRIMARY");

                entity.ToTable("outputs");

                entity.HasIndex(e => e.VideoCardId, "outputs_ibfk_1");

                entity.Property(e => e.Type).HasMaxLength(10);

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.NumberOfOutputs)
                    .HasColumnType("int(2)")
                    .HasColumnName("Number of Outputs");

                entity.Property(e => e.VideoCardId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Video Card ID");

                entity.HasOne(d => d.VideoCard)
                    .WithMany(p => p.Outputs)
                    .HasForeignKey(d => d.VideoCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("outputs_ibfk_1");
            });

            //modelBuilder.Entity<Output>().HasData(
            //  new Output
            //  {
            //      Type = "HDMI",
            //      VideoCardId = ,
            //      NumberOfOutputs = ,
            //      Notes = "",
            //  },
            //  new Output
            //  {
            //      Type = "",  //varchar(10) PK
            //      VideoCardId = ,  //int FK
            //      NumberOfOutputs = ,  //int(2)
            //      Notes = "NA",  //text (nullable)
            //      }
            //);

            modelBuilder.Entity<OwnerLocation>(entity =>
            {
                entity.ToTable("owner/location");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(75);

                entity.Property(e => e.Name).HasMaxLength(60);

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(14)
                    .HasColumnName("Phone Number");
            });

            modelBuilder.Entity<OwnerLocation>().HasData(
            new OwnerLocation
            {
                Id = 1,
                Name = "Fire Hall",
                Address = "Fire Hall",
                Notes = "Not Used",
            },
            new OwnerLocation
            {
                Id = 2,
                Name = "unknown",
                Address = "unknown",
                Notes = "Wiped",
            },
            new OwnerLocation
            {
                Id = 3,
                Name = "Disposed",
                Address = "Unknown",
                Notes = "Disposed ",
            },
            new OwnerLocation
            {
                Id = 4,
                Name = "STAPP",
                Address = "Unknown",
                Notes = "NA ",
            },
            new OwnerLocation
            {
                Id = 5,
                Name = "Graham",
                Address = "Unknown",
                Notes = "NA",
            },
            new OwnerLocation
            {
                Id = 6,
                Name = "Water Resivoir",
                Address = "Unknown",
                Notes = "NA",
            },
            new OwnerLocation
            {
                Id = 7,
                Name = "TOSDC1",
                Address = "unknown",
                Notes = "NA",
            },
            new OwnerLocation
            {
                Id = 8,
                Name = "Downstairs",
                Address = "unknown",
                Notes = "NA",
            },
            new OwnerLocation
            {
                Id = 9,
                Name = "Ivan",
                Address = "unknown",
                Notes = "NA",
            }
            //new OwnerLocation
            //{
            //    Id = ,  //int PK
            //    Name = "",  //varchar(60)
            //    Address = "",  //varchar(75)
            //    PhoneNumber = "",  //varchar(14) (nullable)
            //    Notes = "NA",  //text (nullable)
            //},            
            );

            modelBuilder.Entity<Part>(entity =>
            {
                entity.ToTable("parts");

                entity.HasIndex(e => e.HardDriveId, "parts_ibfk_2");

                entity.HasIndex(e => e.RamId, "parts_ibfk_3");

                entity.HasIndex(e => e.MiscellaneousDriveId, "parts_ibfk_4");

                entity.HasIndex(e => e.SoundCardId, "parts_ibfk_5");

                entity.HasIndex(e => e.VideoCardId, "parts_ibfk_6");

                entity.HasIndex(e => e.DeviceHistoryId, "parts_ibfk_7");

                entity.HasIndex(e => e.OriginalDeviceId, "parts_ibfk_8");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.DeviceHistoryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Device History ID");

                entity.Property(e => e.HardDriveId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Hard Drive ID");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.OriginalDeviceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Original Device ID");

                entity.Property(e => e.RamId)
                    .HasColumnType("int(11)")
                    .HasColumnName("RAM ID");

                entity.Property(e => e.MiscellaneousDriveId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Miscellaneous Drive ID");

                entity.Property(e => e.SoundCardId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Sound Card ID");

                entity.Property(e => e.VideoCardId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Video Card ID");

                entity.HasOne(d => d.DeviceHistory)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.DeviceHistoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("parts_ibfk_7");

                entity.HasOne(d => d.HardDrive)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.HardDriveId)
                    .HasConstraintName("parts_ibfk_2");

                entity.HasOne(d => d.OriginalDevice)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.OriginalDeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("parts_ibfk_8");

                entity.HasOne(d => d.Ram)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.RamId)
                    .HasConstraintName("parts_ibfk_3");

                entity.HasOne(d => d.MiscellaneousDrive)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.MiscellaneousDriveId)
                    .HasConstraintName("parts_ibfk_4");

                entity.HasOne(d => d.SoundCard)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.SoundCardId)
                    .HasConstraintName("parts_ibfk_5");

                entity.HasOne(d => d.VideoCard)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.VideoCardId)
                    .HasConstraintName("parts_ibfk_6");
            });

            //modelBuilder.Entity<Part>().HasData(
            //    new Part
            //    {
            //        Id = 1,
            //        OriginalDeviceId = ,
            //        DeviceHistoryId = ,
            //        RamId = ,
            //        HardDriveId = ,
            //        MiscellaneousDriveId = ,
            //        VideoCardId = ,
            //        SoundCardId = ,
            //        Notes = "",
            //     },
            //    new Part
            //    {
            //        Id = ,  //int PK
            //        OriginalDeviceId = ,  //int FK
            //        DeviceHistoryId = ,  //int FK
            //        RamId = ,  //int FK (nullable)
            //        HardDriveId = ,  //int FK (nullable)
            //        MiscellaneousDriveId = ,  //int FK (nullable)
            //        VideoCardId = ,  //int FK (nullable)
            //        SoundCardId = ,  //int FK (nullable)
            //        Notes = "NA",  //text (nullable)
            //     }
            //);

            modelBuilder.Entity<Printer>(entity =>
            {
                entity.ToTable("printers");

                entity.HasIndex(e => e.History, "History2");

                entity.HasIndex(e => e.DeviceId, "printers_ibfk_1");

                entity.HasIndex(e => e.OwnerLocation, "printers_ibfk_2");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.ConnectionType)
                    .HasMaxLength(15)
                    .HasColumnName("Connection Type");

                entity.Property(e => e.DeviceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Device ID");

                entity.Property(e => e.History).HasColumnType("int(11)");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.OwnerLocation)
                    .HasColumnType("int(11)")
                    .HasColumnName("Owner/Location");

                entity.Property(e => e.TosNumber)
                    .HasMaxLength(25)
                    .HasColumnName("TOS Number");

                entity.Property(e => e.Type).HasMaxLength(20);

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.Printers)
                    .HasForeignKey(d => d.DeviceId)
                    .HasConstraintName("printers_ibfk_1");

                entity.HasOne(d => d.HistoryNavigation)
                    .WithMany(p => p.Printers)
                    .HasForeignKey(d => d.History)
                    .HasConstraintName("printers_ibfk_3");

                entity.HasOne(d => d.OwnerLocationNavigation)
                    .WithMany(p => p.Printers)
                    .HasForeignKey(d => d.OwnerLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("printers_ibfk_2");
            });

            //modelBuilder.Entity<Printer>().HasData(
            //    new Printer
            //    {
            //        Id = ,  //int PK
            //        OwnerLocation = ,  //int FK
            //        TosNumber = ,  //varchar(25)
            //        DeviceId = ,  //int FK (nullable)
            //        Type = "",  //varchar(20)
            //        ConnectionType = "",  //varchar(15)
            //        History = ,  //int FK (nullable)
            //        Notes = "NA",  //text (nullable)
            //    }
            //);

            modelBuilder.Entity<Processor>(entity =>
            {
                entity.ToTable("processor");

                entity.HasIndex(e => e.DeviceId, "processor_ibfk_1");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.CoreCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("Core Count");

                entity.Property(e => e.DeviceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Device ID");

                entity.Property(e => e.Generation).HasColumnType("int(11)");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(30)
                    .HasColumnName("Serial Number");

                entity.Property(e => e.SpeedGhz)
                    .HasPrecision(5, 3)
                    .HasColumnName("Speed (GHz)");

                entity.Property(e => e.Type).HasMaxLength(25);

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.Processors)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("processor_ibfk_1");
            });

            modelBuilder.Entity<Processor>().HasData(
            new Processor
            {
                Id = 1,
                DeviceId = 1,
                Type = "Intel Xeon",
                SpeedGhz = 2.13m,
                SerialNumber = "unknown",
                CoreCount = 4,
                Destroyed = false,
                Notes = "NA",
            },
            new Processor
            {
                Id = 2,
                DeviceId = 3,
                Type = "Intel Xeon",
                SpeedGhz = 2.66m,
                SerialNumber = "unknown",
                CoreCount = 4,
                Destroyed = false,
                Notes = "2 Processors in this unit.  E54302x6MB Cache, 1333MHz FSB",
            },
            new Processor
            {
                Id = 3,
                DeviceId = 7,
                Type = "Intel i7",
                SpeedGhz = 2.67m,
                SerialNumber = "unknown",
                Destroyed = false,
            },
            new Processor
            {
                Id = 4,
                DeviceId = 8,
                Type = "Intel",
                SpeedGhz = 2.53m,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "Core 2 Duo P8700",
            },
            new Processor
            {
                Id = 5,
                DeviceId = 9,
                Type = " Intel Xeon",
                SpeedGhz = 2.4m,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "E5530/",
            },
            new Processor
            {
                Id = 6,
                DeviceId = 10,
                Type = "Intel i5",
                SpeedGhz = 2.53m,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "i5 460M, 3MB L3 Cache",
            },
            new Processor
            {
                Id = 7,
                DeviceId = 11,
                Type = "Intel Q/Xeon",
                SpeedGhz = 3.10m,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "1155 8M Box",
            },
            new Processor
            {
                Id = 8,
                DeviceId = 12,
                Type = "Intel Q/Xeon",
                SpeedGhz = 3.10m,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "1155 8M Box",
            },
            new Processor
            {
                Id = 9,
                DeviceId = 13,
                Type = "Intel Q/Xeon",
                SpeedGhz = 3.10m,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "1155 8M Box",
            },
            new Processor
            {
                Id = 10,
                DeviceId = 14,
                Type = "Intel Q/Xeon",
                SpeedGhz = 3.10m,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "1155 8M Box",
            },
            new Processor
            {
                Id = 11,
                DeviceId = 15,
                Type = "Intel Q/Xeon",
                SpeedGhz = 3.10m,
                SerialNumber = "Unknown",
                Destroyed = false,
                Notes = "1155 8M Box",
            },
            new Processor
            {
                Id = 12,
                DeviceId = 16,
                Type = "Intel Q/Xeon",
                SpeedGhz = 3.10m,
                SerialNumber = "Unknown",
                Destroyed = false,
                Notes = "1155 8M Box",
            }
            //new Processor
            //{
            //    Id = ,  //int PK
            //    DeviceId = ,  //int FK
            //    Type = "",  //varchar(25)
            //    SpeedGhz = ,  //decimal(5,3)
            //    SerialNumber = ,  //varchar(30)
            //    Generation = ,  //int(11) (nullable)
            //    CoreCount = ,  //int(11) (nullable)
            //    Destroyed = ,  //bool
            //    Notes = "NA",  //text (nullable)
            //}
            );

            modelBuilder.Entity<Ram>(entity =>
            {
                entity.ToTable("ram");

                entity.HasIndex(e => e.DeviceId, "ram_ibfk_1");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.DeviceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Device ID");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(30)
                    .HasColumnName("Serial Number");

                entity.Property(e => e.SizeGb)
                    .HasColumnType("int(11)")
                    .HasColumnName("Size (Gb)");

                entity.Property(e => e.SpeedMhz)
                    .HasColumnType("int(5)")
                    .HasColumnName("Speed (MHz)");

                entity.Property(e => e.Type).HasMaxLength(15);

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.Rams)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ram_ibfk_1");
            });

            modelBuilder.Entity<Ram>().HasData(
            new Ram
            {
                Id = 1,
                DeviceId = 1,
                Type = "Unknown",
                SizeGb = 2,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "NA",
            },
            new Ram
            {
                Id = 2,
                DeviceId = 3,
                Type = "Unknown",
                SizeGb = 1,
                SpeedMhz = 667,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "4 Sticks in this unit",
            },
            new Ram
            {
                Id = 3,
                DeviceId = 4,
                Type = "DDR2 SD",
                SizeGb = 3,
                SpeedMhz = 800,
                SerialNumber = "unknown",
                Destroyed = true,
                Notes = "NA",
            },
            new Ram
            {
                Id = 4,
                DeviceId = 5,
                Type = "DDR2 SD",
                SizeGb = 3,
                SpeedMhz = 800,
                SerialNumber = "unknown",
                Destroyed = true,
                Notes = "NA",
            },
            new Ram
            {
                Id = 5,
                DeviceId = 6,
                Type = "DDR2 SD",
                SizeGb = 3,
                SpeedMhz = 800,
                SerialNumber = "unknown",
                Destroyed = true,
                Notes = "NA",
            },
            new Ram
            {
                Id = 6,
                DeviceId = 7,
                Type = "DDR3",
                SizeGb = 6,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "1600",
            },
            new Ram
            {
                Id = 7,
                DeviceId = 8,
                Type = "not listed",
                SizeGb = 4,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "NA",
            },
            new Ram
            {
                Id = 8,
                DeviceId = 9,
                Type = "not listed",
                SizeGb = 4,
                SpeedMhz = 1333,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "4 sticks",
            },
            new Ram
            {
                Id = 9,
                DeviceId = 10,
                Type = "DDR",
                SizeGb = 4,
                SpeedMhz = 1333,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "NA",
            },
            new Ram
            {
                Id = 10,
                DeviceId = 11,
                Type = "DDR3",
                SizeGb = 4,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "Kingston",
            },
            new Ram
            {
                Id = 11,
                DeviceId = 12,
                Type = "DDR3",
                SizeGb = 4,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "Kingston",
            },
            new Ram
            {
                Id = 12,
                DeviceId = 13,
                Type = "DDR3",
                SizeGb = 4,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "Kingston",
            },
            new Ram
            {
                Id = 13,
                DeviceId = 14,
                Type = "DDR3",
                SizeGb = 4,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "Kingston",
            },
            new Ram
            {
                Id = 14,
                DeviceId = 15,
                Type = "DDR3",
                SizeGb = 8,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "Kingston",
            },
            new Ram
            {
                Id = 15,
                DeviceId = 16,
                Type = "DDR3",
                SizeGb = 4,
                SerialNumber = "Unknown",
                Destroyed = false,
                Notes = "Kingston",
            },
            new Ram
            {
                Id = 16,
                DeviceId = 17,
                Type = "Apple",
                SizeGb = 512,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "Ram is not 512 GB, its 512 MB...Apple iPad",
            }
            //new Ram
            //{
            //    Id = ,  //int PK
            //    DeviceId = ,  //int FK
            //    Type = "",  //varchar(15)
            //    SizeGb = ,  //int(11)
            //    SpeedMhz = ,  //int(5) (nullable)
            //    SerialNumber = ,  //varchar(30)
            //    Destroyed = ,  //bool
            //    Notes = "",  //text (nullable)
            //}
            );

            modelBuilder.Entity<MiscellaneousDrive>(entity =>
            {
                entity.ToTable("miscellaneous drives");

                entity.HasIndex(e => e.DeviceId, "miscellaneous drives_ibfk_1");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.DeviceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Device ID");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(30)
                    .HasColumnName("Serial Number");

                entity.Property(e => e.Type).HasMaxLength(30);

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.MiscellaneousDrives)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("miscellaneous drives_ibfk_1");
            });

            modelBuilder.Entity<MiscellaneousDrive>().HasData(
            new MiscellaneousDrive
            {
                Id = 1,
                DeviceId = 1,
                Type = "Not Stated/Backup",
                Removable = true,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "NA",
            },
            new MiscellaneousDrive
            {
                Id = 2,
                DeviceId = 1,
                Type = "CD-RW",
                Removable = false,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "NA",
            },
            new MiscellaneousDrive
            {
                Id = 3,
                DeviceId = 4,
                Type = "DVD +/- RW",
                Removable = false,
                SerialNumber = "unknown",
                Destroyed = true,
                Notes = "NA",
            },
            new MiscellaneousDrive
            {
                Id = 4,
                DeviceId = 5,
                Type = "DVD +/- RW",
                Removable = false,
                SerialNumber = "unknown",
                Destroyed = true,
                Notes = "NA",
            },
            new MiscellaneousDrive
            {
                Id = 5,
                DeviceId = 6,
                Type = "DVD +/- RW",
                Removable = false,
                SerialNumber = "unknown",
                Destroyed = true,
                Notes = "NA",
            },
            new MiscellaneousDrive
            {
                Id = 6,
                DeviceId = 9,
                Type = "External",
                Removable = true,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "LTO3 Backup Drive (TableTop)",
            },
            new MiscellaneousDrive
            {
                Id = 7,
                DeviceId = 10,
                Type = "DVD +/- RW",
                Removable = false,
                SerialNumber = "unknown",
                Destroyed = false,
                Notes = "Supermulti DL LightScribe",
            },
            new MiscellaneousDrive
            {
                Id = 8,
                DeviceId = 11,
                Type = "Card Reader",
                Removable = false,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "NA",
            },
            new MiscellaneousDrive
            {
                Id = 9,
                DeviceId = 12,
                Type = "Card Reader",
                Removable = false,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "NA",
            },
            new MiscellaneousDrive
            {
                Id = 10,
                DeviceId = 13,
                Type = "Card Reader",
                Removable = false,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "NA",
            },
            new MiscellaneousDrive
            {
                Id = 11,
                DeviceId = 14,
                Type = "Card Reader",
                Removable = false,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "NA",
            },
            new MiscellaneousDrive
            {
                Id = 12,
                DeviceId = 11,
                Type = "DVD 22x/22x",
                Removable = false,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "LG",
            },
            new MiscellaneousDrive
            {
                Id = 13,
                DeviceId = 12,
                Type = "DVD 22x/22x",
                Removable = false,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "LG",
            },
            new MiscellaneousDrive
            {
                Id = 14,
                DeviceId = 13,
                Type = "DVD 22x/22x",
                Removable = false,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "LG",
            },
            new MiscellaneousDrive
            {
                Id = 15,
                DeviceId = 14,
                Type = "DVD 22x/22x",
                Removable = false,
                SerialNumber = "Unknown",
                Destroyed = true,
                Notes = "LG",
            },
            new MiscellaneousDrive
            {
                Id = 16,
                DeviceId = 15,
                Type = "Card Reader",
                Removable = false,
                SerialNumber = "Unknown",
                Destroyed = false,
                Notes = "NA",
            },
            new MiscellaneousDrive
            {
                Id = 17,
                DeviceId = 15,
                Type = "DVD 22x/22x",
                Removable = false,
                SerialNumber = "Unknown",
                Destroyed = false,
                Notes = "LG",
            },
            new MiscellaneousDrive
            {
                Id = 18,
                DeviceId = 16,
                Type = "Card Reader",
                Removable = false,
                SerialNumber = "Unknown",
                Destroyed = false,
                Notes = "NA",
            },
            new MiscellaneousDrive
            {
                Id = 19,
                DeviceId = 16,
                Type = "DVD 22x/22x",
                Removable = false,
                SerialNumber = "Unknown",
                Destroyed = false,
                Notes = "LG",
            }
            //new MiscellaneousDrive
            //{
            //    Id = ,  //int PK
            //    DeviceId = ,  //int FK
            //    Type = "",  //varchar(30)
            //    Removable = ,  //bool
            //    SerialNumber = "",  //varchar(30)
            //    Destroyed = ,  //bool
            //    Notes = "",  //text (nullable)
            //}
            );

            modelBuilder.Entity<Software>(entity =>
            {
                entity.ToTable("software");

                entity.Property(e => e.Id)
                    .HasColumnType("int(50)")
                    .HasColumnName("ID");

                entity.Property(e => e.AssociatedAccount)
                    .HasMaxLength(50)
                    .HasColumnName("Associated Account");

                entity.Property(e => e.DevicesAllowed)
                    .HasColumnType("int(11)")
                    .HasColumnName("Devices Allowed");

                entity.Property(e => e.EndOfSupportDate).HasColumnName("End of Support Date");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.ProductKey)
                    .HasMaxLength(60)
                    .HasColumnName("Product Key");

                entity.Property(e => e.PurchaseDate).HasColumnName("Purchase Date");

                entity.Property(e => e.PurchasePrice)
                    .HasPrecision(5, 2)
                    .HasColumnName("Purchase Price");

                entity.Property(e => e.SoftwareName)
                    .HasMaxLength(75)
                    .HasColumnName("Software Name");

                entity.Property(e => e.SubscriptionEndDate).HasColumnName("Subscription End Date");
            });

            modelBuilder.Entity<Software>().HasData(
            new Software
            {
                Id = 1,
                ProductKey = "unknown",
                SoftwareName = "Windows 2003 Server - Standard",
            },
            new Software
            {
                Id = 2,
                ProductKey = "Unknown",
                SoftwareName = "Microsoft Excel 2007",
            },
            new Software
            {
                Id = 3,
                ProductKey = "unknown",
                SoftwareName = "Microsoft Office 2007 Small Buisness",
            },
            new Software
            {
                Id = 4,
                ProductKey = "unknown",
                SoftwareName = "5 Terminal Server CALS",
            },
            new Software
            {
                Id = 5,
                ProductKey = "unknown",
                SoftwareName = "Veritas Backup Exec",
            },
            new Software
            {
                Id = 6,
                ProductKey = "unknown",
                SoftwareName = "Windows 7 Pro 64 bit",
            },
            new Software
            {
                Id = 7,
                ProductKey = "unknown",
                SoftwareName = "Microsoft Office Pro 2010",
            },
            new Software
            {
                Id = 8,
                ProductKey = "Unknonw",
                SoftwareName = "Microsoft Office Pro 2007",
            },
            new Software
            {
                Id = 9,
                ProductKey = "unknown",
                SoftwareName = "Windows 2008 Small Business Server Standard w/5 CAL",
            },
            new Software
            {
                Id = 10,
                ProductKey = "unknown",
                SoftwareName = "Microsoft Small Business Server 2008 Std 20 User CAL",
            },
            new Software
            {
                Id = 11,
                ProductKey = "unknown",
                SoftwareName = "Microsoft Office 2010 Home & Business",
            }
            //new Software
            //{
            //    Id = ,  //int PK
            //    ProductKey = ,  //varchar(60) (nullable)
            //    SoftwareName = "",  //varchar(75)
            //    AssociatedAccount = ,  //varchar(50) (nullable)
            //    Subscription = ,  //bool (nullable)
            //    SubscriptionEndDate = new DateOnly(),  //date (nullable)
            //    PurchaseDate = new DateOnly(),  //date (nullable)
            //    PurchasePrice = ,  //decimal(5,2) (nullable)
            //    DevicesAllowed = ,  //int (nullable)
            //    EndOfSupportDate = new DateOnly(),  //date (nullable)
            //    Notes = "",  //text (nullable)
            //}
            );

            modelBuilder.Entity<SoundCard>(entity =>
            {
                entity.ToTable("sound card");

                entity.HasIndex(e => e.DeviceId, "sound card_ibfk_1");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Brand).HasMaxLength(20);

                entity.Property(e => e.DeviceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Device ID");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.SoundCards)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sound card_ibfk_1");
            });

            //modelBuilder.Entity<SoundCard>().HasData(
            //new SoundCard
            //{
            //    Id = 1,
            //    DeviceId = ,
            //    Brand = "",
            //    Destroyed = ,
            //    Notes = "",
            //},
            //new SoundCard
            //{
            //    Id = ,  //int PK
            //    DeviceId = ,  //int FK
            //    Brand = "",  //varchar(20) (nullable)
            //    Destroyed = , //bool
            //    Notes = "",  //text (nullable)
            //}
            //);

            modelBuilder.Entity<VideoCard>(entity =>
            {
                entity.ToTable("video card");

                entity.HasIndex(e => e.DeviceId, "video card_ibfk_1");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Brand).HasMaxLength(20);

                entity.Property(e => e.DeviceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Device ID");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.RamSizeGb)
                    .HasColumnType("int(11)")
                    .HasColumnName("Ram Size (GB)");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(30)
                    .HasColumnName("Serial Number");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.VideoCards)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("video card_ibfk_1");
            });

            modelBuilder.Entity<VideoCard>().HasData(
           new VideoCard
           {
               Id = 1,
               DeviceId = 11,
               Brand = "Quadro NVS290",
               RamSizeGb = 1,
               SerialNumber = "Unknown",
               Destroyed = false,
               Notes = "Low Profile",
           },
           new VideoCard
           {
               Id = 2,
               DeviceId = 12,
               Brand = "Quadro NVS290",
               RamSizeGb = 1,
               SerialNumber = "Unknown",
               Destroyed = false,
               Notes = "Low Profile",
           },
           new VideoCard
           {
               Id = 3,
               DeviceId = 13,
               Brand = "Quadro 600",
               RamSizeGb = 1,
               SerialNumber = "Unknown",
               Destroyed = true,
               Notes = "128 bit",
           },
           new VideoCard
           {
               Id = 4,
               DeviceId = 14,
               Brand = "Quadro 600",
               RamSizeGb = 1,
               SerialNumber = "Unknown",
               Destroyed = true,
               Notes = "128 bit",
           },
           new VideoCard
           {
               Id = 5,
               DeviceId = 15,
               Brand = "Quadro NVS290",
               RamSizeGb = 1,
               SerialNumber = "Unknown",
               Destroyed = false,
               Notes = "Low Profile",
           },
           new VideoCard
           {
               Id = 6,
               DeviceId = 16,
               Brand = "PNY Quadro NVS600",
               RamSizeGb = 1,
               SerialNumber = "Unknown",
               Destroyed = false,
               Notes = "Low Profile",
           }
           //new VideoCard
           //{
           //    Id = ,  //int PK
           //    DeviceId = ,  //int FK
           //    Brand = ,  //varchar(20) (nullable)
           //    RamSizeGb = ,  //int(11)
           //    SerialNumber = ,  //varchar(30)
           //    Destroyed = ,  //bool
           //    Notes = "",  //text (nullable)
           //}
           );

            modelBuilder.Entity<Warranty>(entity =>
            {
                entity.ToTable("warranty");

                entity.HasIndex(e => e.DeviceId, "warranty_ibfk_1");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.DeviceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Device ID");

                entity.Property(e => e.LengthOfWarranty)
                    .HasMaxLength(15)
                    .HasColumnName("Length of Warranty");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.TypeOfWarranty)
                    .HasMaxLength(100)
                    .HasColumnName("Type of Warranty");

                entity.Property(e => e.WarrantyExpiryDate).HasColumnName("Warranty Expiry Date");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.Warranties)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("warranty_ibfk_1");
            });

            modelBuilder.Entity<Warranty>().HasData(
            new Warranty
            {
                Id = 1,
                DeviceId = 1,
                TypeOfWarranty = "Next Buisness Day",
                LengthOfWarranty = "3 Years",
                Notes = "NA",
            },
            new Warranty
            {
                Id = 2,
                DeviceId = 9,
                TypeOfWarranty = "Pro Support for IT & NDB On-site",
                LengthOfWarranty = "3 Year",
                Notes = "NA",
            },
            new Warranty
            {
                Id = 3,
                DeviceId = 10,
                TypeOfWarranty = "Limited",
                LengthOfWarranty = "1 Year",
                WarrantyExpiryDate = new DateOnly(2012, 03, 01),
                Notes = "NA",
            },
            new Warranty
            {
                Id = 4,
                DeviceId = 11,
                TypeOfWarranty = "Limited",
                LengthOfWarranty = "3 Year",
                WarrantyExpiryDate = new DateOnly(2014, 11, 01),
                Notes = "NA",
            },
            new Warranty
            {
                Id = 5,
                DeviceId = 12,
                TypeOfWarranty = "Limited",
                LengthOfWarranty = "3 Year",
                WarrantyExpiryDate = new DateOnly(2014, 11, 01),
                Notes = "NA",
            },
            new Warranty
            {
                Id = 6,
                DeviceId = 13,
                TypeOfWarranty = "Limited",
                LengthOfWarranty = "3 Year",
                WarrantyExpiryDate = new DateOnly(2014, 11, 01),
                Notes = "NA",
            },
            new Warranty
            {
                Id = 7,
                DeviceId = 14,
                TypeOfWarranty = "Limited",
                LengthOfWarranty = "3 Year",
                WarrantyExpiryDate = new DateOnly(2014, 11, 01),
                Notes = "NA",
            },
            new Warranty
            {
                Id = 8,
                DeviceId = 15,
                TypeOfWarranty = "Limited",
                LengthOfWarranty = "3 Year",
                WarrantyExpiryDate = new DateOnly(2014, 11, 01),
                Notes = "NA",
            },
            new Warranty
            {
                Id = 9,
                DeviceId = 16,
                TypeOfWarranty = "Limited",
                LengthOfWarranty = "3 Year",
                WarrantyExpiryDate = new DateOnly(2015, 05, 01),
                Notes = "NA",
            }
            //new Warranty
            //{
            //    Id = ,  //int PK
            //    DeviceId = ,  //int FK
            //    TypeOfWarranty = ,  //varchar(100)
            //    LengthOfWarranty = ,  //varchar(15)
            //    WarrantyExpiryDate = new DateOnly(),  //date (nullable)
            //    Notes = "",  //text (nullable)
            //}            
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
