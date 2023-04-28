using AutoMapper;
using NetcoreCrudBaseApi.Domains.Dtos.Users;
using NetcoreCrudBaseApi.Domains.Entities;
using NetcoreCrudBaseApi.Domains.Repositories;
using NetcoreCrudBaseApi.Infrastructure.Exceptions;
using NetcoreCrudBaseApi.Infrastructure.Responses;
using Bcrypt = BCrypt.Net.BCrypt;

namespace NetcoreCrudBaseApi.Domains.Services
{
    public class UserService : ICrudService<CreateUserDto, UpdateUserDto, ReadUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;
        private readonly ProfileService _profileService;

        public UserService(IMapper mapper, IUserRepository repository, ProfileService profileService)
        {
            _mapper = mapper;
            _repository = repository;
            _profileService = profileService;
        }

        private void ApplyRuleValidation(long profileId)
        {
            if (RootValidationService.IsRootProfile(profileId) || !_profileService.IsProfileActivitided(profileId))
            {
                throw RuleViolationException.EmitMessage(ResponseErrors.MsgViolationUserProfileId);
            }
        }

        private string CreateHashPassword(string password)
        {
            return Bcrypt.HashPassword(password);
        }
        private bool VerifyPassword(string password, string hashUserPassword)
        {
            return Bcrypt.Verify(password, hashUserPassword);
        }

        public long Create(CreateUserDto dto)
        {
            ApplyRuleValidation(dto.ProfileId);
            dto.Password = CreateHashPassword(dto.Password);
            var reference = _mapper.Map<UserEntity>(dto);
            return _repository.Create(reference);
        }

        public ReadUserDto? Read(long id)
        {
            var reference = _repository.Read(id);
            return reference == null ? null : _mapper.Map<ReadUserDto>(reference);
        }

        public bool Update(long id, UpdateUserDto dto)
        {
            RootValidationService.VerifyRootUser(id);
            ApplyRuleValidation(dto.ProfileId);
            var reference = _repository.Read(id);
            if (reference == null) return false;

            reference.UpdatedAt = DateTime.Now;
            reference = _mapper.Map(dto, reference);
            return _repository.Update(reference);
        }
        public bool ChangePassword(long id, ChangePasswordUserDto dto)
        {
            RootValidationService.VerifyRootUser(id);
            var reference = _repository.Read(id);
            if (reference == null) return false;

            reference.Password = CreateHashPassword(dto.NewPassword);
            return _repository.Update(reference);
        }

        public IEnumerable<ReadUserDto> Search(int skip, int take)
        {
            var reference = _repository.Search(skip, take);
            return _mapper.Map<IEnumerable<ReadUserDto>>(reference);
        }

        public bool Delete(long id)
        {
            RootValidationService.VerifyRootUser(id);

            if (!_repository.ExistsById(id)) return false;

            return _repository.Delete(id);
        }

        public UserEntity? GetUserByLoginAndPassword(string login, string password)
        {
            var user = _repository.GetUserByLoginAndPassword(login, password);
            if (user == null) return null;
            return VerifyPassword(password, user.Password) ? user : null;
        }
    }
}
