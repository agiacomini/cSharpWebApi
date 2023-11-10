namespace cSharpWebApi.Data;

public interface ISystemInfoService
{
      string GetCurrentUser();
      DateTime GetCurrentDate();   
}

public class SystemInfoService : ISystemInfoService
{
    public string GetCurrentUser()
    {
        return "andr3a.giacomini";
    }

    public DateTime GetCurrentDate()
    {
        return DateTime.UtcNow;
    }
}