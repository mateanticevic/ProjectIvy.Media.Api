namespace ProjectIvy.Media.Core.Models.View
{
    public class NameRole
    {
        public NameRole(Name name, Role role)
        {
            Role = role;
            Name = name;
        }

        public Name Name { get; set; }

        public Role Role { get; set; }
    }
}
