using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMail.Helper
{
    public class ListResponse<T>
    {
        public List<T> Data { get; set; }
        public int TotalRecords { get; set; } = 0;
        public bool Status { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
