using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasePCL.Networking
{
    public class ConnectivityService : IConnectivityService
    {

        public bool isConnected()
        {
            return CrossConnectivity.Current.IsConnected;

        }
    }
}
