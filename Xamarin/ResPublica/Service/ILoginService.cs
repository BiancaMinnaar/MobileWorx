using System.Threading.Tasks;
using ResPublica.Implementation.ViewModel;

namespace ResPublica.Interface.Service
{
    public interface ILoginService
    {
        Task Login(LoginViewModel model);
    }
}

