using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnetfundaScaffolding.Models
{
    public class Post
    {
        public Post()
        {
            this.Tags = new HashSet<Tag>();
        }
        [Key]
        public Int64 PostId { get; set; }

        public string Author { get; set; }

        [Required]
        public string Title { get; set; }

        public string Content { get; set; }
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }
        [ScaffoldColumn(false)]
        public DateTime LastmodifiedDate { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}