using System.Threading.Tasks;
using HiRes.Implementation.ViewModel;

namespace HiRes.Interface.Service
{
    public interface IWelcomeThreeService
    {
        Task WelcomeThree(WelcomeThreeViewModel model);
    }
}

