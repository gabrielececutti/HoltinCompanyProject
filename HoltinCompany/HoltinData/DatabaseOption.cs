using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinData
{
    public class DatabaseOption
    {
        public string ConnectionString { get;  private set; }
        public DatabaseOption (string connectionString) => ConnectionString = connectionString;
    }
}
