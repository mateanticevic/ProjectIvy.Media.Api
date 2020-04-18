using System.Collections.Generic;

namespace ProjectIvy.Media.Core.Models.Database
{
    public partial class Title
    {
        public Title()
        {
            TitleNames = new HashSet<TitleName>();
        }

        public int Id { get; set; }
        public string ValueId { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public bool IsAdult { get; set; }
        public short? StartYear { get; set; }
        public short? EndYear { get; set; }
        public short? Runtime { get; set; }
        public string Genres { get; set; }
        public int TitleTypeId { get; set; }
        public short? SeasonNumber { get; set; }
        public int? EpisodeNumber { get; set; }
        public int? ParentTitleId { get; set; }
        public int? NumberOfVotes { get; set; }
        public decimal? AverageRating { get; set; }

        public virtual ICollection<TitleName> TitleNames { get; set; }
    }
}
