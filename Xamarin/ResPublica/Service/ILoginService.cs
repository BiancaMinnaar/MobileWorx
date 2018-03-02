using System.Threading.Tasks;
using HiRes.Implementation.ViewModel;

namespace HiRes.Interface.Service
{
    public interface ILoginService
    {
        Task Login(LoginViewModel model);
    }
}

