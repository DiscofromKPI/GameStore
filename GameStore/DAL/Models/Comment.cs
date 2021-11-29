
using System;
using System.Collections.Generic;


namespace DAL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public User Author { get; set; }
        public DateTime DateCreated { get; set; }
        public int? ParentId { get; set; }
        
        public Comment Parent { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}