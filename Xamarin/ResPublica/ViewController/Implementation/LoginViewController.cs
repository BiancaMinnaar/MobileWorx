using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CorePCL;
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
	public class LoginViewController : ProjectBaseViewController<LoginViewModel>, ILoginViewController
	{
		ILoginRepository<LoginResponseUser> _Repository;
		ILoginService<LoginResponseUser> _Service;

		public LoginViewController()
		{
			BrokenRules.Add(new BrokenRule()
			{
				Check = () => InputObject.Username.IsNotNullOrEmpty(),
				Balance = "The Username is required."
			});

			var emailValidator = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
			BrokenRules.Add(new BrokenRule()
			{
				Check = () => emailValidator.IsMatch(InputObject.Username.Trim()),
				Balance = "The Username must be a valid email address."
			});
			BrokenRules.Add(new BrokenRule()
			{
				Check = () => InputObject.Password.IsNotNullOrEmpty(),
				Balance = "The Password is required."
			});
		}

		public override void SetRepositories()
		{
			_Service = new LoginService<LoginResponseUser>((U, P, C, A) =>
														   ExecuteQueryWithReturnTypeAndNetworkAccessAsync<LoginResponseUser>(U, P, C, A));
			_Repository = new LoginRepository<LoginResponseUser>(_MasterRepo, _Service);
		}

		public async Task Login()
		{
			try
			{
				var validation = ValidateBrokenRules();
				if (validation == "")
				{
					// Trim the spaces from the end of the property
					InputObject.Username = InputObject.Username.Trim();

					await _Repository.Login(InputObject, (response) =>
					{
						// Ensure the request was valid
						if (response.Status.StatusCode == 200)
						{
							ShowMessage($"Welcome your Token is : {response.Token}");
							Debug.WriteLine(response.StudentManagerID);
							_MasterRepo.PushSandbox();
						}
						else
							ShowError(response.Status.Message);
					});
				}
				else
				{
					ShowError(validation);
				}
			}
			catch (Exception ex)
			{
				ShowError(ex.Message);
				//#if DEBUG
				//				Debugger.Break();
				//#endif
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