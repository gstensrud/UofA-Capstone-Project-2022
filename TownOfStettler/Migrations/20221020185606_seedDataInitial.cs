using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TownOfStettler.Migrations
{
    public partial class seedDataInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "hardware device",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TypeofHardware = table.Column<string>(name: "Type of Hardware", type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hardware device", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "owner/location",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(75)", maxLength: 75, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(name: "Phone Number", type: "varchar(14)", maxLength: 14, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notes = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner/location", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "software",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(50)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductKey = table.Column<string>(name: "Product Key", type: "varchar(60)", maxLength: 60, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SoftwareName = table.Column<string>(name: "Software Name", type: "varchar(75)", maxLength: 75, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AssociatedAccount = table.Column<string>(name: "Associated Account", type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Subscription = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    SubscriptionEndDate = table.Column<DateOnly>(name: "Subscription End Date", type: "date", nullable: true),
                    PurchaseDate = table.Column<DateOnly>(name: "Purchase Date", type: "date", nullable: true),
                    PurchasePrice = table.Column<decimal>(name: "Purchase Price", type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    DevicesAllowed = table.Column<int>(name: "Devices Allowed", type: "int(11)", nullable: true),
                    EndofSupportDate = table.Column<DateOnly>(name: "End of Support Date", type: "date", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_software", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "device information",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeviceTypeID = table.Column<int>(name: "Device Type ID", type: "int(11)", nullable: false),
                    OwnerLocation = table.Column<int>(name: "Owner/Location", type: "int(11)", nullable: false),
                    TOSNumber = table.Column<string>(name: "TOS Number", type: "varchar(25)", maxLength: 25, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SerialNumber = table.Column<string>(name: "Serial Number", type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModelNumber = table.Column<string>(name: "Model Number", type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PowerSupply = table.Column<string>(name: "Power Supply", type: "varchar(75)", maxLength: 75, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PurchaseStore = table.Column<string>(name: "Purchase Store", type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PurchasePrice = table.Column<decimal>(name: "Purchase Price", type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    PurchaseDate = table.Column<DateOnly>(name: "Purchase Date", type: "date", nullable: false),
                    OperatingSystem = table.Column<string>(name: "Operating System", type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destroyed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_device information", x => x.ID);
                    table.ForeignKey(
                        name: "device information_ibfk_1",
                        column: x => x.DeviceTypeID,
                        principalTable: "hardware device",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "device information_ibfk_2",
                        column: x => x.OwnerLocation,
                        principalTable: "owner/location",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "ethernet/network",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeviceID = table.Column<int>(name: "Device ID", type: "int(11)", nullable: false),
                    Speed = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Wireless = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Bluetooth = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SerialNumber = table.Column<string>(name: "Serial Number", type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destroyed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ethernet/network", x => x.ID);
                    table.ForeignKey(
                        name: "ethernet/network_ibfk_1",
                        column: x => x.DeviceID,
                        principalTable: "device information",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "hard drive",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeviceID = table.Column<int>(name: "Device ID", type: "int(11)", nullable: false),
                    Type = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SizeGb = table.Column<int>(name: "Size (Gb)", type: "int(7)", nullable: false),
                    SerialNumber = table.Column<string>(name: "Serial Number", type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destroyed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hard drive", x => x.ID);
                    table.ForeignKey(
                        name: "hard drive_ibfk_1",
                        column: x => x.DeviceID,
                        principalTable: "device information",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "installed software",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeviceID = table.Column<int>(name: "Device ID", type: "int(11)", nullable: false),
                    SoftwareID = table.Column<int>(name: "Software ID", type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_installed software", x => x.ID);
                    table.ForeignKey(
                        name: "installed software_ibfk_1",
                        column: x => x.DeviceID,
                        principalTable: "device information",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "installed software_ibfk_2",
                        column: x => x.SoftwareID,
                        principalTable: "software",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "processor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeviceID = table.Column<int>(name: "Device ID", type: "int(11)", nullable: false),
                    Type = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpeedGHz = table.Column<decimal>(name: "Speed (GHz)", type: "decimal(5,3)", precision: 5, scale: 3, nullable: false),
                    SerialNumber = table.Column<string>(name: "Serial Number", type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Generation = table.Column<int>(type: "int(11)", nullable: true),
                    CoreCount = table.Column<int>(name: "Core Count", type: "int(11)", nullable: true),
                    Destroyed = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_processor", x => x.ID);
                    table.ForeignKey(
                        name: "processor_ibfk_1",
                        column: x => x.DeviceID,
                        principalTable: "device information",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "ram",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeviceID = table.Column<int>(name: "Device ID", type: "int(11)", nullable: false),
                    Type = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SizeGb = table.Column<int>(name: "Size (Gb)", type: "int(11)", nullable: false),
                    SpeedMHz = table.Column<int>(name: "Speed (MHz)", type: "int(5)", nullable: true),
                    SerialNumber = table.Column<string>(name: "Serial Number", type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destroyed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ram", x => x.ID);
                    table.ForeignKey(
                        name: "ram_ibfk_1",
                        column: x => x.DeviceID,
                        principalTable: "device information",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "miscellaneous drives",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeviceID = table.Column<int>(name: "Device ID", type: "int(11)", nullable: false),
                    Type = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Removable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SerialNumber = table.Column<string>(name: "Serial Number", type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destroyed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_miscellaneous drives", x => x.ID);
                    table.ForeignKey(
                        name: "miscellaneous drives_ibfk_1",
                        column: x => x.DeviceID,
                        principalTable: "device information",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "sound card",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeviceID = table.Column<int>(name: "Device ID", type: "int(11)", nullable: false),
                    Brand = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destroyed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sound card", x => x.ID);
                    table.ForeignKey(
                        name: "sound card_ibfk_1",
                        column: x => x.DeviceID,
                        principalTable: "device information",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "video card",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeviceID = table.Column<int>(name: "Device ID", type: "int(11)", nullable: false),
                    Brand = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RamSizeGB = table.Column<int>(name: "Ram Size (GB)", type: "int(11)", nullable: false),
                    SerialNumber = table.Column<string>(name: "Serial Number", type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destroyed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_video card", x => x.ID);
                    table.ForeignKey(
                        name: "video card_ibfk_1",
                        column: x => x.DeviceID,
                        principalTable: "device information",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "warranty",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeviceID = table.Column<int>(name: "Device ID", type: "int(11)", nullable: false),
                    TypeofWarranty = table.Column<string>(name: "Type of Warranty", type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LengthofWarranty = table.Column<string>(name: "Length of Warranty", type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WarrantyExpiryDate = table.Column<DateOnly>(name: "Warranty Expiry Date", type: "date", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warranty", x => x.ID);
                    table.ForeignKey(
                        name: "warranty_ibfk_1",
                        column: x => x.DeviceID,
                        principalTable: "device information",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "modifications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProcessorID = table.Column<int>(name: "Processor ID", type: "int(11)", nullable: true),
                    RAMID = table.Column<int>(name: "RAM ID", type: "int(11)", nullable: true),
                    HardDriveID = table.Column<int>(name: "Hard Drive ID", type: "int(11)", nullable: true),
                    MiscellaneousDriveID = table.Column<int>(name: "Miscellaneous Drive ID", type: "int(11)", nullable: true),
                    SoundCardID = table.Column<int>(name: "Sound Card ID", type: "int(11)", nullable: true),
                    VideoCardID = table.Column<int>(name: "Video Card ID", type: "int(11)", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modifications", x => x.ID);
                    table.ForeignKey(
                        name: "modifications_ibfk_1",
                        column: x => x.HardDriveID,
                        principalTable: "hard drive",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "modifications_ibfk_2",
                        column: x => x.ProcessorID,
                        principalTable: "processor",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "modifications_ibfk_3",
                        column: x => x.RAMID,
                        principalTable: "ram",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "modifications_ibfk_4",
                        column: x => x.MiscellaneousDriveID,
                        principalTable: "miscellaneous drives",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "modifications_ibfk_5",
                        column: x => x.SoundCardID,
                        principalTable: "sound card",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "modifications_ibfk_6",
                        column: x => x.VideoCardID,
                        principalTable: "video card",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "outputs",
                columns: table => new
                {
                    Type = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VideoCardID = table.Column<int>(name: "Video Card ID", type: "int(11)", nullable: false),
                    NumberofOutputs = table.Column<int>(name: "Number of Outputs", type: "int(2)", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Type);
                    table.ForeignKey(
                        name: "outputs_ibfk_1",
                        column: x => x.VideoCardID,
                        principalTable: "video card",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "history",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeviceTypeID = table.Column<int>(name: "Device Type ID", type: "int(11)", nullable: false),
                    DeviceID = table.Column<int>(name: "Device ID", type: "int(11)", nullable: true),
                    PartsChanged = table.Column<int>(name: "Parts Changed", type: "int(11)", nullable: true),
                    PastOwners = table.Column<int>(name: "Past Owner(s)", type: "int(11)", nullable: true),
                    Wiped = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PartsRemoved = table.Column<int>(name: "Parts Removed", type: "int(11)", nullable: true),
                    DateofChanges = table.Column<DateOnly>(name: "Date of Changes", type: "date", nullable: false),
                    OutofServiceDate = table.Column<DateOnly>(name: "Out of Service Date", type: "date", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_history", x => x.ID);
                    table.ForeignKey(
                        name: "history_ibfk_1",
                        column: x => x.DeviceID,
                        principalTable: "device information",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "history_ibfk_2",
                        column: x => x.PastOwners,
                        principalTable: "owner/location",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "history_ibfk_3",
                        column: x => x.PartsChanged,
                        principalTable: "modifications",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "history_ibfk_4",
                        column: x => x.DeviceTypeID,
                        principalTable: "hardware device",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "display monitors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TOSNumber = table.Column<string>(name: "TOS Number", type: "varchar(25)", maxLength: 25, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ViewSizeInches = table.Column<decimal>(name: "View Size (Inches)", type: "decimal(3,2)", precision: 3, scale: 2, nullable: false),
                    ViewType = table.Column<string>(name: "View Type", type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Resolution = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RefreshRateHz = table.Column<int>(name: "Refresh Rate (Hz)", type: "int(3)", nullable: true),
                    SerialNumber = table.Column<string>(name: "Serial Number", type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OutputType = table.Column<string>(name: "Output Type", type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumberofOutputs = table.Column<int>(name: "Number of Outputs", type: "int(11)", nullable: true),
                    History = table.Column<int>(type: "int(11)", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_display monitors", x => x.ID);
                    table.ForeignKey(
                        name: "display monitors_ibfk_2",
                        column: x => x.History,
                        principalTable: "history",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "other hardware",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OwnerLocation = table.Column<int>(name: "Owner/Location", type: "int(11)", nullable: false),
                    TOSNumber = table.Column<string>(name: "TOS Number", type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeOfDevice = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destroyed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    History = table.Column<int>(type: "int(11)", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_other hardware", x => x.ID);
                    table.ForeignKey(
                        name: "other hardware_ibfk_1",
                        column: x => x.OwnerLocation,
                        principalTable: "owner/location",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "other hardware_ibfk_2",
                        column: x => x.History,
                        principalTable: "history",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "parts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OriginalDeviceID = table.Column<int>(name: "Original Device ID", type: "int(11)", nullable: false),
                    DeviceHistoryID = table.Column<int>(name: "Device History ID", type: "int(11)", nullable: false),
                    RAMID = table.Column<int>(name: "RAM ID", type: "int(11)", nullable: true),
                    HardDriveID = table.Column<int>(name: "Hard Drive ID", type: "int(11)", nullable: true),
                    MiscellaneousDriveID = table.Column<int>(name: "Miscellaneous Drive ID", type: "int(11)", nullable: true),
                    VideoCardID = table.Column<int>(name: "Video Card ID", type: "int(11)", nullable: true),
                    SoundCardID = table.Column<int>(name: "Sound Card ID", type: "int(11)", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parts", x => x.ID);
                    table.ForeignKey(
                        name: "parts_ibfk_2",
                        column: x => x.HardDriveID,
                        principalTable: "hard drive",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "parts_ibfk_3",
                        column: x => x.RAMID,
                        principalTable: "ram",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "parts_ibfk_4",
                        column: x => x.MiscellaneousDriveID,
                        principalTable: "miscellaneous drives",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "parts_ibfk_5",
                        column: x => x.SoundCardID,
                        principalTable: "sound card",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "parts_ibfk_6",
                        column: x => x.VideoCardID,
                        principalTable: "video card",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "parts_ibfk_7",
                        column: x => x.DeviceHistoryID,
                        principalTable: "history",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "parts_ibfk_8",
                        column: x => x.OriginalDeviceID,
                        principalTable: "device information",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "printers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TOSNumber = table.Column<string>(name: "TOS Number", type: "varchar(25)", maxLength: 25, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OwnerLocation = table.Column<int>(name: "Owner/Location", type: "int(11)", nullable: false),
                    DeviceID = table.Column<int>(name: "Device ID", type: "int(11)", nullable: true),
                    Type = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConnectionType = table.Column<string>(name: "Connection Type", type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    History = table.Column<int>(type: "int(11)", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_printers", x => x.ID);
                    table.ForeignKey(
                        name: "printers_ibfk_1",
                        column: x => x.DeviceID,
                        principalTable: "device information",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "printers_ibfk_2",
                        column: x => x.OwnerLocation,
                        principalTable: "owner/location",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "printers_ibfk_3",
                        column: x => x.History,
                        principalTable: "history",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "inuse monitors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeviceID = table.Column<int>(name: "Device ID", type: "int(11)", nullable: false),
                    MonitorID = table.Column<int>(name: "Monitor ID", type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inuse monitors", x => x.ID);
                    table.ForeignKey(
                        name: "inuse monitors_ibfk_1",
                        column: x => x.DeviceID,
                        principalTable: "device information",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "inuse monitors_ibfk_2",
                        column: x => x.MonitorID,
                        principalTable: "display monitors",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.InsertData(
                table: "display monitors",
                columns: new[] { "ID", "History", "Notes", "Number of Outputs", "Output Type", "Refresh Rate (Hz)", "Resolution", "Serial Number", "TOS Number", "View Size (Inches)", "View Type" },
                values: new object[,]
                {
                    { 1, null, "WXGA Anti Glare", 1, "Unknown", 0, "NA", "unknown", "unknown", 15.4m, "LCD " },
                    { 2, null, "NA", null, null, null, null, "unknown", "unknown", 17.0m, "monitor" },
                    { 3, null, "NA", null, null, 0, "1366 x 768", "unknown", "unknown", 15.6m, "LED" },
                    { 4, null, "NA", null, null, null, "2048x1536", "unknown", "unknown", 9.7m, "Retina" }
                });

            migrationBuilder.InsertData(
                table: "hardware device",
                columns: new[] { "ID", "Type of Hardware" },
                values: new object[,]
                {
                    { 1, "Server" },
                    { 2, "Desktop" },
                    { 3, "Laptop" },
                    { 4, "Monitor" },
                    { 5, "Printer" },
                    { 6, "Misc. Devices" }
                });

            migrationBuilder.InsertData(
                table: "owner/location",
                columns: new[] { "ID", "Address", "Name", "Notes", "Phone Number" },
                values: new object[,]
                {
                    { 1, "Fire Hall", "Fire Hall", "Not Used", null },
                    { 2, "unknown", "unknown", "Wiped", null },
                    { 3, "Unknown", "Disposed", "Disposed ", null },
                    { 4, "Unknown", "STAPP", "NA ", null },
                    { 5, "Unknown", "Graham", "NA", null },
                    { 6, "Unknown", "Water Resivoir", "NA", null },
                    { 7, "unknown", "TOSDC1", "NA", null },
                    { 8, "unknown", "Downstairs", "NA", null },
                    { 9, "unknown", "Ivan", "NA", null }
                });

            migrationBuilder.InsertData(
                table: "software",
                columns: new[] { "ID", "Associated Account", "Devices Allowed", "End of Support Date", "Notes", "Product Key", "Purchase Date", "Purchase Price", "Software Name", "Subscription", "Subscription End Date" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "unknown", null, null, "Windows 2003 Server - Standard", null, null },
                    { 2, null, null, null, null, "Unknown", null, null, "Microsoft Excel 2007", null, null },
                    { 3, null, null, null, null, "unknown", null, null, "Microsoft Office 2007 Small Buisness", null, null },
                    { 4, null, null, null, null, "unknown", null, null, "5 Terminal Server CALS", null, null },
                    { 5, null, null, null, null, "unknown", null, null, "Veritas Backup Exec", null, null },
                    { 6, null, null, null, null, "unknown", null, null, "Windows 7 Pro 64 bit", null, null },
                    { 7, null, null, null, null, "unknown", null, null, "Microsoft Office Pro 2010", null, null },
                    { 8, null, null, null, null, "Unknonw", null, null, "Microsoft Office Pro 2007", null, null },
                    { 9, null, null, null, null, "unknown", null, null, "Windows 2008 Small Business Server Standard w/5 CAL", null, null },
                    { 10, null, null, null, null, "unknown", null, null, "Microsoft Small Business Server 2008 Std 20 User CAL", null, null },
                    { 11, null, null, null, null, "unknown", null, null, "Microsoft Office 2010 Home & Business", null, null }
                });

            migrationBuilder.InsertData(
                table: "device information",
                columns: new[] { "ID", "Destroyed", "Device Type ID", "Model Number", "Notes", "Operating System", "Owner/Location", "Power Supply", "Purchase Date", "Purchase Price", "Purchase Store", "Serial Number", "TOS Number" },
                values: new object[,]
                {
                    { 1, false, 1, "NA", "Dell Poweredge 840 Dual Core Xeon 2.13 Ghz", "Windows 2003 Server - Standard", 1, null, new DateOnly(2007, 5, 1), 3594.00m, "NA", "NA", " TOS0705C" },
                    { 2, false, 2, "NA", "Dell Dimension E520/EQT5131", "unknown", 2, null, new DateOnly(2007, 3, 1), 1.00m, "NA", "NA", "TOSO703AA" },
                    { 3, false, 1, "NA", "Dell Poweredge 2900/EQT5134/Spare", "Windows 2008 Server w/Downgrade Windows Server 2003 SP2 32 bit X64", 4, "Redundant Power Supply", new DateOnly(2008, 5, 1), 7085.00m, "NA", "NA", "TOS0805D" },
                    { 4, true, 3, "unknown", "Dell Vostro 1520 Celeron 575/EQT5136/Disposed in 2018", "Windows Vista Buisness", 3, "6 Cell Lithium Ion Battery", new DateOnly(2009, 7, 1), 964.00m, "unknown", "unknown", "TOSL0907B" },
                    { 5, true, 3, "unknown", "Dell Vostro 1520 Celeron 575/EQT5136/Disposed in 2018", "Windows Vista Buisness", 3, "6 Cell Lithium Ion Battery", new DateOnly(2009, 7, 1), 964.00m, "unknown", "unknown", "TOSL0907C" },
                    { 6, true, 3, "unknown", "Dell Vostro 1520 Celeron 575/EQT5136/Disposed in 2018", "Windows Vista Buisness", 3, "6 Cell Lithium Ion Battery", new DateOnly(2009, 7, 1), 964.00m, "unknown", "unknown", "TOSL0907E" },
                    { 7, false, 2, "unknown", "EQT5145/Motherboard-ASUS P6T6 WS Revolution X58 ATX", "Windows 7 Pro 64 bit", 5, null, new DateOnly(2009, 12, 1), 1.00m, "unknown", "unknown", "TOS0912" },
                    { 8, false, 3, "unknown", "TOSL1005B/Dell Precision M6400", "Windows 7 pro", 6, "Battery", new DateOnly(2010, 6, 15), 1.00m, "unknown", "unknown", "TOSL1004" },
                    { 9, false, 1, "unknown", "Spare/EQT5148/Dell Poweredge R710/VMWare Server/8M Cache/Turbo/HT/1066MHz Max Mem/1333 MHZ Dual Ranked RDIMMs/iDRAC6 Enterprise/Ultra 320 SCSI PCI3 Host Adapter", "Windows 2008 Small Business SErver Standard w/5 CAL", 7, "Redundant 570 Watt", new DateOnly(2010, 2, 1), 15000.00m, "unknown", "unknown", "TOS" },
                    { 10, false, 3, "unknown", "HP ProBook 6500B WX303UT/EQT5153", "Windows 7 Pro 64 Bit", 8, "Battery", new DateOnly(2011, 3, 1), 1300.00m, "unknown", "CNU1080527", "TOSL1103" },
                    { 11, true, 3, "unknown", "EQT5153/Touch Intel P-Series/Speakers/Mouse/Keyboard", "Windows 7 PRo 64 Bit", 3, "Battery", new DateOnly(2011, 11, 1), 1730.00m, "unknown", "unknown", "TOS1111C" },
                    { 12, true, 3, "unknown", "EQT5153/Touch Intel P-Series/Speakers/Mouse/Keyboard", "Windows 7 PRo 64 Bit", 3, "Battery", new DateOnly(2011, 11, 1), 1730.00m, "unknown", "unknown", "TOS1111D" },
                    { 13, true, 3, "V1116390", "EQT5153/Touch Intel P-Series/Speakers/Mouse/Keyboard", "Windows 7 PRo 64 Bit", 3, "Battery", new DateOnly(2011, 11, 1), 1843.00m, "unknown", "124973", "TOS1111B" },
                    { 14, true, 3, "V1116391", "EQT5153/Touch Intel P-Series/Speakers/Mouse/Keyboard", "Windows 7 PRo 64 Bit", 3, "Battery", new DateOnly(2011, 11, 1), 1627.00m, "unknown", "124974", "TOS1111A" },
                    { 15, false, 3, "V1116380", "EQT5153/Touch Intel P-Series/Speakers/Mouse/Keyboard", "Windows 7 Pro 64 Bit", 1, null, new DateOnly(2011, 11, 1), 1726.00m, "unknown", "124975", "TOS1111E" },
                    { 16, false, 3, "V1210920", "EQT5160/Touch Intel P-Series/Mouse/Keyboard", "Windows 7 Pro 64 Bit", 8, null, new DateOnly(2011, 11, 1), 1703.00m, "unknown", "125409", "TOS1205" },
                    { 17, false, 6, "unknown", "EQT5160/Apple iPad3 w/wifi/Black/Front&Rear Cameras/Smart Cover&Logitech wireless keyboard w/stand", "iOS", 9, null, new DateOnly(2012, 10, 1), 710.00m, "unknown", "unknown", "TOS1210" }
                });

            migrationBuilder.InsertData(
                table: "other hardware",
                columns: new[] { "ID", "Destroyed", "History", "Notes", "Owner/Location", "TOS Number", "TypeOfDevice" },
                values: new object[,]
                {
                    { 1, false, null, "NA", 1, "unknown", "Keyboard" },
                    { 2, false, null, "NA", 1, "unknown", "Mouse" },
                    { 3, false, null, "NA", 1, "unknown", "Network Switch" }
                });

            migrationBuilder.InsertData(
                table: "ethernet/network",
                columns: new[] { "ID", "Bluetooth", "Destroyed", "Device ID", "Notes", "Serial Number", "Speed", "Wireless" },
                values: new object[,]
                {
                    { 1, false, false, 3, "NA", "unknown", "1000", false },
                    { 2, false, false, 3, "NA", "unknown", "1000", false },
                    { 3, false, false, 9, "Broadcom NetXtreme II 5709 Gigabit Ethernet NIC", "unknown", "", false },
                    { 4, true, false, 10, "NA", "Unknown", "10/100/1000 LAN", true },
                    { 5, true, true, 11, "NA", "Unknown", "10/100/1000 LAN", true },
                    { 6, true, true, 12, "NA", "Unknown", "10/100/1000 LAN", true },
                    { 7, true, true, 13, "NA", "Unknown", "10/100/1000 LAN", true },
                    { 8, true, true, 14, "NA", "Unknown", "10/100/1000 LAN", true },
                    { 9, true, false, 15, "NA", "Unknown", "10/100/1000 LAN", true },
                    { 10, true, false, 16, "NA", "Unknown", "10/100/1000 LAN", true }
                });

            migrationBuilder.InsertData(
                table: "hard drive",
                columns: new[] { "ID", "Destroyed", "Device ID", "Notes", "Serial Number", "Size (Gb)", "Type" },
                values: new object[,]
                {
                    { 1, false, 1, "NA", "unknown", 160, "Unknown" },
                    { 2, false, 1, "NA", "unknown", 160, "Raid" },
                    { 3, false, 3, "OS", "unknown", 73, "Hot Swap" },
                    { 4, false, 3, "OS", "unknown", 73, "Hot Swap" },
                    { 5, false, 3, "Data   15K RPM", "unknown", 300, "Hot Swap" },
                    { 6, false, 3, "Data   15K RPM", "unknown", 300, "Hot Swap" },
                    { 7, false, 3, "Data   15K RPM", "unknown", 300, "Hot Swap" },
                    { 8, true, 4, "5400rpm/", "unknown", 160, "SATA" },
                    { 9, true, 5, "5400rpm/", "unknown", 160, "SATA" },
                    { 10, true, 6, "5400rpm/", "unknown", 160, "SATA" },
                    { 11, false, 7, "7200rpm/", "unknown", 1000, "SATA" },
                    { 12, false, 7, "Digital VelociRaptor 10000", "unknown", 300, "SATA 2" },
                    { 13, false, 8, "NA", "unknown", 150, "unknown" },
                    { 14, false, 9, "7200rpm/Near Line SAS 3.5'' Hot Plug", "unknown", 500, "RAID" },
                    { 15, false, 9, "7200rpm/Near Line SAS 3.5'' Hot Plug", "unknown", 500, "RAID" },
                    { 16, false, 9, "7200rpm/Near Line SAS 3.5'' Hot Plug", "unknown", 500, "RAID" },
                    { 17, false, 9, "7200rpm/Near Line SAS 3.5'' Hot Plug", "unknown", 500, "RAID" },
                    { 18, false, 10, "7200rpm", "unknown", 320, "SATA II" },
                    { 19, true, 11, "NA", "Unknown", 250, "SATA" },
                    { 20, true, 12, "NA", "Unknown", 250, "SATA" },
                    { 21, true, 13, "NA", "Unknown", 300, "SATA" },
                    { 22, true, 14, "NA", "Unknown", 300, "SATA" },
                    { 23, false, 15, "NA", "Unknown", 250, "SATA" },
                    { 24, false, 16, "NA", "Unknown", 320, "SATA" },
                    { 25, false, 17, "NA", "unknown", 16, "Apple" }
                });

            migrationBuilder.InsertData(
                table: "history",
                columns: new[] { "ID", "Date of Changes", "Device ID", "Device Type ID", "Notes", "Out of Service Date", "Parts Changed", "Parts Removed", "Past Owner(s)", "Wiped" },
                values: new object[,]
                {
                    { 1, new DateOnly(1, 1, 1), 2, 2, "Dell Dimension E520", null, null, null, null, true },
                    { 2, new DateOnly(1, 1, 1), 4, 3, "NA", new DateOnly(2018, 7, 1), null, null, null, null },
                    { 3, new DateOnly(1, 1, 1), 5, 3, "NA", new DateOnly(2018, 7, 1), null, null, null, null },
                    { 4, new DateOnly(1, 1, 1), 6, 3, "NA", new DateOnly(2018, 7, 1), null, null, null, null },
                    { 5, new DateOnly(1, 1, 1), 10, 3, "NA", null, null, null, null, true },
                    { 6, new DateOnly(1, 1, 1), 11, 3, "NA", new DateOnly(2018, 7, 1), null, null, null, null },
                    { 7, new DateOnly(1, 1, 1), 12, 3, "NA", new DateOnly(2018, 7, 1), null, null, null, null },
                    { 8, new DateOnly(1, 1, 1), 13, 3, "NA", new DateOnly(2018, 7, 1), null, null, null, null },
                    { 9, new DateOnly(1, 1, 1), 14, 3, "NA", new DateOnly(2018, 7, 1), null, null, null, null },
                    { 10, new DateOnly(1, 1, 1), 16, 3, "NA", null, null, null, null, true }
                });

            migrationBuilder.InsertData(
                table: "installed software",
                columns: new[] { "ID", "Device ID", "Software ID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 4 },
                    { 3, 1, 5 },
                    { 4, 3, 1 },
                    { 5, 1, 3 },
                    { 6, 5, 3 },
                    { 7, 6, 3 },
                    { 8, 8, 6 },
                    { 9, 8, 8 },
                    { 10, 9, 9 },
                    { 11, 9, 10 },
                    { 12, 10, 6 },
                    { 13, 10, 11 },
                    { 14, 11, 6 },
                    { 15, 11, 11 },
                    { 16, 12, 6 },
                    { 17, 12, 11 },
                    { 18, 13, 6 },
                    { 19, 13, 11 },
                    { 20, 14, 6 },
                    { 21, 14, 11 },
                    { 22, 15, 6 },
                    { 23, 15, 11 },
                    { 24, 16, 6 },
                    { 25, 16, 11 }
                });

            migrationBuilder.InsertData(
                table: "inuse monitors",
                columns: new[] { "ID", "Device ID", "Monitor ID" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 5, 1 },
                    { 3, 6, 1 },
                    { 4, 8, 2 },
                    { 5, 10, 3 },
                    { 6, 17, 4 }
                });

            migrationBuilder.InsertData(
                table: "processor",
                columns: new[] { "ID", "Core Count", "Destroyed", "Device ID", "Generation", "Notes", "Serial Number", "Speed (GHz)", "Type" },
                values: new object[,]
                {
                    { 1, 4, false, 1, null, "NA", "unknown", 2.13m, "Intel Xeon" },
                    { 2, 4, false, 3, null, "2 Processors in this unit.  E54302x6MB Cache, 1333MHz FSB", "unknown", 2.66m, "Intel Xeon" },
                    { 3, null, false, 7, null, null, "unknown", 2.67m, "Intel i7" },
                    { 4, null, false, 8, null, "Core 2 Duo P8700", "unknown", 2.53m, "Intel" },
                    { 5, null, false, 9, null, "E5530/", "unknown", 2.4m, " Intel Xeon" },
                    { 6, null, false, 10, null, "i5 460M, 3MB L3 Cache", "unknown", 2.53m, "Intel i5" },
                    { 7, null, true, 11, null, "1155 8M Box", "Unknown", 3.10m, "Intel Q/Xeon" },
                    { 8, null, true, 12, null, "1155 8M Box", "Unknown", 3.10m, "Intel Q/Xeon" },
                    { 9, null, true, 13, null, "1155 8M Box", "Unknown", 3.10m, "Intel Q/Xeon" },
                    { 10, null, true, 14, null, "1155 8M Box", "Unknown", 3.10m, "Intel Q/Xeon" },
                    { 11, null, false, 15, null, "1155 8M Box", "Unknown", 3.10m, "Intel Q/Xeon" },
                    { 12, null, false, 16, null, "1155 8M Box", "Unknown", 3.10m, "Intel Q/Xeon" }
                });

            migrationBuilder.InsertData(
                table: "ram",
                columns: new[] { "ID", "Destroyed", "Device ID", "Notes", "Serial Number", "Size (Gb)", "Speed (MHz)", "Type" },
                values: new object[,]
                {
                    { 1, false, 1, "NA", "unknown", 2, null, "Unknown" },
                    { 2, false, 3, "4 Sticks in this unit", "unknown", 1, 667, "Unknown" },
                    { 3, true, 4, "NA", "unknown", 3, 800, "DDR2 SD" },
                    { 4, true, 5, "NA", "unknown", 3, 800, "DDR2 SD" },
                    { 5, true, 6, "NA", "unknown", 3, 800, "DDR2 SD" },
                    { 6, false, 7, "1600", "unknown", 6, null, "DDR3" },
                    { 7, false, 8, "NA", "unknown", 4, null, "not listed" },
                    { 8, false, 9, "4 sticks", "unknown", 4, 1333, "not listed" },
                    { 9, false, 10, "NA", "unknown", 4, 1333, "DDR" },
                    { 10, true, 11, "Kingston", "Unknown", 4, null, "DDR3" },
                    { 11, true, 12, "Kingston", "Unknown", 4, null, "DDR3" },
                    { 12, true, 13, "Kingston", "Unknown", 4, null, "DDR3" },
                    { 13, true, 14, "Kingston", "Unknown", 4, null, "DDR3" },
                    { 14, true, 15, "Kingston", "Unknown", 8, null, "DDR3" },
                    { 15, false, 16, "Kingston", "Unknown", 4, null, "DDR3" },
                    { 16, false, 17, "Ram is not 512 GB, its 512 MB...Apple iPad", "unknown", 512, null, "Apple" }
                });

            migrationBuilder.InsertData(
                table: "miscellaneous drives",
                columns: new[] { "ID", "Destroyed", "Device ID", "Notes", "Removable", "Serial Number", "Type" },
                values: new object[,]
                {
                    { 1, false, 1, "NA", true, "unknown", "Not Stated/Backup" },
                    { 2, false, 1, "NA", false, "unknown", "CD-RW" },
                    { 3, true, 4, "NA", false, "unknown", "DVD +/- RW" },
                    { 4, true, 5, "NA", false, "unknown", "DVD +/- RW" },
                    { 5, true, 6, "NA", false, "unknown", "DVD +/- RW" },
                    { 6, false, 9, "LTO3 Backup Drive (TableTop)", true, "unknown", "External" },
                    { 7, false, 10, "Supermulti DL LightScribe", false, "unknown", "DVD +/- RW" },
                    { 8, true, 11, "NA", false, "Unknown", "Card Reader" },
                    { 9, true, 12, "NA", false, "Unknown", "Card Reader" },
                    { 10, true, 13, "NA", false, "Unknown", "Card Reader" },
                    { 11, true, 14, "NA", false, "Unknown", "Card Reader" },
                    { 12, true, 11, "LG", false, "Unknown", "DVD 22x/22x" },
                    { 13, true, 12, "LG", false, "Unknown", "DVD 22x/22x" },
                    { 14, true, 13, "LG", false, "Unknown", "DVD 22x/22x" },
                    { 15, true, 14, "LG", false, "Unknown", "DVD 22x/22x" },
                    { 16, false, 15, "NA", false, "Unknown", "Card Reader" },
                    { 17, false, 15, "LG", false, "Unknown", "DVD 22x/22x" },
                    { 18, false, 16, "NA", false, "Unknown", "Card Reader" },
                    { 19, false, 16, "LG", false, "Unknown", "DVD 22x/22x" }
                });

            migrationBuilder.InsertData(
                table: "video card",
                columns: new[] { "ID", "Brand", "Destroyed", "Device ID", "Notes", "Ram Size (GB)", "Serial Number" },
                values: new object[,]
                {
                    { 1, "Quadro NVS290", false, 11, "Low Profile", 1, "Unknown" },
                    { 2, "Quadro NVS290", false, 12, "Low Profile", 1, "Unknown" },
                    { 3, "Quadro 600", true, 13, "128 bit", 1, "Unknown" },
                    { 4, "Quadro 600", true, 14, "128 bit", 1, "Unknown" },
                    { 5, "Quadro NVS290", false, 15, "Low Profile", 1, "Unknown" },
                    { 6, "PNY Quadro NVS600", false, 16, "Low Profile", 1, "Unknown" }
                });

            migrationBuilder.InsertData(
                table: "warranty",
                columns: new[] { "ID", "Device ID", "Length of Warranty", "Notes", "Type of Warranty", "Warranty Expiry Date" },
                values: new object[,]
                {
                    { 1, 1, "3 Years", "NA", "Next Buisness Day", null },
                    { 2, 9, "3 Year", "NA", "Pro Support for IT & NDB On-site", null },
                    { 3, 10, "1 Year", "NA", "Limited", new DateOnly(2012, 3, 1) },
                    { 4, 11, "3 Year", "NA", "Limited", new DateOnly(2014, 11, 1) },
                    { 5, 12, "3 Year", "NA", "Limited", new DateOnly(2014, 11, 1) },
                    { 6, 13, "3 Year", "NA", "Limited", new DateOnly(2014, 11, 1) },
                    { 7, 14, "3 Year", "NA", "Limited", new DateOnly(2014, 11, 1) },
                    { 8, 15, "3 Year", "NA", "Limited", new DateOnly(2014, 11, 1) },
                    { 9, 16, "3 Year", "NA", "Limited", new DateOnly(2015, 5, 1) }
                });

            migrationBuilder.CreateIndex(
                name: "device information_ibfk_1",
                table: "device information",
                column: "Device Type ID");

            migrationBuilder.CreateIndex(
                name: "device information_ibfk_2",
                table: "device information",
                column: "Owner/Location");

            migrationBuilder.CreateIndex(
                name: "History",
                table: "display monitors",
                column: "History");

            migrationBuilder.CreateIndex(
                name: "ethernet/network_ibfk_1",
                table: "ethernet/network",
                column: "Device ID");

            migrationBuilder.CreateIndex(
                name: "hard drive_ibfk_1",
                table: "hard drive",
                column: "Device ID");

            migrationBuilder.CreateIndex(
                name: "Device Type ID",
                table: "history",
                column: "Device Type ID");

            migrationBuilder.CreateIndex(
                name: "history_ibfk_1",
                table: "history",
                column: "Device ID");

            migrationBuilder.CreateIndex(
                name: "history_ibfk_2",
                table: "history",
                column: "Past Owner(s)");

            migrationBuilder.CreateIndex(
                name: "history_ibfk_3",
                table: "history",
                column: "Parts Changed");

            migrationBuilder.CreateIndex(
                name: "Device ID",
                table: "installed software",
                column: "Device ID");

            migrationBuilder.CreateIndex(
                name: "Software ID",
                table: "installed software",
                column: "Software ID");

            migrationBuilder.CreateIndex(
                name: "Device ID1",
                table: "inuse monitors",
                column: "Device ID");

            migrationBuilder.CreateIndex(
                name: "Monitor ID",
                table: "inuse monitors",
                column: "Monitor ID");

            migrationBuilder.CreateIndex(
                name: "modifications_ibfk_1",
                table: "modifications",
                column: "Hard Drive ID");

            migrationBuilder.CreateIndex(
                name: "modifications_ibfk_2",
                table: "modifications",
                column: "Processor ID");

            migrationBuilder.CreateIndex(
                name: "modifications_ibfk_3",
                table: "modifications",
                column: "RAM ID");

            migrationBuilder.CreateIndex(
                name: "modifications_ibfk_4",
                table: "modifications",
                column: "Miscellaneous Drive ID");

            migrationBuilder.CreateIndex(
                name: "modifications_ibfk_5",
                table: "modifications",
                column: "Sound Card ID");

            migrationBuilder.CreateIndex(
                name: "modifications_ibfk_6",
                table: "modifications",
                column: "Video Card ID");

            migrationBuilder.CreateIndex(
                name: "History1",
                table: "other hardware",
                column: "History");

            migrationBuilder.CreateIndex(
                name: "other hardware_ibfk_1",
                table: "other hardware",
                column: "Owner/Location");

            migrationBuilder.CreateIndex(
                name: "outputs_ibfk_1",
                table: "outputs",
                column: "Video Card ID");

            migrationBuilder.CreateIndex(
                name: "parts_ibfk_2",
                table: "parts",
                column: "Hard Drive ID");

            migrationBuilder.CreateIndex(
                name: "parts_ibfk_3",
                table: "parts",
                column: "RAM ID");

            migrationBuilder.CreateIndex(
                name: "parts_ibfk_4",
                table: "parts",
                column: "Miscellaneous Drive ID");

            migrationBuilder.CreateIndex(
                name: "parts_ibfk_5",
                table: "parts",
                column: "Sound Card ID");

            migrationBuilder.CreateIndex(
                name: "parts_ibfk_6",
                table: "parts",
                column: "Video Card ID");

            migrationBuilder.CreateIndex(
                name: "parts_ibfk_7",
                table: "parts",
                column: "Device History ID");

            migrationBuilder.CreateIndex(
                name: "parts_ibfk_8",
                table: "parts",
                column: "Original Device ID");

            migrationBuilder.CreateIndex(
                name: "History2",
                table: "printers",
                column: "History");

            migrationBuilder.CreateIndex(
                name: "printers_ibfk_1",
                table: "printers",
                column: "Device ID");

            migrationBuilder.CreateIndex(
                name: "printers_ibfk_2",
                table: "printers",
                column: "Owner/Location");

            migrationBuilder.CreateIndex(
                name: "processor_ibfk_1",
                table: "processor",
                column: "Device ID");

            migrationBuilder.CreateIndex(
                name: "ram_ibfk_1",
                table: "ram",
                column: "Device ID");

            migrationBuilder.CreateIndex(
                name: "miscellaneous drives_ibfk_1",
                table: "miscellaneous drives",
                column: "Device ID");

            migrationBuilder.CreateIndex(
                name: "sound card_ibfk_1",
                table: "sound card",
                column: "Device ID");

            migrationBuilder.CreateIndex(
                name: "video card_ibfk_1",
                table: "video card",
                column: "Device ID");

            migrationBuilder.CreateIndex(
                name: "warranty_ibfk_1",
                table: "warranty",
                column: "Device ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ethernet/network");

            migrationBuilder.DropTable(
                name: "installed software");

            migrationBuilder.DropTable(
                name: "inuse monitors");

            migrationBuilder.DropTable(
                name: "other hardware");

            migrationBuilder.DropTable(
                name: "outputs");

            migrationBuilder.DropTable(
                name: "parts");

            migrationBuilder.DropTable(
                name: "printers");

            migrationBuilder.DropTable(
                name: "warranty");

            migrationBuilder.DropTable(
                name: "software");

            migrationBuilder.DropTable(
                name: "display monitors");

            migrationBuilder.DropTable(
                name: "history");

            migrationBuilder.DropTable(
                name: "modifications");

            migrationBuilder.DropTable(
                name: "hard drive");

            migrationBuilder.DropTable(
                name: "processor");

            migrationBuilder.DropTable(
                name: "ram");

            migrationBuilder.DropTable(
                name: "miscellaneous drives");

            migrationBuilder.DropTable(
                name: "sound card");

            migrationBuilder.DropTable(
                name: "video card");

            migrationBuilder.DropTable(
                name: "device information");

            migrationBuilder.DropTable(
                name: "hardware device");

            migrationBuilder.DropTable(
                name: "owner/location");
        }
    }
}
