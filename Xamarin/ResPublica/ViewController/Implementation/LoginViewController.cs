using System;
using System.Diagnostics;
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
		ILoginRepository _Repository;
		ILoginService _Service;

		public override void SetRepositories()
		{
			_MasterRepo.NetworkInterface = (U, P, A) => ExecuteQueryWithObjectAndNetworkAccessAsync(U, P, A);
			_MasterRepo.NetworkInterfaceWithTypedParameters = (U, P, A) => ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A);
			_Service = new LoginService(_MasterRepo.NetworkInterfaceWithTypedParameters);
			_Repository = new LoginRepository(_MasterRepo, _Service);
		}

		public async Task Login()
		{
			try
			{
				//MasterRepository.MasterRepo.ShowLoading();

				await _Repository.Login(InputObject, () => { });

			}
			catch (Exception ex)
			{
#if DEBUG
				Debugger.Break();
#endif
				Debug.WriteLine(ex.Message);
			}
			finally
			{
				//MasterRepository.MasterRepo.HideLoading();
			}
		}

		public void RegisterView()
		{
			_MasterRepo.PushRegister();
		}
	}
}