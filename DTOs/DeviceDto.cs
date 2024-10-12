namespace CameraStreamingAPI.DTOs
{
    public class DeviceDto
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public string? DeviceName { get; set; }

        public string? DeviceType { get; set; }

        public virtual ICollection<Stream> Streams { get; set; } = new List<Stream>();
    }


}
