namespace UserManager.Models
{
    public class PagedResult<T>
    {
        public int TotalItems { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<T> Items { get; set; }=new List<T>();
    }
}
