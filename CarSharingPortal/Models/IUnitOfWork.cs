using CarSharingPortal.Models.Repositories;

namespace CarSharingPortal.Models
{
    public interface IUnitOfWork
    {
        ICarSharingOfferRepository Offers { get; }
        void Save();
    }
}