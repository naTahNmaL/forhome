using AutoMapper;
using Common.UnitOfWork;
using PersistentLayer.Repositories;
using ServiceLayer.DTO;

namespace ServiceLayer.Services
{

    public interface IEmployeeService
    {
        public Task<IList<EmployeeDto>> GetAllEmployeesAsync();
    }
    public class EmployeeService : IEmployeeService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository,
                                    IUnitOfWork unitOfWork,
                                    IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<EmployeeDto>> GetAllEmployeesAsync()
        {
            var transaction = _unitOfWork.BeginTransaction();
            var employee = await _employeeRepository.GetAllEmployeesAsync();
            var results = _mapper.Map<List<EmployeeDto>>(employee);
            transaction.Commit();
            return results;
        }
    }
}