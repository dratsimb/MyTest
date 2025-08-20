using System;

namespace Safran.Data
{
    public interface IFlowerPictureRepository
    {
        Guid Add(int flowerId, string fileUrl);

        string[] GetList(int flowerId);

        int Delete(int flowerId, Guid pictureId);
    }
}
