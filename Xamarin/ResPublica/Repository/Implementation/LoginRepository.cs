using System;
using System.Threading.Tasks;
using ResPublica.Interface.Service;
using ResPublica.Interface.Repository;
using ResPublica.Implementation.ViewModel;
using ResPublica.Base;
using System.Windows.Input;

namespace ResPublica.Implementation.Repository
{
    public class LoginRepository : ProjectBaseRepository, ILoginRepository
    {
        ILoginService _Service;

        public LoginRepository(IMasterRepository masterRepository, ILoginService service)
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