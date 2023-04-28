using AutoMapper;
using NetcoreCrudBaseApi.Domains.Dtos.Permissions;
using NetcoreCrudBaseApi.Domains.Entities;
using NetcoreCrudBaseApi.Domains.Repositories;

namespace NetcoreCrudBaseApi.Domains.Services;

public class PermissionService : ICrudService<CreatePermissionDto, UpdatePermissionDto, ReadPermissionDto>
{
    private IMapper _mapper;
    private readonly IPermissionRepository _repository;

    public PermissionService(IMapper mapper, IPermissionRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public long Create(CreatePermissionDto dto)
    {
        var reference = _mapper.Map<PermissionEntity>(dto);
        return _repository.Create(reference);
    }

    public ReadPermissionDto? Read(long id)
    {
        var reference = _repository.Read(id);
        return reference == null ? null : _mapper.Map<ReadPermissionDto>(reference);
    }

    public bool Update(long id, UpdatePermissionDto dto)
    {
        RootValidationService.VerifyRootPermission(id);

        var reference = _repository.Read(id);
        if (reference == null) return false;

        reference.UpdatedAt = DateTime.Now;
        reference = _mapper.Map(dto, reference);
        return _repository.Update(reference);
    }

    public IEnumerable<ReadPermissionDto> Search(int skip, int take)
    {
        var reference = _repository.Search(skip, take);
        return _mapper.Map<IEnumerable<ReadPermissionDto>>(reference);
    }

    public bool Delete(long id)
    {
        RootValidationService.VerifyRootPermission(id);
        
        if (!_repository.ExistsById(id)) return false;

        return _repository.Delete(id);
    }

    public bool ExistsById(long id)
    {
        return _repository.ExistsById(id);
    }
}
