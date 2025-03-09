using AutoMapper;
using Common.AspNetCore;
using Common.Domain.ValueObject;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.Users;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;
using Shop.Application.Users.SetActiveAddress;
using Shop.Domain.UserAgg;
using Shop.Presentation.Facade.Users.Addresses;
using Shop.Query.Users.DTOs;

namespace Shop.Api.Controllers;

public class UserAddressController:ApiController
{
    private readonly IUserAddressFacade _addressFacade;
    private readonly IMapper _mapper;

    public UserAddressController(IUserAddressFacade addressFacade, IMapper mapper)
    {
        _addressFacade = addressFacade;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ApiResult<List<AddressDto>>> GetList()
    {
        var result = await _addressFacade.GetList(User.GetUserId());
        return QueryResult(result);
    }

    [HttpGet("{id}")]
    public async Task<ApiResult<AddressDto?>> GetById(long id)
    {
        var result = await _addressFacade.GetById(id);
        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult> AddAddress(AddUserAddressViewModel viewModel)
    {
        var command = _mapper.Map<AddUserAddressCommand>(viewModel);
        var result = await _addressFacade.AddAddress(command);
        return CommandResult(result);
    }

    [HttpDelete("{addressId}")]
    public async Task<ApiResult> Delete(long addressId)
    {
        var result = await _addressFacade.DeleteAddress(new DeleteUserAddressCommand(User.GetUserId(), addressId));
        return CommandResult(result);

    }

    [HttpPut]
    public async Task<ApiResult> Edit(EditUserAddressViewModel viewModel)
    {
        var command = new EditUserAddressCommand(viewModel.Shire, viewModel.City, viewModel.PostalCode,
            viewModel.PostalAddress, new PhoneNumber(viewModel.PhoneNumber), viewModel.Name,
            viewModel.Family, viewModel.NationalCode, User.GetUserId(), viewModel.Id);

        command.UserId = User.GetUserId();
        var result = await _addressFacade.EditAddress(command);
        return CommandResult(result);
    }

    [HttpPut("SetActiveAddress/{addressId}")]
    public async Task<ApiResult> SetAddressActive(long addressId)
    {
        var command = new SetActiveUserAddressCommand(User.GetUserId(), addressId);

        var result = await _addressFacade.SetActiveAddress(command);
        return CommandResult(result);
    }
}