using System;
using System.Threading.Tasks;
using CorePCL;
using HiRes.Base;
using HiRes.Implementation.ViewModel;
using HiRes.Interface.Repository;
using HiRes.Interface.Service;

namespace HiRes.Implementation.Repository
{
    public class LoginRepository<T> : ProjectBaseRepository, ILoginRepository<T>
        where T : BaseViewModel
    {
        ILoginService<T> _Service;

        public LoginRepository(IMasterRepository masterRepository, ILoginService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Login(LoginViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.Login(model);
            completeAction(serviceReturnModel);
        }


		public void RegisterView()
        {
            _MasterRepo.PushRegister();
        }

    }
}