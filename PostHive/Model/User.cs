using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PostHive.Model
{
    public class User
    {
        [Key] 
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ValidateNever] public List<Comment> Comments { get; set; } = new();

        [ValidateNever]
        public List<Post> Posts { get; set; } = new();

        public List<int> UpvotedPostsIds = new();
        public List<int> DownvotedPostsIds = new();

        public List<int> UpvotedCommentsIds = new();
        public List<int> DownvotedCommentsIds = new();
    }
}
