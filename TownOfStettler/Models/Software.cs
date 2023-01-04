using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TownOfStettler.Models
{
    public partial class Software
    {
        public Software()
        {
            InstalledSoftwares = new HashSet<InstalledSoftware>();
        }

        public int Id { get; set; }
        public string? ProductKey { get; set; }
        public string SoftwareName { get; set; } = null!;
        public string? AssociatedAccount { get; set; }
        public bool? Subscription { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly? SubscriptionEndDate { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly? PurchaseDate { get; set; }
        public decimal? PurchasePrice { get; set; }
        public int? DevicesAllowed { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateOnly? EndOfSupportDate { get; set; }
        public string? Notes { get; set; }

        public virtual ICollection<InstalledSoftware> InstalledSoftwares { get; set; }

        [NotMapped]
        public string SubEndDate
        {
            get
            {
                if (SubscriptionEndDate == null)
                {
                    return "";
                }
                else
                {
                    return (SubscriptionEndDate?.ToString("yyyy-MM-dd"));
                }

            }
        }

        [NotMapped]
        public string PurchDate
        {
            get
            {                
                {
                    return (PurchaseDate?.ToString("yyyy-MM-dd"));
                }

                //if (PurchaseDate == null)
                //{
                //    return "";
                //}
                //else

            }
        }

        [NotMapped]
        public string EndOfSupport
        {
            get
            {
                if (EndOfSupportDate == null)
                {
                    return "";
                }
                else
                {
                    return (EndOfSupportDate?.ToString("yyyy-MM-dd"));
                }

            }
        }

    }
}
