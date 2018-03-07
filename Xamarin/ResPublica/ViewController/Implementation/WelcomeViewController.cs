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
    public class WelcomeViewController : ProjectBaseViewController<WelcomeViewModel>, IWelcomeViewController
    {
        IWelcomeRepository _Reposetory;
        IWelcomeService _Service;

        public override void SetRepositories()
        {
            _Service = new WelcomeService((U, P, C, A) =>
                                          ExecuteQueryWithReturnTypeAndNetworkAccessAsync<WelcomeResponse>(U, P, C, A));
            _Reposetory = new WelcomeRepository(_MasterRepo, _Service);
        }

        public async Task Welcome()
        {
            
        }
    }
}