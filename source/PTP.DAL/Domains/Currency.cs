namespace PTP.DAL.Domains;

public class Currency : BaseEntity
{
    public virtual string Name { get;  set ; }
    public virtual string Symbol { get;  set; }
}