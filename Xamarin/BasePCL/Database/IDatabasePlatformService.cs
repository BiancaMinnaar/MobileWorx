using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasePCL.Database
{
    public interface IDatabasePlatformService
    {
       // string getDatabasePath();
       // ISQLitePlatform getDevicePlatform();

        void CloseConnection();
        SQLiteAsyncConnection GetAsyncConnection();
        void DeleteDatabase();
    }
}
