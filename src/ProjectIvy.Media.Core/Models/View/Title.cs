using ProjectIvy.Media.Core.Constants.Database;
using System.Collections.Generic;
using System.Linq;

namespace ProjectIvy.Media.Core.Models.View
{
    public class Title
    {
        public Title(Database.Title t)
        {
            PrimaryTitle = t.PrimaryTitle;
            Runtime = t.Runtime;
            Rating = t.AverageRating;
            Cast = t.TitleName.Where(x => IsPartOfCast((RoleId)x.RoleId)).OrderBy(x => x.Ordering).Select(x => new NameRole(new Name(x.Name), new Role(x.Role)));
            Directors = t.TitleName.Where(x => x.RoleId == (int)RoleId.Director).OrderBy(x => x.Ordering).Select(x => new Name(x.Name));
            Writers = t.TitleName.Where(x => x.RoleId == (int)RoleId.Writer).OrderBy(x => x.Ordering).Select(x => new Name(x.Name));
            Episode = t.EpisodeNumber;
            Season = t.SeasonNumber;
            Id = t.ValueId;
        }

        public string Id { get; set; }

        public int? Episode { get; set; }

        public short? Season { get; set; }

        public string PrimaryTitle { get; set; }

        public short? Runtime { get; set; }

        public decimal? Rating { get; set; }

        public IEnumerable<NameRole> Cast { get; set; }

        public IEnumerable<Name> Directors { get; set; }

        public IEnumerable<Name> Writers { get; set; }

        public static bool IsPartOfCast(RoleId roleId) => !(roleId == RoleId.Director || roleId == RoleId.Writer);
    }
}
