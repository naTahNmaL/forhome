using AutoMapper;
using Common.UnitOfWork;
using PersistentLayer.Repositories;
using ServiceLayer.DTO;

namespace ServiceLayer.Services
{

    public interface IGroupService
    {
        Task<IList<GroupDto>> GetAllGroupsAsync();
    }
    public class GroupService : IGroupService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository groupRepository,
                                    IUnitOfWork unitOfWork,
                                    IMapper mapper)
        {
            _groupRepository = groupRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<GroupDto>> GetAllGroupsAsync()
        {
            var transaction = _unitOfWork.BeginTransaction();
            var groups = await _groupRepository.GetAllGroupsAsync();
            var groupDtos = _mapper.Map<List<GroupDto>>(groups);
            transaction.Commit();
            return groupDtos;


        }
    }

}