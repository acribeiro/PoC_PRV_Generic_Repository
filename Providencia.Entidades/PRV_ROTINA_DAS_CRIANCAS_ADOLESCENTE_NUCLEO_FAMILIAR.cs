using System.ComponentModel;

namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR
    {
        [Key]
        public int PRV_ID_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR { get; set; }

        [Required]
        [StringLength(1000)]
        [DisplayName("ROTINA")]
        public string DESCRICAO_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR { get; set; }

        [DisplayName("EDUCANDO")]
        public int? FK_ID_EDUCANDO_ROTINA { get; set; }

        [DisplayName("EDUCANDO")]
        public virtual PRV_EDUCANDO PRV_EDUCANDO { get; set; }
    }
}
