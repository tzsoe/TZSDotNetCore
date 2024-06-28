using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Models;

[Table("UserRegistration")]
public class UserRegistrationModel
{
    [Key]
    public int UserID { get; set; }
    public string? FirstName { get; set; } 
    public string? LastName { get; set; }
    public string? Contact { get; set; }
    public string? Gender { get; set; }
    public string? Address { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
}

