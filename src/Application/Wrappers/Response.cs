using System.Collections.Generic;

namespace Application.Wrappers;

public class Response<T>
{
    public bool Succeded { get; set; }
    public string? Message { get; set; }
    public List<string>? Errors { get; set; }
    public T? Data { get; set; }

    public Response()
    {
    }

    public Response(string message)
    {
        Succeded = false;
        Message = message;
    }

    public Response(T data, string? message = null)
    {
        Succeded = true;
        Data = data;
        Message = message;
    }

    public static readonly Response<T> SuccessResponse = new Response<T> { Succeded=true };
    public static readonly Response<T> FailiorResponse = new Wrappers.Response<T> { Succeded=false };
}
