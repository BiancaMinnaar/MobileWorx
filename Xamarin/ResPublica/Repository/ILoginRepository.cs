using System;
using System.Threading.Tasks;
using ResPublica.Implementation.ViewModel;

namespace ResPublica.Interface.Repository
{
    public interface ILoginRepository
    {
        Task Login(LoginViewModel model, Action completeAction);
        void RegisterView();
    }
}
