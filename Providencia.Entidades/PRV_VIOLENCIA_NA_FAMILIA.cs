namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_VIOLENCIA_NA_FAMILIA
    {
        [Key]
        public int PRV_ID_VIOLENCIA_NA_FAMILIA { get; set; }

        [Required]
        [StringLength(1)]
        public string PRV_SOFREU_VIOLENCIA { get; set; }

        public int PRV_ID_MEMBRO_FAMILIA_SOFREU_VIOLENCIA { get; set; }

        [StringLength(1000)]
        public string PRV_MEDIDAS_TOMADAS { get; set; }

        [Required]
        [StringLength(1)]
        public string PRV_ACIONOU_AUTORIDADES { get; set; }

        public virtual PRV_CONSTITUICAO_FAMILIAR PRV_CONSTITUICAO_FAMILIAR { get; set; }
    }
}
