using FluentResults;

namespace SaxsSpot.Shared.Contracts.Models;

public class ResultDto<T>
{
    public T Result { get; set; }
    
    public bool IsSuccess { get; set; }

    public IEnumerable<ErrorDto> Errors { get; set; }

    public ResultDto(bool isSuccess, IEnumerable<ErrorDto> errors, T result)
    {
        Result = result;
        IsSuccess = isSuccess;
        Errors = errors;
    }
}

public class ErrorDto
{
    public string Message { get; set; }

    public string Code { get; set; }

    public ErrorDto(string message, string code)
    {
        Message = message;
        Code = code;
    }
}

public static class ResultDtoExtensions
{
    public static ResultDto<T> ToResultDto<T>(this IResult<T> result)
    {
        if (result.IsSuccess)
            return new ResultDto<T>(true, Enumerable.Empty<ErrorDto>(), result.ValueOrDefault);

        return new ResultDto<T>(false, TransformErrors(result.Errors), result.ValueOrDefault);
    }

    private static IEnumerable<ErrorDto> TransformErrors(IEnumerable<IError> errors)
    {
        
        return errors.Select(TransformError);
    }

    private static ErrorDto TransformError(IError error)
    {
        var errorCode = TransformErrorCode(error);

        return new ErrorDto(error.Message, errorCode);
    }

    private static string TransformErrorCode(IError error)
    {
        if (error.Metadata.TryGetValue("ErrorCode", out var errorCode))
            return errorCode as string;

        return "";
    }
}