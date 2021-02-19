using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Templete.Identity.Model
{
  public  class IdentityUser
    {
        [PersonalData]
        [Column(TypeName ="nvarchar(100)")]
        public string FirstName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
    }
}
