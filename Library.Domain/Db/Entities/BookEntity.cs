namespace Library.Domain.Db.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AuthorEntity Author { get; set; }
    }
}
