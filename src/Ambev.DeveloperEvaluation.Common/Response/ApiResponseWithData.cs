namespace Ambev.DeveloperEvaluation.Common.Response
{
    public class ApiResponseWithData<T> : ApiResponse
    {
        public T? Data { get; set; }
    }

}
