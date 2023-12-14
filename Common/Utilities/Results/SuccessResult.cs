namespace Project.Common.Utilities.Results;

public class SuccessResult : Result
{
    // eğer sonuç succes ise Resulta gidip succes'i true yapıyor eğer message değişkeni var ise onuda reuslta set ediyor.
    public SuccessResult(string message) : base(true, message)
    {

    }

    public SuccessResult() : base(true)
    {

    }
}