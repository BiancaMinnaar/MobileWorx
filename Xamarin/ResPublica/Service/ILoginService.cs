using System.Threading.Tasks;
using HiRes.Implementation.ViewModel;
using HiRes.ViewModel.ReturnModel;

namespace HiRes.Interface.Service
{
    public interface ILoginService<T>
    {
        Task<T> Login(LoginViewModel model);
    }
}

