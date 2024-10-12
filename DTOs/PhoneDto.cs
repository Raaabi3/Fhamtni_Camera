using System;
using System.Collections.Generic;

namespace CameraStreamingAPI.DTOs
{
    public class PhoneDto
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public string? Number { get; set; }

        public string? Type { get; set; }

    }
}