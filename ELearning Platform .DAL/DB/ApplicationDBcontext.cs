﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Platform_.DAL.DB
{
    public class ApplicationDBcontext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
        {


        }
    }
}