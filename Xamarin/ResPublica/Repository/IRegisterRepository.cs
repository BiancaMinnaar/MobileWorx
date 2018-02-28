using System;
using System.Threading.Tasks;
using ResPublica.Implementation.ViewModel;

namespace ResPublica.Interface.Repository
{
    public interface IRegisterRepository
    {
        Task Register(RegisterViewModel model, Action completeAction);
    }
}
