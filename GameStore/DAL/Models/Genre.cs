using System.Collections;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public Genre Parent { get; set; }
        public ICollection<Genre> Children { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}