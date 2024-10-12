namespace CameraStreamingAPI.DTOs
{
    public class StreamDto
    {
        public int Id { get; set; }

        public int? DeviceId { get; set; }

        public string? StreamUrl { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }

    }
}
