using Common.Query;
using Shop.Domain.RoleAgg.enums;
using Shop.Infrastructure;
using Shop.Query.Roles.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shop.Query.Roles.DTOs
{
    public class RoleDto : BaseDto
    {
        public string Title { get; set; }
        public List<Permission> Permissions { get; set; }
    }


   
    
}
