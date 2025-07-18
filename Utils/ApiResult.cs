namespace UserManager.Utils
{
    public class ApiResult<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }=string.Empty;
        public T? Data { get; set; }

    }
    public class ApiResult : ApiResult<Object> { }
}
