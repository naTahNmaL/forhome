namespace PTP.DAL.Domains;

public class Country : BaseEntity
{
    public virtual string Name { get;  set; }
    public virtual string Code { get; set; }
    public virtual string Continent { get; set; }
    public virtual IList<Place> Places { get; set; }  = new List<Place>();
}