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
    public class WelcomeThreeViewController : ProjectBaseViewController<WelcomeThreeViewModel>, IWelcomeThreeViewController
    {
        IWelcomeThreeRepository _Reposetory;
        IWelcomeThreeService _Service;

        public override void SetRepositories()
        {
            _MasterRepo.NetworkInterface = (U, P, A) => ExecuteQueryWithObjectAndNetworkAccessAsync(U, P, A);
            _MasterRepo.NetworkInterfaceWithTypedParameters = (U, P, C, A) => ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, C, A);
            _Service = new WelcomeThreeService(_MasterRepo.NetworkInterfaceWithTypedParameters);
            _Reposetory = new WelcomeThreeRepository(_MasterRepo, _Service);
        }

        public async Task WelcomeThree()
        {
            
        }
    }
}