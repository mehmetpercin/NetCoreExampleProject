using AutoMapper;
using Business.Interfaces;
using Core.Models;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<Response<AppUserDto>> CreateUserAsync(AppUserCreateDto userCreateDto)
        {
            var user = new AppUser { Email = userCreateDto.Email, UserName = userCreateDto.UserName };

            var result = await _userManager.CreateAsync(user, userCreateDto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return Response<AppUserDto>.Fail(errors, 400);
            }

            var response = _mapper.Map<AppUserDto>(user);
            return Response<AppUserDto>.Success(response, 200);
        }
    }
}
