namespace ProjectIvy.Media.Core.Models.Database
{
    public partial class TitleName
    {
        public int TitleId { get; set; }
        public int NameId { get; set; }
        public int RoleId { get; set; }
        public int? Ordering { get; set; }
        public string Job { get; set; }
        public string Characters { get; set; }

        public virtual Name Name { get; set; }
        public virtual Role Role { get; set; }
        public virtual Title Title { get; set; }
    }
}
