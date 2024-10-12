using System;
using System.Collections.Generic;

namespace CameraStreamingAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Token { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public string? Number { get; set; }

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();

    public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();
}
