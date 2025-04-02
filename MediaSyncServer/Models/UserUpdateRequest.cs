using System.ComponentModel.DataAnnotations;

namespace MediaSyncServer.Models;

public class UserUpdateRequest
{
    [Required]
    public string _id { get; set; }

    [Required]
    public string UserName { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    public string Phone { get; set; }
}
