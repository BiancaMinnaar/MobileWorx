using System;
using System.Threading.Tasks;
using HiRes.Implementation.ViewModel;

namespace HiRes.Interface.Repository
{
    public interface ILoginRepository
    {
        Task Login(LoginViewModel model, Action completeAction);
        void RegisterView();
    }
}
