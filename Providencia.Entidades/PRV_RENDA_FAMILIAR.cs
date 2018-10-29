using System.ComponentModel;

namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_RENDA_FAMILIAR
    {
        [Key]
        public int PRV_ID_RENDA_FAMILIAR { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("RENDA FAMILIAR")]
        public string PRV_DESCRICAO_RENDA_FAMILIAR { get; set; }
    }
}
