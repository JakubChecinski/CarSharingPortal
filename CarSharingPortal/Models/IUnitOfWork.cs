using CarSharingPortal.Models.Repositories;

namespace CarSharingPortal.Models
{
    public interface IUnitOfWork
    {
        ICarSharingOfferRepository Offers { get; }
        ICityRepository Cities { get; }
        void Save();
    }
}