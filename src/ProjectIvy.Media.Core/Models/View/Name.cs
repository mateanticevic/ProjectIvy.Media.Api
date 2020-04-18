namespace ProjectIvy.Media.Core.Models.View
{
    public class Name
    {
        public Name(Database.Name n)
        {
            Id = n.ValueId;
            PrimaryName = n.PrimaryName;
        }

        public string Id { get; set; }

        public string PrimaryName { get; set; }
    }
}
