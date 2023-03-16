using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PostHive.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        [ValidateNever]
        public User Author { get; set; }

        [Required]
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        [ValidateNever]
        public Post Post { get; set; }

        public int? RepliedToCommentId { get; set; }
        [ForeignKey("RepliedToCommentId")]
        [ValidateNever]
        public Comment RepliedToComment { get; set; }

        public List<Comment>? Replies { get; set; }
    }
}