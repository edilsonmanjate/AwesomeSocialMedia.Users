namespace AwesomeSocialMedia.Application.Models;

public class BaseResult
{
    public BaseResult(bool isSuccess = true, string message="")
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}


public class BaseResult<T> : BaseResult
    {
        public BaseResult(T data, bool isSuccess = true, string message = "") : base(isSuccess, message)
        {
            Data = data;
        }

        public T Data { get; private set; }
    }
