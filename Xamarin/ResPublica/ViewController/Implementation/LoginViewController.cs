using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
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
	public class LoginViewController : ProjectBaseViewController<LoginViewModel>, ILoginViewController
	{
		ILoginRepository _Repository;
		ILoginService _Service;

        public LoginViewController()
        {
            _ChecksAndBalances.Add(new CheckAndBalance()
            {
                Check = () => !(InputObject.UserName == null && InputObject.UserName.Equals("")),
                Balance = "The Username is required."
            });

            var emailValidator = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            _ChecksAndBalances.Add(new CheckAndBalance()
            {
                Check = () => emailValidator.IsMatch(InputObject.UserName),
                Balance = "The Username must be a valid email address."
            });
            _ChecksAndBalances.Add(new CheckAndBalance()
            {
                Check = () => !(InputObject.Password == null && InputObject.Password.Equals("")),
                Balance = "The Password is required."
            });
        }

		public override void SetRepositories()
		{
//			_MasterRepo.NetworkInterface = (U, P, A) => ExecuteQueryWithObjectAndNetworkAccessAsync(U, P, A);
			_MasterRepo.NetworkInterfaceWithTypedParameters = (U, P, A) => ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A);
			_Service = new LoginService(_MasterRepo.NetworkInterfaceWithTypedParameters);
			_Repository = new LoginRepository(_MasterRepo, _Service);
		}

		public async Task Login()
		{
			try
			{
                var validation = RunChecksAndBalances();
                if (validation == "")
                {
                    await _Repository.Login(InputObject, () => { });
                }
                else
                {
                    ShowMessage(validation);
                }
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