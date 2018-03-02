using System.Threading.Tasks;
using ResPublica.Base;
using ResPublica.Implementation.Repository;
using ResPublica.Implementation.Service;
using ResPublica.Implementation.ViewModel;
using ResPublica.Interface.Repository;
using ResPublica.Interface.Service;
using ResPublica.Interface.ViewController;

namespace ResPublica.Implementation.ViewController
{
    public class RegisterViewController : ProjectBaseViewController<RegisterViewModel>, IRegisterViewController
    {
        IRegisterRepository _Reposetory;
        IRegisterService _Service;

        public override void SetRepositories()
        {
            _MasterRepo.NetworkInterface = (U, P, A) => ExecuteQueryWithObjectAndNetworkAccessAsync(U, P, A);
            _MasterRepo.NetworkInterfaceWithTypedParameters = (U, P, A) => ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A);
            _Service = new RegisterService(_MasterRepo.NetworkInterfaceWithTypedParameters);
            _Reposetory = new RegisterRepository(_MasterRepo, _Service);
        }

        public async Task Register()
        {
			_MasterRepo.PushSandbox();

		}
	}
}