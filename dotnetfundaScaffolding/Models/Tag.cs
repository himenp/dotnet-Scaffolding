using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetfundaScaffolding.Models
{
    public class Tag
    {
        [Key]
        public Int64 TagId { get; set; }
        public string Tags { get; set; }
        public Int64 PostId { get; set; }
        public virtual Post Post { get; set; }

    }
}