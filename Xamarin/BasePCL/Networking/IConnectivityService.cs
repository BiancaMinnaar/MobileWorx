using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasePCL.Networking
{
    public interface IConnectivityService
    {
        bool isConnected();
    }
}
