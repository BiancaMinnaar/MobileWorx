using System.Threading.Tasks;
using HiRes.Implementation.ViewModel;

namespace HiRes.Interface.Service
{
    public interface IRegisterService
    {
        Task Register(RegisterViewModel model);
    }
}

