using System;
using System.Collections.Generic;
using System.Diagnostics;
using Acr.UserDialogs;
using CorePCL;
using Newtonsoft.Json;
using HiRes.Implementation.Repository;
using HiRes.Interface.Repository;

namespace HiRes.Base
{
	public abstract class ProjectBaseViewController<T> : BaseViewController<T>
		where T : ProjectBaseViewModel
	{
		public IMasterRepository _MasterRepo { get; set; }
		protected List<BrokenRule> BrokenRules;
		public bool HasSpecificResponse { get; set; }

		protected ProjectBaseViewController()
        {
			_MasterRepo = MasterRepository.MasterRepo;

			HasSpecificResponse = false;
			BrokenRules = new List<BrokenRule>();
			base.NetworkInteractionSucceeded += (sender, e) =>
			{
				base._RawBytes = e.RawBytes;
				base._ResponseContent = e.NetworkResponseContent;
			};

			base.NetworkInteractionFailed += (sender, e) =>
			{
				string mys = e.NetworkCallMessage;
				UserDialogs.Instance.Toast(new ToastConfig(e.NetworkCallMessage).SetDuration(TimeSpan.FromSeconds(5)).SetBackgroundColor(System.Drawing.Color.FromArgb(193, 57, 43)));
			};
			base.NetworkCallInitialised += (sender, e) =>
			{
				UserDialogs.Instance.ShowLoading();
			};
			base.NetworkCallCompleted += (sender, e) =>
			{
				UserDialogs.Instance.HideLoading();
			};
		}

		/// <summary>
		/// Serializes the object.
		/// </summary>
		/// <param name="objectToSerialize">The object to serialize.</param>
		/// <returns></returns>
		protected override string SerializeObject(T objectToSerialize)
		{
			return JsonConvert.SerializeObject(objectToSerialize);
		}

		/// <summary>
		/// Serializes the type of the object with.
		/// </summary>
		/// <typeparam name="G"></typeparam>
		/// <param name="objectToSerialize">The object to serialize.</param>
		/// <returns></returns>
		public string SerializeObjectWithType<G>(G objectToSerialize)
		{
			return JsonConvert.SerializeObject(objectToSerialize);
		}

		/// <summary>
		/// Deserializes the object.
		/// </summary>
		/// <typeparam name="G"></typeparam>
		/// <param name="stringToDeserialize">The string to deserialize.</param>
		/// <returns></returns>
		protected G DeserializeObject<G>(string stringToDeserialize)
		{
			var returnObject = JsonConvert.DeserializeObject<G>(stringToDeserialize);
			Debug.WriteLine(stringToDeserialize);
			return returnObject;
		}

		/// <summary>
		/// Shows the message.
		/// </summary>
		/// <param name="message">The message.</param>
		public void ShowMessage(string message)
		{
			try
			{
				var toastOptions = new ToastConfig(message);
				toastOptions.SetDuration(TimeSpan.FromSeconds(5));
				toastOptions.SetBackgroundColor(System.Drawing.Color.Red);
				toastOptions.SetPosition(ToastPosition.Bottom);
				toastOptions.SetMessageTextColor(System.Drawing.Color.White);

				UserDialogs.Instance.Toast(message, TimeSpan.FromSeconds(5));

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}

		public void ShowError(string message)
		{
			try
			{
				var toastOptions = new ToastConfig(message);
				toastOptions.SetDuration(TimeSpan.FromSeconds(5));
				toastOptions.SetBackgroundColor(System.Drawing.Color.Red);
				toastOptions.SetPosition(ToastPosition.Bottom);
				toastOptions.SetMessageTextColor(System.Drawing.Color.White);

				UserDialogs.Instance.Toast(toastOptions);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// Validates the broken rules.
		/// </summary>
		/// <returns></returns>
		protected string ValidateBrokenRules()
		{
			foreach (BrokenRule check in this.BrokenRules)
			{
				if (!check.Check())
					return check.Balance;
			}

			return "";
		}

		public abstract void SetRepositories();

		/// <summary>
		/// Sets the service network online.
		/// </summary>
		protected virtual void SetServiceNetworkOnline()
		{
		}

		/// <summary>
		/// Sets the service network offline.
		/// </summary>
		protected virtual void SetServiceNetworkOffline()
		{
		}

		private void SetServiceNetworkAccess(bool isConnected)
		{
			if (isConnected)
				SetServiceNetworkOnline();
			else
				SetServiceNetworkOffline();
		}
	}
}
