using AutoMapper;
using PIM.BusinessService.Mapper;
using PIM.BusinessService.Models;
using PIM.DataAccess.Entity;
using PIM.DataAccess.Repository;
using PIM.DataAccess.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIM.BusinessService.Service
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private static MapperConfiguration _config = new MapperConfiguration(cfg =>
                                                        {
                                                            cfg.AddProfile(new MappingProfile());
                                                        });
        private IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
            _mapper = _config.CreateMapper();
        }

        public async Task<IList<EmployeeModel>> GetAllAsync()
        {
            _unitOfWork.BeginTransaction();
            var employeeListFromRepo = await _employeeRepository.GetAllAsync();
            _unitOfWork.Commit();
            var employeeList = _mapper.Map<IList<Employee>, List<EmployeeModel>>(employeeListFromRepo);
            return employeeList;
        }

        public async Task<EmployeeModel> GetByIdAsync(Guid id)
        {
            _unitOfWork.BeginTransaction();
            var employeeFromRepo = await _employeeRepository.GetByIdAsync(id);
            _unitOfWork.Commit();
            return _mapper.Map<Employee, EmployeeModel>(employeeFromRepo);
        }

        public async Task CreateAsync(EmployeeModel employee)
        {
            _unitOfWork.BeginTransaction();
            await _employeeRepository.CreateAsync(_mapper.Map<EmployeeModel, Employee>(employee));
            _unitOfWork.Commit();
        }

        public async Task UpdateAsync(EmployeeModel employee)
        {
            _unitOfWork.BeginTransaction();
            await _employeeRepository.UpdateAsync(_mapper.Map<EmployeeModel, Employee>(employee));
            _unitOfWork.Commit();
        }

        public async Task DeleteAsync(Guid id)
        {
            _unitOfWork.BeginTransaction();
            await _employeeRepository.DeleteAsync(id);
            _unitOfWork.Commit();
        }
    }
}