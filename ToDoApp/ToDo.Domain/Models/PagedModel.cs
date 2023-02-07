namespace ToDo.Domain.Models
{
    public class PagedModel<T> where T : class
    {
        public IList<T> Entities { get; }
        public int Total { get; }
        public int PageSize { get; }
        public int TotalPages => (int)Math.Ceiling((decimal)Total / PageSize);

        public PagedModel(IList<T> entities, int total, int pageSize)
        {
            Entities = entities;
            Total = total;
            PageSize = pageSize;
        }
    }
}
