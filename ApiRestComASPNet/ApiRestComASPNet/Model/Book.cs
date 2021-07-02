using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestComASPNet.Model
{
    [Table("books")]
    public class Book : BaseEntity
    {

        [Column("book_name")]
        public string BookName { get; set; }
        [Column("writter")]
        public string Writter { get; set; }
        [Column("type_book")]
        public string TypeBook { get; set; }
    }
}
