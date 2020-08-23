using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podium.Data
{
    public sealed class DatabaseConnection
    {
        public DatabaseConnection(string connectionString) => Value = connectionString;

        public string Value { get; }
    }
}