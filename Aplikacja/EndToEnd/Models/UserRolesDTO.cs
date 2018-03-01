using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EndToEnd.Models
{
    public class ExpandedUserDTO
    {
        [Key]
        [Display(Name = "Użytkownik")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Hasło")]
        public string Password { get; set; }
        [Display(Name = "Data zakończenia blokady Utc")]
        public DateTime? LockoutEndDateUtc { get; set; }
        public int AccessFailedCount { get; set; }
        public string PhoneNumber { get; set; }
        [Display(Name = "Uprawnienia")]
        public IEnumerable<UserRolesDTO> Roles { get; set; }
    }

    public class UserRolesDTO
    {
        [Key]
        [Display(Name = "Uprawnienia")]
        public string RoleName { get; set; }
    }

    public class UserRoleDTO
    {
        [Key]
        [Display(Name = "Użytkownik")]
        public string UserName { get; set; }
        [Display(Name = "Uprawnienia")]
        public string RoleName { get; set; }
    }

    public class RoleDTO
    {
        [Key]
        public string Id { get; set; }
        [Display(Name = "Uprawnienia")]
        public string RoleName { get; set; }
    }

    public class UserAndRolesDTO
    {
        [Key]
        [Display(Name = "Użytkownik")]
        public string UserName { get; set; }
        public List<UserRoleDTO> colUserRoleDTO { get; set; }
    }
}