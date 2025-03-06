﻿using API.Inventory.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Inventory.CORE.Services.Interface
{
    public interface IUserService
    {
        Task<ResponseModel> GetAllUsers();
    }
}
