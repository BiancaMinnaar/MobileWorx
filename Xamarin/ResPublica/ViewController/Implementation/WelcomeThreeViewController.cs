using System.Threading.Tasks;
using HiRes.Base;
using HiRes.Implementation.Repository;
using HiRes.Implementation.Service;
using HiRes.Implementation.ViewModel;
using HiRes.Interface.Repository;
using HiRes.Interface.Service;
using HiRes.Interface.ViewController;
using HiRes.ViewModel.ReturnModel;

namespace HiRes.Implementation.ViewController
{
    public class WelcomeThreeViewController : ProjectBaseViewController<WelcomeThreeViewModel>, IWelcomeThreeViewController
    {
        IWelcomeThreeRepository _Reposetory;
        IWelcomeThreeService _Service;

        public override void SetRepositories()
        {
            _Service = new WelcomeThreeService((U, P, C, A) =>
                                               ExecuteQueryWithReturnTypeAndNetworkAccessAsync<WelcomeResponse>(U, P, C, A));
            _Reposetory = new WelcomeThreeRepository(_MasterRepo, _Service);
        }

        public async Task WelcomeThree()
        {
            
        }
    }
}