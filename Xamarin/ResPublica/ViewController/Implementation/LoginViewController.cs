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
    public class LoginViewController : ProjectBaseViewController<LoginViewModel>, ILoginViewController
    {
        ILoginRepository _Reposetory;
        ILoginService _Service;

        public override void SetRepositories()
        {
            _MasterRepo.NetworkInterface = (U, P, A) => ExecuteQueryWithObjectAndNetworkAccessAsync(U, P, A);
            _MasterRepo.NetworkInterfaceWithTypedParameters = (U, P, A) => ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A);
            _Service = new LoginService(_MasterRepo.NetworkInterface);
            _Reposetory = new LoginRepository(_MasterRepo, _Service);
        }

        public async Task Login()
        {
            
        }
    }
}