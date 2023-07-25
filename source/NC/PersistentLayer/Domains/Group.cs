namespace PersistentLayer.Domains
{
    public class Group
    {
        public virtual int Id { get; set; }
        public virtual int GroupLeaderId { get; set; }
        public virtual string GroupName { get; set; }
        public virtual int Version { get; set; }
        public virtual Employee Leader { get; set; }

        public virtual IList<Project> Projects { get; set; }
    }


}
