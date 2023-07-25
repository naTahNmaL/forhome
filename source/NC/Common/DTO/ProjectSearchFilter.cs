using Common.Enums;

namespace Common.DTO
{
    public class PagedProjectSearchFilter : PageRequest
    {
        public string Search { get; set; } = string.Empty;
        public eProjectStatus? Status { get; set; } = default;

        public string SortOrder { get; set; } = "ProjectNumber";
        public bool IsSortAscending { get; set; } = true;

        public string Name { get; set; }
        public string Customer { get; set; }
        public int? Number { get; set; }
    }

    public class PageRequest
    {
        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 5;
    }

}
