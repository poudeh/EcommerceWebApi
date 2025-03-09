using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users;

public class UserDomainService:IDomainUserService
{
    private readonly IUserRepository _userRepository;

    public UserDomainService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public bool IsEmailExist(string email)
    {
        return _userRepository.Exists(x => x.Email == email);
    }

    public bool PhoneNumberIsExist(string phoneNumber)
    {
        return _userRepository.Exists(x => x.PhoneNumber == phoneNumber);
    }
}