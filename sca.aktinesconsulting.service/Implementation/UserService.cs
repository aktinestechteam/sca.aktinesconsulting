﻿using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.repository.Interface;
using sca.aktinesconsulting.service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPermissionRepository _permissionRepository;
        public UserService(IUserRepository userRepository, IPermissionRepository permissionRepository)
        {
            _userRepository = userRepository;
            _permissionRepository = permissionRepository;
        }
        public async Task<User> Validate(string email, string password)
        {
            return await _userRepository.Validate(email, password);
        }
        public async Task<IList<UserPermission>> GetPermissions(int userId)
        {
            return await _permissionRepository.GetByUserId(userId);
        }
    }
}
