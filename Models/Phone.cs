using System;
using System.Collections.Generic;

namespace CameraStreamingAPI.Models;

public partial class Phone
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Number { get; set; }

    public string? Type { get; set; }

    public virtual User? User { get; set; }
}
