using AutoMapper;
using StudentsData.Application.Interfaces;
using StudentsData.Application.ViewModels;
using StudentsData.Application.ViewModels.Create;
using StudentsData.Application.ViewModels.Edit;
using StudentsData.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsData.Application.Services
{
    public class GroupService : IGroupService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public GroupService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }


        public async Task<string> CreateGroup(GroupCreateViewModel model)
        {
            return await unitOfWork.Groups.CreateAsync(new Domain.Models.Group
            {
                Name = model.Name,
                DateStartEdu = model.DateStartEdu,
                DateEndEdu = model.DateEndEdu
            });
        }

        public async Task<string> EditGroup(GroupEditViewModel model)
        {
            var group = await unitOfWork.Groups.GetByWhereAsTrackingAsync(d => d.Id == model.Id);
            if (group == null) return null;
            group.Name = model.Name;
            group.DateStartEdu = model.DateStartEdu;
            group.DateEndEdu = model.DateEndEdu;
            return await unitOfWork.Groups.EditAsync(group);
        }

        public async Task<List<GroupViewModel>> GetAllGroups()
        {
            return mapper.Map<List<GroupViewModel>>(await unitOfWork.Groups.GetAllAsync());
        }

        public async Task<GroupViewModel> GetGroupById(int Id)
        {
            return mapper.Map<GroupViewModel>(await unitOfWork.Groups.GetByWhereAsync(d => d.Id == Id));
        }

        public async Task<GroupViewModel> GetGroupByIdWithStudents(int Id)
        {
            return mapper.Map<GroupViewModel>(await unitOfWork.Groups.GetByGroupWithStudentsAsync(Id));
        }

        public async Task<string> RemoveGroup(int Id)
        {
            var group = await unitOfWork.Groups.GetByWhereAsTrackingAsync(d => d.Id == Id);
            if (group == null) return "Null";
            return await unitOfWork.Groups.RemoveAsync(group);
        }

        public async Task<List<GroupViewModel>> SearchGroups(string name)
        {
            return mapper.Map<List<GroupViewModel>>(await unitOfWork.Groups.SearchGroupsAsync(name));
        }
    }
}