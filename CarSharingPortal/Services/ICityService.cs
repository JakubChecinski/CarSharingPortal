using CarSharingPortal.Models.Domains;
using System.Collections.Generic;

namespace CarSharingPortal.Services
{
    public interface ICityService
    {
        IEnumerable<City> Get();
        void Add(City city);
    }
}
