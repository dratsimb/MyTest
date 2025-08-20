

using System.Data;

namespace Safran.Data.Sql
{
    public class FlowerPictureRepository(IConnectionProvider connectionProvider) : BaseRepository(connectionProvider), IFlowerPictureRepository
    {
        Guid IFlowerPictureRepository.Add(int flowerId, string fileUrl)
        {
            throw new NotImplementedException();
        }

        int IFlowerPictureRepository.Delete(int flowerId, Guid pictureId)
        {
            throw new NotImplementedException();
        }

        string[] IFlowerPictureRepository.GetList(int flowerId)
        {
            throw new NotImplementedException();
        }
    }
}
