using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Title { get; set; }
        [Required]
        [StringLength(20)]
        public string Author { get; set; }

    }
}
