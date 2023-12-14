namespace Project.Common.Utilities.Results;

public class DataResult<T> : Result, IDataResult<T>
{
    // buradaki baseler de Result İçerisindeki Ctorlarda succes ve message datalarını gönderip set ediyor.
    public DataResult(T? data, bool success, string message) : base(success, message)
    {
        Data = data;
    }

    public DataResult(T? data, bool success) : base(success)
    {
        Data = data;

    }

    public T Data { get; }
}