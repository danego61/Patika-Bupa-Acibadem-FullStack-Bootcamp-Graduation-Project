using Graduation.Project.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Entity.Base
{

    public class Response : IResponse
    {
        public string Message { get; set; } = null!;

        public int StatusCode { get; set; }

        public object Data { get; set; } = null!;
    }

    public class Response<T> : Response, IResponse<T> where T : class
    {

        public new T Data { get; set; } = null!;

    }

}
