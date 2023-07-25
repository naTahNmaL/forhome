using AutoMapper;
using Common.Constants;
using Microsoft.Extensions.Localization;
using PersistentLayer.Domains;
using PersistentLayer.Repositories;
using ServiceLayer.DTO;

namespace ServiceLayer.ProfileMapper.Resolver
{
    public class GroupResolver : IValueResolver<BaseProjectDto, Project, Group>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IStringLocalizer<GroupResolver> _localizer;

        public GroupResolver()
        {
            // Parameterless constructor
        }
        public GroupResolver(IGroupRepository groupRepository,
             IStringLocalizer<GroupResolver> localizer)
        {
            _groupRepository = groupRepository;
            _localizer = localizer;
        }

        public Group Resolve(BaseProjectDto source, Project destination, Group destMember, ResolutionContext context)
        {
            var validGroup = _groupRepository.GetGroupById((int)source.GroupID);

            if (validGroup == null)
            {
                throw new Common.Exceptions.UserFriendlyException(_localizer[ErrorMessageConst.Group_Id_Invalid]);
            }

            return validGroup;
        }
    }
}
