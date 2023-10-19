namespace cSharpWebApi.Data.Address.Dto
{
    public class CreateAddress
    {
        public string State {get; set;} = string.Empty;
        public string Country {get; set;} = string.Empty;
        public string ZipCode {get; set;} = string.Empty;
    }
}