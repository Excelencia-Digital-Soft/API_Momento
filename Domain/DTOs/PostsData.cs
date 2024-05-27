

namespace Domain.DTOs
{
    public class PostsData
    {
        public int IdPublication { get; set; }

        public string Picture { get; set; } = null!;

        public string Text { get; set; } = null!;

        public byte[] PictureByte { get; set; } = null!;

        public DateTime CreationDate { get; set; }

        public string CreationDateString { get; set; } = null!;

        public string AgoDate { get; set; } = null!;

    }
}
