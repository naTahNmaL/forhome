using Common.UnitOfWork;
using NHibernate;

namespace Common.Transactions
{
    public interface IUnitTransaction
    {
        void Commit();

        void Rollback();

    }

    public class UnitTransaction : IUnitTransaction
    {
        private readonly IUnitOfWork _unitOfWork = null!;


        public UnitTransaction(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Commit()
        {

            _unitOfWork.GetActiveSession().GetCurrentTransaction().Commit();
            _unitOfWork.Close();
        }

        public void Rollback()
        {
            _unitOfWork.GetActiveSession().GetCurrentTransaction().Rollback();
            _unitOfWork.Close();
        }
    }

}
