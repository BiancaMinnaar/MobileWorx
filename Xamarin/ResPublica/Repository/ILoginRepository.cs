using System;
using System.Threading.Tasks;
using CorePCL;
using HiRes.Implementation.ViewModel;

namespace HiRes.Interface.Repository
{
    public interface ILoginRepository<T>
        where T : BaseViewModel
    {
        Task Login(LoginViewModel model, Action<T> completeAction);
        void RegisterView();
    }
}
