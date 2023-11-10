using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cSharpWebApi.Data.Address.Dto
{
    public class UpdateAddress
    {
        public string? State {get; set;}
        public string? Country {get; set;}
        public string? ZipCode {get; set;}
    }
}