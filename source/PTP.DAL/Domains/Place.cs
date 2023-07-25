namespace PTP.DAL.Domains;

public class Place : BaseEntity
{
    public virtual string Name { get; protected  set; }
    public virtual Country Country { get; protected   set; }   
}