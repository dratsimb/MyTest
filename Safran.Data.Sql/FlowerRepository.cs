using Safran.Data.Flowers;

namespace Safran.Data.Sql
{
    public class FlowerRepository(IConnectionProvider connectionProvider) :BaseRepository(connectionProvider), IFlowerRepository
    {
        int IFlowerRepository.Add(string name)
        {
            throw new NotImplementedException();
        }

        Guid IFlowerRepository.AddFile(int id, Uri fileUri)
        {
            throw new NotImplementedException();
        }

        void IFlowerRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

        void IFlowerRepository.DeleteFile(int id, Guid fileId)
        {
            throw new NotImplementedException();
        }

        (FlowerSummary[], int) IFlowerRepository.Get(int page, int pageSize, bool isAscending)
        {
            throw new NotImplementedException();
        }
    }
}
