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
    public class WelcomeTwoViewController : ProjectBaseViewController<WelcomeTwoViewModel>, IWelcomeTwoViewController
    {
        IWelcomeTwoRepository _Reposetory;
        IWelcomeTwoService _Service;

        public override void SetRepositories()
        {
            _MasterRepo.NetworkInterface = (U, P, A) => ExecuteQueryWithObjectAndNetworkAccessAsync(U, P, A);
            _MasterRepo.NetworkInterfaceWithTypedParameters = (U, P, A) => ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A);
            _Service = new WelcomeTwoService(_MasterRepo.NetworkInterfaceWithTypedParameters);
            _Reposetory = new WelcomeTwoRepository(_MasterRepo, _Service);
        }

        public async Task WelcomeTwo()
        {
            
        }
    }
}