using System.Collections.Generic;

namespace ProjectIvy.Media.Core.Models.Database
{
    public partial class Role
    {
        public Role()
        {
            TitleName = new HashSet<TitleName>();
        }

        public int Id { get; set; }
        public string ValueId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TitleName> TitleName { get; set; }
    }
}
