using System;
using System.Collections.Generic;

namespace ProjectIvy.Media.Core.Models.Database
{
    public partial class Aka
    {
        public int Id { get; set; }
        public int TitleId { get; set; }
        public short Ordering { get; set; }
        public string Title { get; set; }
        public string Types { get; set; }
        public string Attributes { get; set; }
        public bool IsOriginalTitle { get; set; }
        public int LanguageId { get; set; }
        public int? RegionId { get; set; }

        public virtual Title TitleNavigation { get; set; }
    }
}
