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
    public class GroupService : IGroupService
    {
        private IGroupRepository _groupRepository;
        private readonly IUnitOfWork _unitOfWork;
        private static MapperConfiguration _config = new MapperConfiguration(cfg =>
                                                        {
                                                            cfg.AddProfile(new MappingProfile());
                                                        });
        private IMapper _mapper;
        public GroupService(IGroupRepository groupRepository, IUnitOfWork unitOfWork)
        {
            _groupRepository = groupRepository;
            _unitOfWork = unitOfWork;
            _mapper = _config.CreateMapper();
        }

        public async Task<IList<GroupModel>> GetAllAsync()
        {
            _unitOfWork.BeginTransaction();
            var groupListFromRepo = await _groupRepository.GetAllAsync();
            _unitOfWork.Commit();
            var groupList = _mapper.Map<IList<Group>, List<GroupModel>>(groupListFromRepo);
            return groupList;
        }

        public async Task<GroupModel> GetByIdAsync(Guid id)
        {
            _unitOfWork.BeginTransaction();
            var groupFromRepo = await _groupRepository.GetByIdAsync(id);
            _unitOfWork.Commit();
            return _mapper.Map<Group, GroupModel>(groupFromRepo);
        }

        public async Task CreateAsync(GroupModel group)
        {
            _unitOfWork.BeginTransaction();
            await _groupRepository.CreateAsync(_mapper.Map<GroupModel, Group>(group));
            _unitOfWork.Commit();
        }

        public async Task UpdateAsync(GroupModel group)
        {
            _unitOfWork.BeginTransaction();
            await _groupRepository.UpdateAsync(_mapper.Map<GroupModel, Group>(group));
            _unitOfWork.Commit();
        }

        public async Task DeleteAsync(Guid id)
        {
            _unitOfWork.BeginTransaction();
            await _groupRepository.DeleteAsync(id);
            _unitOfWork.Commit();
        }
    }
}