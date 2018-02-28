using System.Threading.Tasks;
using ResPublica.Implementation.ViewModel;

namespace ResPublica.Interface.Service
{
    public interface IRegisterService
    {
        Task Register(RegisterViewModel model);
    }
}

