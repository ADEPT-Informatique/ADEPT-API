using ADEPT_API.DATACONTRACTS.Dto.Users.Enums;
using Microsoft.AspNetCore.Authorization;
using System;

namespace ADEPT_API.LIBRARY.Security.Handlers
{
  [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
  public class RolesAttribute : AuthorizeAttribute
  {
    public string RoleName { get; set; }

    public RolesAttribute(Roles roles) : base("Roles")
    {
      this.RoleName = roles.ToString();
    }
  }
}
