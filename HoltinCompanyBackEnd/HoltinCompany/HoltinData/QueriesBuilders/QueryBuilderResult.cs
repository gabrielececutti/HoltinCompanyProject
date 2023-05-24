using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinData.QueriesBuilders
{
    public class QueryBuilderResult
    {
        public string? Query { get; set; }
        public Dictionary<string, object>? Parameters { get; set; }
    }
}
