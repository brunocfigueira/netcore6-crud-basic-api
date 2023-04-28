using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetcoreCrudBaseApi.Domains.Context;
using NetcoreCrudBaseApi.Domains.Dtos.ProfilePermission;
using NetcoreCrudBaseApi.Domains.Dtos.Users;
using NetcoreCrudBaseApi.Domains.Entities;
using NetcoreCrudBaseApi.Domains.Repositories;
using NetcoreCrudBaseApi.Infrastructure.Exceptions;
using NetcoreCrudBaseApi.Infrastructure.Responses;

namespace NetcoreCrudBaseApi.Domains.Services;

public class ProfilePermissionService : ICrudService<CreateProfilePermissionDto, UpdateProfilePermissionDto, ReadProfilePermissionDto>
{
    private IMapper _mapper;
    private readonly IProfilePermissionRepository _repository;
    private readonly ProfileService _profileService;
    private readonly PermissionService _permissionService;

    public ProfilePermissionService(IMapper mapper, IProfilePermissionRepository repository, ProfileService profileService, PermissionService permissionService)
    {
        _mapper = mapper;
        _repository = repository;
        _profileService = profileService;
        _permissionService = permissionService;
    }
    private void ApplyRootRuleValidation(long profileId, ICollection<long> permissionIds, bool isDelete = false)
    {
        RootValidationService.VerifyRootProfile(profileId);

        if (!_profileService.IsProfileActivitided(profileId))
        {
            throw RuleViolationException.EmitMessage(ResponseErrors.MsgViolationProfileIdPermission);
        }

        if (!isDelete)
        {
            foreach (var id in permissionIds)
            {
                RootValidationService.VerifyRootPermission(id);
                if (!_permissionService.ExistsById(id))
                {
                    throw RuleViolationException.EmitMessage(ResponseErrors.MsgViolationPermissionId);
                }
            }
        }
    }

    private void ApplyRuleOnCreate(long profileId, ICollection<long> permissionIds)
    {
        ApplyRootRuleValidation(profileId, permissionIds);

        if (ExistsPermissionsByProfileId(profileId))
        {
            throw RuleViolationException.EmitMessage(ResponseErrors.MsgHasProfilePermissions);
        }

    }
    private bool ExistsPermissionsByProfileId(long profileId)
    {
        return _repository.ExistsPermissionsByProfileId(profileId);
    }
    private void SaveProfilePermissions(long profileId, ICollection<long> permissions)
    {
        var references = new List<ProfilePermissionEntity>();
        foreach (var permissionId in permissions)
        {
            var item = new ProfilePermissionEntity
            {
                ProfileId = profileId,
                PermissionId = permissionId
            };
            references.Add(item);
        }
        _repository.SaveProfilePermissions(references);
    }
    private void DeleteProfilePermissions(long profileId)
    {
        _repository.DeleteProfilePermissions(profileId);
    }
    public long Create(CreateProfilePermissionDto dto)
    {
        ApplyRuleOnCreate(dto.ProfileId, dto.PermissionIds);
        SaveProfilePermissions(dto.ProfileId, dto.PermissionIds);
        return dto.ProfileId;
    }

    public ReadProfilePermissionDto? Read(long id)
    {
        return null;
    }

    public IEnumerable<ReadProfilePermissionDto>? ReadByProfileId(long profileId)
    {
        var reference = _repository.ReadByProfileId(profileId);
        return reference == null ? null : _mapper.Map<IEnumerable<ReadProfilePermissionDto>>(reference);
    }

    public bool Update(long profileId, UpdateProfilePermissionDto dto)
    {
        ApplyRootRuleValidation(profileId, dto.PermissionIds);
        DeleteProfilePermissions(profileId);
        SaveProfilePermissions(profileId, dto.PermissionIds);
        return true;
    }

    public IEnumerable<ReadProfilePermissionDto> Search(int skip, int take)
    {
        var reference = _repository.Search(skip, take); 
        return _mapper.Map<IEnumerable<ReadProfilePermissionDto>>(reference);
    }

    public bool Delete(long profileId)
    {
        ApplyRootRuleValidation(profileId, null, isDelete: true);
        DeleteProfilePermissions(profileId);
        return true;
    }
}
