namespace Library.Domain.Db.Entities
{
    public class AuthorEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<BookEntity> Books { get; set; }

        public AuthorEntity()
        {
            Books = new List<BookEntity>();
        }
    }
}
