using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SotnWiki.Models
{
    public class Run
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public string Runner { get; set; }

        public string Time { get; set; }

        public DateTime? Date { get; set; }

        public string Url { get; set; }

        public Category Category { get; set; }

        public Platform Platform { get; set; }
    }
}
