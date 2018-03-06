using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using HiRes.Base;
using HiRes.Implementation.ViewModel;
using HiRes.Interface.Service;

namespace HiRes.Implementation.Service
{
	public class RegisterService : BaseService, IRegisterService
	{
        public RegisterService(Func<string, Dictionary<string, ParameterTypedValue>, BaseViewModel, BaseNetworkAccessEnum, Task> networkInterface)
			: base(networkInterface)
		{
		}

		public async Task Register(RegisterViewModel model)
		{
			string requestURL = "http://sm2.respublica.co.za/API/app/AppAPI/Register";
			var httpMethod = BaseNetworkAccessEnum.Get;



			var parameters = new Dictionary<string, ParameterTypedValue>()
			{
				{"X-API-TOKEN", new ParameterTypedValue() {
						ParameterValue="boguskey",
						ParameterType=ParameterTypeEnum.HeaderParameter
					}
				}
			};


			parameters["name"] = new ParameterTypedValue(model.Name);
			parameters["surname"] = new ParameterTypedValue(model.Surname);
			parameters["gender"] = new ParameterTypedValue(model.Gender);

			parameters["nationality"] = new ParameterTypedValue(model.Nationality);
			parameters["nationalityOther"] = new ParameterTypedValue(model.NationalitiesOther);

			parameters["rsa_id "] = new ParameterTypedValue(model.NationalIdNumber);
			parameters["mobile_number"] = new ParameterTypedValue(model.MobileNumber);

			parameters["email"] = new ParameterTypedValue(model.EmailAddress);
			parameters["email_confirm"] = new ParameterTypedValue(model.EmailAddressConfirm);

			parameters["birthday"] = new ParameterTypedValue(model.BirthDate);

			parameters["password"] = new ParameterTypedValue(model.Password);
			parameters["password_confirm"] = new ParameterTypedValue(model.PasswordConfirm);

			parameters["source"] = new ParameterTypedValue(model.WhereDidYouHearAboutUs);

			var deviceId = Plugin.DeviceInfo.CrossDeviceInfo.Current.GenerateAppId(true, "RSL");

			parameters["device"] = new ParameterTypedValue(deviceId);
			parameters["token_type"] = new ParameterTypedValue("app");


			// : male, female, other
			//nationality : local = South African, foreign: Foreign
			//birthday
			//password
			//password_confirm
			//source : rsl_employee = "Respublica Student Living Employee", newspaper, google
			//device
			//token_type : app = "Mobile App"
			//X-API-KEY : boguskey_rsl


			await _NetworkInterface(requestURL, parameters, httpMethod);
		}
	}
}
