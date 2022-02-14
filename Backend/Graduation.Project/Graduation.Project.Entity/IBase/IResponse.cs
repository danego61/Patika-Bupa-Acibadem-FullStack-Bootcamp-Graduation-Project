using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Entity.IBase
{

    public interface IResponse
    {
        string Message { get; set; }

        int StatusCode { get; set; }

        object Data { get; set; }
    }

    public interface IResponse<T> : IResponse
    {
        new T Data { get; set; }

    }
}
