using System.ComponentModel.DataAnnotations.Schema;
using TownOfStettler.Data;

//  I have noticed that there is a column missing from this table.  I would add a serial number column to this table that could be null.  Modems, and switches would have a serial number, but keyboards may not
namespace TownOfStettler.Models
{
    public partial class OtherHardware
    {
        public int Id { get; set; }
        public int OwnerLocation { get; set; }
        public string TosNumber { get; set; } = null!;
        public string TypeOfDevice { get; set; } = null!;
        public bool Destroyed { get; set; }
        public int? History { get; set; }
        public string? Notes { get; set; }

        public virtual History? HistoryNavigation { get; set; }
        public virtual OwnerLocation OwnerLocationNavigation { get; set; } = null!;



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
