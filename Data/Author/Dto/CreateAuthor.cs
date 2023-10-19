namespace cSharpWebApi.Data.Author.Dto
{
    public class CreateAuthor
    {
        public string FirstName {get; set;} = string.Empty;
        public string LastName {get; set;} = string.Empty;
        public int AddressId {get; set;}
        public int[] BookId { get; set; }
    }
}