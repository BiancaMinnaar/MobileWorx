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
using HiRes.ViewModel;

namespace HiRes.Implementation.ViewController
{
	public class LoginViewController : ProjectBaseViewController<LoginViewModel>, ILoginViewController
	{
		ILoginRepository _Repository;
		ILoginService _Service;

		public LoginViewController()
		{
			BrokenRules.Add(new BrokenRule()
			{
				Check = () => !string.IsNullOrWhiteSpace(InputObject.Username),
				Balance = "The Username is required."
			});

			var emailValidator = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
			BrokenRules.Add(new BrokenRule()
			{
				Check = () => emailValidator.IsMatch(InputObject.Username),
				Balance = "The Username must be a valid email address."
			});
			BrokenRules.Add(new BrokenRule()
			{
				Check = () => !(InputObject.Password == null && InputObject.Password.Equals("")),
				Balance = "The Password is required."
			});
		}

		public override void SetRepositories()
		{
			_MasterRepo.NetworkInterfaceWithTypedParameters = (U, P, C, A) => ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, C, A);
			_Service = new LoginService(_MasterRepo.NetworkInterfaceWithTypedParameters);
			_Repository = new LoginRepository(_MasterRepo, _Service);
		}

		public async Task Login()
		{
			try
			{
				var validation = ValidateBrokenRules();
				if (validation == "")
				{
					await _Repository.Login(InputObject, () => 
                    { 
                        _MasterRepo.DataSorce.Authenticated = true;
                        _MasterRepo.DataSorce.User = DeserializeObject<UserModel>(_ResponseContent);
                    });
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