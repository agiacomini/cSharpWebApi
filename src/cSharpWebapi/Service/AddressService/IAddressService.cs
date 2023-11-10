using cSharpWebApi.Data.Address;
using cSharpWebApi.Data.Address.Dto;
using Microsoft.AspNetCore.Mvc;

namespace cSharpWebApi.Service.AddressService
{
    public interface IAddressService
    {
        Task<List<Address>> GetAllAddresses();
        Task<Address?> GetSingleAddress(int id);
        Task<Address?> UpdateAddress(int id, UpdateAddress updateAddress);
        Task<List<Address>> CreateAddress(CreateAddress createAddress);
        Task<ActionResult<IEnumerable<Address>>> DeleteAddress(int id);
    }
}