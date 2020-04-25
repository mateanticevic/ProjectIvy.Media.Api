using System;
using System.Collections.Generic;

namespace ProjectIvy.Media.Core.Models.Database
{
    public partial class Title
    {
        public Title()
        {
            Aka = new HashSet<Aka>();
            InverseParentTitle = new HashSet<Title>();
            TitleGenre = new HashSet<TitleGenre>();
            TitleName = new HashSet<TitleName>();
        }

        public int Id { get; set; }
        public string ValueId { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public bool IsAdult { get; set; }
        public short? StartYear { get; set; }
        public short? EndYear { get; set; }
        public short? Runtime { get; set; }
        public int TitleTypeId { get; set; }
        public short? SeasonNumber { get; set; }
        public int? EpisodeNumber { get; set; }
        public int? NumberOfVotes { get; set; }
        public decimal? AverageRating { get; set; }
        public int? ParentTitleId { get; set; }

        public virtual Title ParentTitle { get; set; }
        public virtual ICollection<Aka> Aka { get; set; }
        public virtual ICollection<Title> InverseParentTitle { get; set; }
        public virtual ICollection<TitleGenre> TitleGenre { get; set; }
        public virtual ICollection<TitleName> TitleName { get; set; }
    }
}
