using PTP.DAL.Domains;

namespace PTP.BusinessService.Models;

public class CountryModel
{
    public virtual int Id { get; set; }
    public virtual string Name { get;  set; }
    public virtual string Code { get; set; }
    public virtual string Continent { get; set; }
    public virtual IList<Place> Places { get; set; }  = new List<Place>();
}