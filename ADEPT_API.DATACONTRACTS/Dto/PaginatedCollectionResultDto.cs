using System.Collections.Generic;

namespace ADEPT_API.DATACONTRACTS.Dto
{
    public class PaginatedCollectionResultDto<TResult>
    {
        public int CurrentPage { get; set; }

        public int PageCount { get; set; }

        public int TotalCount { get; set; }

        public IEnumerable<TResult> Result { get; set; }
    }
}
