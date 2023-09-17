using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

namespace ManagementAppDbHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBaseLoader.MongoDBLoader();
        }
    }
}
