using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestComASPNet.Model
{
    [Table("base_entity")]
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
