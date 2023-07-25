namespace PersistentLayer.Domains
{
    public class ProjectEmployee
    {
        public virtual int ProjectId { get; set; }
        public virtual int EmployeeId { get; set; }
        public virtual Project Project { get; set; }
        public virtual Employee Employee { get; set; }
    }


}
