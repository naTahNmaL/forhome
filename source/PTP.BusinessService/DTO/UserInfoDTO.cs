using PTP.DAL.Domains;

namespace PTP.BusinessService.DTO;

public class UserInfoDTO
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    
    public UserAvatar Avatar { get; set; }
    public IList<Journey> Journeys { get; set; } = new List<Journey>();
    //public IList<UsersRole> Roles { get; set; } = new List<UsersRole>();
}
