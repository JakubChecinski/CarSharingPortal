using CarSharingPortal.Models.Domains;
using System.Collections.Generic;

namespace CarSharingPortal.Models.Repositories
{
    public interface ICityRepository
    {
        IEnumerable<City> Get();
        void Add(City city);
    }
}
