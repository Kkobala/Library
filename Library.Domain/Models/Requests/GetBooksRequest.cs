namespace Library.Domain.Models.Requests
{
    public class GetBooksRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
