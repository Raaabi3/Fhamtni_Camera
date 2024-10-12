using System;
using System.Collections.Generic;

namespace CameraStreamingAPI.Models;

public partial class Stream
{
    public int Id { get; set; }

    public int? DeviceId { get; set; }

    public string? StreamUrl { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Device? Device { get; set; }
}
