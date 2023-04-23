using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.Responses
{
    public class DefaultResponse<T>
    {
        public T? Data { get; set; }
        public string[]? Errors { get; set; }
    }
}
