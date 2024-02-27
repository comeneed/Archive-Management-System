using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class WebApiResponse
    {
        public string Message { get; set; }

        public bool Status { get; set; }

        public object Result { get; set; }
    }

    public class WebApiResponse<T>
    {
        public string Message { get; set; }

        public bool Status { get; set; }

        public T Result { get; set; }
    }
}
