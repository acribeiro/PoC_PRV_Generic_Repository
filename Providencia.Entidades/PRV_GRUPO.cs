using System.ComponentModel;

namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_GRUPO
    {
        [Key]
        public int PRV_ID_GRUPO { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("GRUPO")]
        public string PRV_NOME_GRUPO { get; set; }
    }
}
