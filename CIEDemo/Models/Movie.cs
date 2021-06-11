using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CIEDemo.Models
{
    public class Movie
    {
        [Key]
        public long ID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }

        [Column(TypeName = "int")]
        public int YearReleased { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string ImagePath { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Runtime { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string IMDBLink { get; set; }
    }
}
