﻿using RPC.Model;

namespace RPC.Services
{
    public interface IUserService
    {
        Task<bool> UserCreate(UserModel user);
        Task<bool> UserLoggin(UserModel user);


    }
}