using AutoMapper;
using NetcoreCrudBaseApi.Domains.Dtos.Profiles;
using NetcoreCrudBaseApi.Domains.Entities;
using NetcoreCrudBaseApi.Domains.Repositories;

namespace NetcoreCrudBaseApi.Domains.Services
{
    public class ProfileService : ICrudService<CreateProfileDto, UpdateProfileDto, ReadProfileDto>
    {
        private readonly IMapper _mapper;
        private readonly IProfileReporitory _repository;

        public ProfileService(IMapper mapper, IProfileReporitory repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public long Create(CreateProfileDto dto)
        {
            var reference = _mapper.Map<ProfileEntity>(dto);
            return _repository.Create(reference);
        }

        public ReadProfileDto? Read(long id)
        {
            var reference = _repository.Read(id);
            return reference == null ? null : _mapper.Map<ReadProfileDto>(reference);
        }
        public bool Update(long id, UpdateProfileDto dto)
        {
            RootValidationService.VerifyRootProfile(id);

            var reference = _repository.Read(id);
            if (reference == null) return false;

            reference.UpdatedAt = DateTime.Now;
            reference = _mapper.Map(dto, reference);
            return _repository.Update(reference);
        }

        public IEnumerable<ReadProfileDto> Search(int skip, int take)
        {
            var reference = _repository.Search(skip, take);
            return _mapper.Map<IEnumerable<ReadProfileDto>>(reference);
        }

        public bool Delete(long id)
        {
            RootValidationService.VerifyRootProfile(id);

            if (!_repository.ExistsById(id)) return false;

            return _repository.Delete(id);
        }

        public virtual bool IsProfileActivitided(long id)
        {
            return _repository.IsProfileActivitided(id);
        }

    }
}
