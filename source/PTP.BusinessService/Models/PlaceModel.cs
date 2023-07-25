using PTP.DAL.Domains;

namespace PTP.BusinessService.Models;

public class PlaceModel
{
    public virtual int Id { get; set; }
    public virtual string Name { get; protected  set; }
    public virtual Country Country { get; protected   set; }   
}