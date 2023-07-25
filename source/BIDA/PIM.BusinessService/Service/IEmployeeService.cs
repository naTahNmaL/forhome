using PIM.BusinessService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIM.BusinessService.Service
{
    public interface IEmployeeService
    {
        Task<IList<EmployeeModel>> GetAllAsync();
        Task<EmployeeModel> GetByIdAsync(Guid id);
        Task CreateAsync(EmployeeModel employee);
        Task UpdateAsync(EmployeeModel employee);
        Task DeleteAsync(Guid id);
    }
}