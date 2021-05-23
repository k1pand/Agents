using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agents.Classes
{
    class Connection
    {
        public static string String { get; } = "Data Source = COLLIDER\\SQLEXPRESS; Initial Catalog = Agents; uid=; pwd=; Integrated Security = true";  //подключение к БД через вызов Connection
       //public static string String { get; } = "Data Source = tcp:CL303-20; Initial Catalog = Agents; uid=darkhole; pwd=van; Integrated Security = true";  //подключение к БД через вызов Connection
    }
}
