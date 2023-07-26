using PTP.DAL.Domains;

namespace PTP.BusinessService.Models;

public class JourneyModel
{
    public virtual int Id { get; set; }
    public virtual UserInfo User { get; set; }
    public virtual string Name { get; set; }
    public virtual string Description { get; set; }
    public virtual Country Country { get; set; }
    public virtual Place Place { get; set; }
    public virtual DateTime StartDate { get; set; }
    public virtual DateTime EndDate { get; set; }
    public virtual long Amount { get; set; }
    public virtual Currency Currency { get; set; }
    public virtual string Status { get; set; }
}