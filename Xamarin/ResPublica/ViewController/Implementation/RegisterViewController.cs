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
    public class RegisterViewController : ProjectBaseViewController<RegisterViewModel>, IRegisterViewController
    {
        IRegisterRepository _Reposetory;
        IRegisterService _Service;

        public override void SetRepositories()
        {
            _Service = new RegisterService((U, P, C, A) =>
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<RegisterResponse>(U, P, C, A));
            _Reposetory = new RegisterRepository(_MasterRepo, _Service);
        }

        public async Task Register()
        {
			_MasterRepo.PushSandbox();

		}
	}
}