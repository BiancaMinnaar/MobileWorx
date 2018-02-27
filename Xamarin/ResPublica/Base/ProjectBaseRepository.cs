using PCLBase.DataContracts;
using ResPublica.Interface.Repository;

namespace ResPublica.Base
{
    public class ProjectBaseRepository : BaseRepository
    {
        protected IMasterRepository _MasterRepo;

        public ProjectBaseRepository(IMasterRepository masterRepository)
        {
            _MasterRepo = masterRepository;
        }
    }
}
