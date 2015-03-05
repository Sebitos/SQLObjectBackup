using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLObjectBackup
{
    interface IDataStore
    {
        bool TestConnection();
        void CleanupAll();
    }
}
