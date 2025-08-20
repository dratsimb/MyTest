using System;

namespace Safran.Data.Flowers
{
    public interface IFlowerRepository
    {
        int Add(string name);

        void Delete(int id);

        Guid AddFile(int id, Uri fileUri);

        void DeleteFile(int id, Guid fileId);

        (FlowerSummary[], int) Get(int page, int pageSize, bool isAscending);
    }
}
