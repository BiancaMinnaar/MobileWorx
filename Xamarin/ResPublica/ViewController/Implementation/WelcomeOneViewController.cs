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
    public class WelcomeOneViewController : ProjectBaseViewController<WelcomeOneViewModel>, IWelcomeOneViewController
    {
        IWelcomeOneRepository _Reposetory;
        IWelcomeOneService _Service;

        public override void SetRepositories()
        {
            _Service = new WelcomeOneService((U, P, C, A) =>
                                             ExecuteQueryWithReturnTypeAndNetworkAccessAsync<WelcomeResponse>(U, P, C, A));
            _Reposetory = new WelcomeOneRepository(_MasterRepo, _Service);
        }

        public async Task WelcomeOne()
        {
            
        }
    }
}