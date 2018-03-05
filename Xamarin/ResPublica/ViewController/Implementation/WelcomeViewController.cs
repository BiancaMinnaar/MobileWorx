using System.Threading.Tasks;
using HiRes.Base;
using HiRes.Implementation.Repository;
using HiRes.Implementation.Service;
using HiRes.Implementation.ViewModel;
using HiRes.Interface.Repository;
using HiRes.Interface.Service;
using HiRes.Interface.ViewController;

namespace HiRes.Implementation.ViewController
{
    public class WelcomeViewController : ProjectBaseViewController<WelcomeViewModel>, IWelcomeViewController
    {
        IWelcomeRepository _Reposetory;
        IWelcomeService _Service;

        public override void SetRepositories()
        {
            _MasterRepo.NetworkInterface = (U, P, A) => ExecuteQueryWithObjectAndNetworkAccessAsync(U, P, A);
            _MasterRepo.NetworkInterfaceWithTypedParameters = (U, P, C, A) => ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, C, A);
            _Service = new WelcomeService(_MasterRepo.NetworkInterfaceWithTypedParameters);
            _Reposetory = new WelcomeRepository(_MasterRepo, _Service);
        }

        public async Task Welcome()
        {
            
        }
    }
}