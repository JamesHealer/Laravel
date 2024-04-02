using API.DTOs;
using API.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Servivces.Interfaces
{
    public interface IOfferService
    {
        Task<int> AddOffer(OffersDto serviceSetupDto);
        Task<int> EditOffer(OffersDto serviceSetupDto);
        Task<int> DeleteOffer(int id);
        Task<ServiceSetupDto> GetOfferById(int id);
        Task<ServiceSetupDtoObj> GetOffers(PaginationParams paginationParams);
    }
}
