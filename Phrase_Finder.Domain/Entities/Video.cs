using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phrase_Finder.Domain.Entities
{
    public class Video
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Subtitles { get; set; }
        public string YouTubeVideoId { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Video);
        }

        public bool Equals(Video video)
        {
            return Id == video.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, YouTubeVideoId);
        }
    }
}
