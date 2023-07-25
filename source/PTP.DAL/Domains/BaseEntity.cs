namespace PTP.DAL.Domains;

public class BaseEntity
{
    public virtual int Id { get; set; }
    public virtual int Version { get; set; }
}