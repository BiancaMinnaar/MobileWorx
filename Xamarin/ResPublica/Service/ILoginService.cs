using System.Threading.Tasks;
using CorePCL;
using HiRes.Implementation.ViewModel;

namespace HiRes.Interface.Service
{
    public interface ILoginService<T>
        where T : BaseViewModel
    {
        Task<T> Login(LoginViewModel model);
    }
}

