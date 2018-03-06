using System;
using System.Threading.Tasks;
using HiRes.Base;
using HiRes.Implementation.ViewModel;
using HiRes.Interface.Repository;
using HiRes.Interface.Service;

namespace HiRes.Implementation.Repository
{
    public class LoginRepository<T> : ProjectBaseRepository, ILoginRepository
    {
        ILoginService<T> _Service;

        public LoginRepository(IMasterRepository masterRepository, ILoginService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Login(LoginViewModel model, Action completeAction)
        {
            await _Service.Login(model);
            completeAction();
        }


		public void RegisterView()
        {
            _MasterRepo.PushRegister();
        }

    }
}