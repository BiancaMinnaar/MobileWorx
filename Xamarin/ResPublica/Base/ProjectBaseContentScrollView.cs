using HiRes.Implementation.Repository;
using Xamarin.Forms;

namespace HiRes.Base
{
    public abstract class ProjectBaseContentScrollView<T, M> : ScrollView
		where T : ProjectBaseViewController<M>, new()
		where M : ProjectBaseViewModel
	{
		protected T _ViewController;

		protected ProjectBaseContentScrollView()
		{
			_ViewController = new T();
			_ViewController._MasterRepo = MasterRepository.MasterRepo;
			_ViewController.SetRepositories();
		}

		protected abstract void SetSVGCollection();
	}
}
