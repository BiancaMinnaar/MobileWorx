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
        protected List<CheckAndBalance> _ChecksAndBalances;
        public bool HasSpecificResponse { get; set; }

        protected ProjectBaseViewController() 
            : base() 
        {

            _MasterRepo = MasterRepository.MasterRepo;

            HasSpecificResponse = false;
            _ChecksAndBalances = new List<CheckAndBalance>();
            base.NetworkInteractionSucceeded += (sender, e) =>
            {
                //if (e.CanResponseDeserialise)
                //{
                //    base.OutputObject = DeserializeObject(e.NetworkResponseContent);
                //} 
                //else 
                //{
                //    HasSpecificResponse = true;
                //}
				base._RawBytes = e.RawBytes;
				base._ResponseContent = e.NetworkResponseContent;
            };

            base.NetworkInteractionFailed += (sender, e) =>
            {
                string mys = e.NetworkCallMessage;
                UserDialogs.Instance.Toast(new ToastConfig(e.NetworkCallMessage)
                    .SetDuration(TimeSpan.FromSeconds(5)).SetBackgroundColor(System.Drawing.Color.FromArgb(193, 57, 43)));
            };
            base.NetworkCallInitialised += (sender, e) =>
            {
                //UserDialogs.Instance.ShowLoading();
            };
            base.NetworkCallCompleted += (sender, e) =>
            {
                //UserDialogs.Instance.HideLoading();
            };
        }

        protected override string SerializeObject(T objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }

        public string SerializeObjectWithType<G>(G objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }

        protected G DeserializeObject<G>(string stringToDeserialize)
        {
            var returnObject = JsonConvert.DeserializeObject<G>(stringToDeserialize);
            Debug.WriteLine(stringToDeserialize);
            return returnObject;
        }

        public void ShowMessage(string message)
        {
			UserDialogs.Instance.Toast(new ToastConfig(message)
					.SetDuration(TimeSpan.FromSeconds(5)).SetBackgroundColor(System.Drawing.Color.FromArgb(193, 57, 43)));
        }

        protected string RunChecksAndBalances()
        {
            foreach(CheckAndBalance check in this._ChecksAndBalances)
            {
                if (!check.Check())
                {
                    return check.Balance;
                }
            }

            return "";
        }

        public abstract void SetRepositories();
        protected virtual void SetServiceNetworkOnline()
        {}
        protected virtual void SetServiceNetworkOffline()
        {}

        private void SetServiceNetworkAccess(bool isConnected)
        {
            if (isConnected)
                SetServiceNetworkOnline();
            else
                SetServiceNetworkOffline();
        }
    }
}
