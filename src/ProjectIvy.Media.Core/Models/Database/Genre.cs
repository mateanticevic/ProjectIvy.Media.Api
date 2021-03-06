﻿using System;
using System.Collections.Generic;

namespace ProjectIvy.Media.Core.Models.Database
{
    public partial class Genre
    {
        public Genre()
        {
            TitleGenre = new HashSet<TitleGenre>();
        }

        public int Id { get; set; }
        public string ValueId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TitleGenre> TitleGenre { get; set; }
    }
}
