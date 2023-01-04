using System.ComponentModel.DataAnnotations.Schema;
using TownOfStettler.Data;

namespace TownOfStettler.Models
{
    public partial class Output
    {
        public string Type { get; set; } = null!;
        public int VideoCardId { get; set; }
        public int NumberOfOutputs { get; set; }
        public string? Notes { get; set; }

        public virtual VideoCard VideoCard { get; set; } = null!;

        [NotMapped]
        public string VideosIdWithName
        {
            get
            {
                string result = "ID#" + VideoCardId.ToString();
                using (DatabaseContext __dbcntxt = new())
                {
                    result += (" [ " + __dbcntxt.VideoCards.Single(item => (item.Id == VideoCardId)).Brand + " ]");
                }
                return result;
            }
        }


    }
}
