namespace ProjectIvy.Media.Core.Models.Database
{
    public partial class TitleGenre
    {
        public int TitleId { get; set; }
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Title Title { get; set; }
    }
}
