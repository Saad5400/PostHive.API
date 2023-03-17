﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PostHive.Model
{
    public class PostPostModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorId { get; set; }

    }
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int Score { get; set; } = 0;

        public string? AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        [ValidateNever]
        public User? Author { get; set; }

        [ValidateNever] 
        public List<Comment> Comments { get; set; } = new();

        public Post(string title, string content, string authorId)
        {
            Title = title;
            Content = content;
            AuthorId = authorId;
        }
    }
}
