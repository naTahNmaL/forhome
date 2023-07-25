namespace PersistentLayer.Domains
{
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual string Visa { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual int Version { get; set; }
        public virtual IList<Project> Projects { get; set; }
    }


}
