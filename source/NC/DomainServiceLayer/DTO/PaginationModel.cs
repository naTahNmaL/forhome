using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceLayer.DTO
{

    public class PagedObjectResult<T>
    {
        public int TotalCount { get; set; }
        public IList<T> Data { get; set; }
    }

    public class PaginationModel<T> : PageModel
    {
        public int Count { get; set; }
        public int PageSize { get; set; } = 5;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public IList<T> Data { get; set; }

    }





}
