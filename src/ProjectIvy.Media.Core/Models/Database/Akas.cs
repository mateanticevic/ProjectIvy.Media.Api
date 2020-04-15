using System;
using System.Collections.Generic;

namespace ProjectIvy.Media.Core.Models.Database
{
    public partial class Akas
    {
        public string TitleId { get; set; }
        public int Ordering { get; set; }
        public string Title { get; set; }
        public string Region { get; set; }
        public string Language { get; set; }
        public string Types { get; set; }
        public string Attributes { get; set; }
        public string IsOriginalTitle { get; set; }
    }
}
