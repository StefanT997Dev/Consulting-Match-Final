namespace Application.Core.Wrappers
{
    public class PagedResult<T>:Result<T>
    {
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public static PagedResult<T> Success(T value,int numberOfPages,int totalRecords) => new PagedResult<T>{IsSuccess=true,Value=value,TotalPages=numberOfPages,TotalRecords=totalRecords};
        public static PagedResult<T> Failure(string error,int numberOfPages,int totalRecords) => new PagedResult<T> {IsSuccess=false,Error=error,TotalPages=numberOfPages,TotalRecords=totalRecords};
    }
}