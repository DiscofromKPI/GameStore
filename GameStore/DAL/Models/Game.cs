using System.Collections;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Details { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}