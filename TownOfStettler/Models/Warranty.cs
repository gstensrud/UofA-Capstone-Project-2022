using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TownOfStettler.Data;

namespace TownOfStettler.Models
{
    public partial class Warranty
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string TypeOfWarranty { get; set; } = null!;
        public string LengthOfWarranty { get; set; } = null!;
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly? WarrantyExpiryDate { get; set; } = null!;
        public string? Notes { get; set; }

        public virtual DeviceInformation Device { get; set; } = null!;

        [NotMapped]
        public string WarrentyExpired
        {
            get
            {
                return (WarrantyExpiryDate?.ToString("yyyy-MM-dd"));

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

    }
}
