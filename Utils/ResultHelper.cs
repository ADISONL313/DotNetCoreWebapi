namespace UserManager.Utils
{
    //result工具类用于构建对应状态码的返回结果
    public static class ResultHelper
    {
        //请求成功返回正确结果(带有数据)
        public static ApiResult<T> Success<T>(T Data, string message = "成功")
        {
            return new ApiResult<T>
            {
                Code = (int)ResultCode.Success,
                Message = message,
                Data = Data
            };
        }
        //请求失败返回正确结果(带有数据)
        public static ApiResult<T> Failed<T>(string message,T Data=default)
        {
            return new ApiResult<T>
            {
                Code = (int)ResultCode.Failed,
                Message = message,
                Data = Data
            };
        }
        //创建成功结果(无数据)
        public static ApiResult Success(string message = "成功")
        {
            return new ApiResult
            {
                Code = (int)ResultCode.Success,
                Message = message
            };
        }
        // <summary>创建参数错误结果</summary>
        public static ApiResult BadRequest(string message = "失败")
        {
            return new ApiResult
            {
                Code = (int)ResultCode.Failed,
                Message = message
            };
        }
    }
}