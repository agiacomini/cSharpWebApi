using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cSharpWebApi.Data;
using cSharpWebApi.Data.Address;
using cSharpWebApi.Data.Address.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cSharpWebApi.Service.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly DatabaseContext _context;

        public AddressService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Address>> CreateAddress(CreateAddress createAddress)
        {
            var newAddress = new Address()
            {
                State = createAddress.State,
                Country = createAddress.Country,
                ZipCode = createAddress.ZipCode
            };
            _context.Addresses.Add(newAddress);
            await _context.SaveChangesAsync();

            return await _context.Addresses.ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Address>>> DeleteAddress(int id)
        {
            var addressToDelete = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (addressToDelete is null)
                return null;
                
            _context.Addresses.Remove(addressToDelete);
            await _context.SaveChangesAsync();

            return await _context.Addresses.ToListAsync();
        }

        public async Task<List<Address>> GetAllAddresses()
        {
            var address = await _context.Addresses.ToListAsync();
            return address;
        }

        public async Task<Address?> GetSingleAddress(int id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (address is null)
                return null;
            return address;
        }

        public async Task<Address?> UpdateAddress(int id, UpdateAddress updateAddress)
        {
            var addressToUpdate = _context.Addresses.FirstOrDefault(x => x.Id == id);

            addressToUpdate.State = updateAddress.State != null ? updateAddress.State : addressToUpdate.State;
            addressToUpdate.Country = updateAddress.Country != null ? updateAddress.Country : addressToUpdate.Country;
            addressToUpdate.ZipCode = updateAddress.ZipCode != null ? updateAddress.ZipCode : addressToUpdate.ZipCode;

            _context.Addresses.Update(addressToUpdate);
            await _context.SaveChangesAsync();
            return addressToUpdate;
        }
    }
}