using System.ComponentModel;

namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_MORADORES_RESIDENCIA_EDUCANDO
    {
        [Key]
        public int PRV_ID_MORADORES_RESIDENCIA_EDUCANDO { get; set; }

        public int PRV_ID_MEMBRO_FAMILIA { get; set; }

        [Required]
        [StringLength(1)]
        [DisplayName("VACINAÇÃO EM DIA?")]
        public string PRV_VACINACAO_EM_DIA { get; set; }

        [Required]
        [StringLength(1)]
        [DisplayName("POSSUI ACOMPANHAMENTO MÉDICO?")]
        public string PRV_POSSUI_ACOMPANHAMENTO_MEDICO { get; set; }

        [Required]
        [StringLength(500)]
        [DisplayName("ACOMPANHAMENTO MÉDICO")]
        public string PRV_DESCRIACAO_POSSUI_ACOMPANHAMENTO_MEDICO { get; set; }

        [Required]
        [StringLength(1)]
        [DisplayName("PARTICIPA DO PROJETO?")]
        public string PRV_PARTICIPA_DO_PROJETO { get; set; }

        [Required]
        [StringLength(500)]
        [DisplayName("DESCRIÇÃO PARTICIPAÇÃO NO PROJETO?")]
        public string PRV_DESCRIACAO_PARTICIPA_DO_PROJETO { get; set; }

        public virtual PRV_CONSTITUICAO_FAMILIAR PRV_CONSTITUICAO_FAMILIAR { get; set; }
    }
}
