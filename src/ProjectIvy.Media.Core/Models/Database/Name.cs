using System;
using System.Collections.Generic;

namespace ProjectIvy.Media.Core.Models.Database
{
    public partial class Name
    {
        public Name()
        {
            TitleName = new HashSet<TitleName>();
        }

        public int Id { get; set; }
        public string ValueId { get; set; }
        public string PrimaryName { get; set; }
        public short? BirthYear { get; set; }
        public short? DeathYear { get; set; }

        public virtual ICollection<TitleName> TitleName { get; set; }
    }
}
