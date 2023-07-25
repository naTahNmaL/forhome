using AutoMapper;
using Common.Constants;
using Microsoft.Extensions.Localization;
using PersistentLayer.Domains;
using PersistentLayer.Repositories;
using ServiceLayer.DTO;

namespace ServiceLayer.ProfileMapper.Resolver
{
    public class EmployeeResolver : IValueResolver<BaseProjectDto, Project, IList<Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IStringLocalizer<EmployeeResolver> _localizer;

        public EmployeeResolver(IEmployeeRepository employeeRepository,
            IStringLocalizer<EmployeeResolver> localizer)
        {
            _employeeRepository = employeeRepository;
            _localizer = localizer;
        }

        public IList<Employee> Resolve(BaseProjectDto source, Project destination, IList<Employee> destMember, ResolutionContext context)
        {
            var employees = _employeeRepository.GetAllEmployeeByVisasAsync(source.Employees).Result;

            // Find the invalid visas
            var invalidVisas = source.Employees.Except(employees.Select(e => e.Visa));
            if (invalidVisas.Any())
            {
                //Get the error message from the resource file
                var errorMessage = _localizer[ErrorMessageConst.Visas_Are_Not_Existed, string.Join(", ", invalidVisas)];

                throw new Common.Exceptions.UserFriendlyException(errorMessage);
            }

            return employees;
        }
    }
}
