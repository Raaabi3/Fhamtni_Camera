using System;
using System.Collections.Generic;

namespace CameraStreamingAPI.Models;

public partial class Device
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? DeviceName { get; set; }

    public string? DeviceType { get; set; }

    public virtual ICollection<Stream> Streams { get; set; } = new List<Stream>();

    public virtual User? User { get; set; }
}
