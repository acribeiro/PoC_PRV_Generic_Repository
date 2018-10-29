namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_DESPESA_FAMILIAR
    {
        [Key]
        public int PRV_ID_DESPESA_FAMILIAR { get; set; }

        [Required]
        [StringLength(100)]
        public string PRV_DESCRICAO_DESPESA_FAMILIAR { get; set; }
    }
}
