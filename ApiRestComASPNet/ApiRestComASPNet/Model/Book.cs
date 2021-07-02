using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestComASPNet.Model
{
    [Table("books")]
    public class Book
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("book_name")]
        public string BookName { get; set; }
        [Column("writter")]
        public string Writter { get; set; }
        [Column("type_book")]
        public string TypeBook { get; set; }
    }
}
