namespace Project.Common.Utilities.Results;

public class Result : IResult
{
    public Result(bool success, string message) : this(success) // tihs sccces aşağıdaki ctor ' a gönderiyor ve set ediyor.
    {
        Message = message;
    }
    public Result(bool success)
    {
        Success = success;
    }

    public bool Success { get; }
    public string Message { get; }

}
