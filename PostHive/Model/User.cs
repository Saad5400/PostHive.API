using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PostHive.Model
{
    public class UserPostModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }
    public class User
    {
        [Key] 
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ValidateNever] 
        public List<Comment> Comments { get; set; } = new();

        [ValidateNever]
        public List<Post> Posts { get; set; } = new();

        public List<int> UpvotedPostsIds = new();
        public List<int> DownvotedPostsIds = new();

        public List<int> UpvotedCommentsIds = new();
        public List<int> DownvotedCommentsIds = new();

        public User(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
