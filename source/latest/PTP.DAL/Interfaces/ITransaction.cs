namespace PTP.DAL.Interfaces;

public interface ITransaction 
{
    void Commit();
    void Rollback();
}