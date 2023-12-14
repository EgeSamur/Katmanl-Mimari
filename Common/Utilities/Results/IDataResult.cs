using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common.Utilities.Results;

public interface IDataResult<T> : IResult
{
    // Manevi olarak burda da message ve succes var 
    T Data { get; }
}
