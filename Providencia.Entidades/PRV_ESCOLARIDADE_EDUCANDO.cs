using System.ComponentModel;

namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_ESCOLARIDADE_EDUCANDO
    {
        [Key]
        public int PRV_ID_DADOS_ESCOLARIDADE_EDUCANDO { get; set; }

        public int PRV_ID_EDUCANDO { get; set; }

        [DisplayName("SÉRIE")]
        public int PRV_SERIE_ESCOLARIDADE_EDUCANDO { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("ENSINO")]
        public string PRV_ENSINO { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("TURNO")]
        public string PRV_TURNO { get; set; }

        [Required]
        [StringLength(1)]
        [DisplayName("REPETINDO SÉRIE ATUAL")]
        public string PRV_REPETINDO_SERIE_ATUAL { get; set; }

        public virtual PRV_EDUCANDO PRV_EDUCANDO { get; set; }
    }
}
