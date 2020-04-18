namespace ProjectIvy.Media.Core.Models.View
{
    public class Role
    {
        public Role(Database.Role r)
        {
            Id = r.ValueId;
            Name = r.Name;
        }

        public string Id { get; set; }

        public string Name { get; set; }
    }
}
