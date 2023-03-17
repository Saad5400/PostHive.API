using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PostHive.Model
{
    public class UserPostModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
    public class User
    {
        [Key] 
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Comment> Comments { get; set; } = new();

        public List<Post> Posts { get; set; } = new();

        public List<Post>? UpvotedPosts { get; set; } = new();
        public List<Post>? DownvotedPosts { get; set; } = new();

        public List<Comment>? UpvotedComments { get; set; } = new();
        public List<Comment>? DownvotedComments { get; set; } = new();

        public User(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
