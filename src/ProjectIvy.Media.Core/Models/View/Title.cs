namespace ProjectIvy.Media.Core.Models.View
{
    public class Title
    {
        public Title(Database.Title t)
        {
            PrimaryTitle = t.PrimaryTitle;
            Runtime = t.Runtime;
            Rating = t.AverageRating;
        }

        public string PrimaryTitle { get; set; }

        public short? Runtime { get; set; }

        public decimal? Rating { get; set; }
    }
}
