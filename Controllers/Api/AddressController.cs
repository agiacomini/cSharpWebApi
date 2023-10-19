using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cSharpWebApi.Data;
using cSharpWebApi.Data.Address;
using cSharpWebApi.Data.Address.Dto;
using NuGet.Protocol;
using cSharpWebApi.Service.AddressService;

namespace cSharpWebApi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IAddressService _addressService;

        public AddressController(DatabaseContext context, IAddressService addressService)
        {
            _context = context;
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            List<Address> addresses = await _addressService.GetAllAddresses();
            return addresses;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            if (!AddressExists(id))
                return NotFound("Address id " + id + " not found");

            var address = await _addressService.GetSingleAddress(id);
            return address; 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Address>> PutAddress(int id, UpdateAddress updateAddress)
        {
            if (!AddressExists(id))
                return NotFound("Address id " + id + " not found");

            var addressUpdated = await _addressService.UpdateAddress(id, updateAddress);
            return addressUpdated;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Address>>> PostAddress(CreateAddress createAddress)
        {
            return await _addressService.CreateAddress(createAddress);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Address>>> DeleteAddress(int id)
        {
            if (!AddressExists(id))
                return NotFound("Address id " + id + " not found");

            return await _addressService.DeleteAddress(id);
        }

        private bool AddressExists(int id)
        {
            return (_context.Addresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}