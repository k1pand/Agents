using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agents.Classes
{
    class Connection
    {
        public static string String { get; } = "Data Source = tcp:CL303-20; Initial Catalog = Agents; Integrated Security = true"; //подключение к БД через вызов Connection
    }
}
