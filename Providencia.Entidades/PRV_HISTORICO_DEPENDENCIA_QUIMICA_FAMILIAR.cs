using System.ComponentModel;

namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR
    {
        [Key]
        public int PRV_ID_HISTORICO_DEPENDENCIA { get; set; }

        [Required]
        [StringLength(1)]
        [DisplayName("EXISTE HISTÓRICO?")]
        public string PRV_EXISTE_HISTORICO_DEPENDENCIA { get; set; }

        public int PRV_ID_MEMBRO_FAMILIA { get; set; }

        [StringLength(1)]
        [DisplayName("FEZ TRATAMENTO?")]
        public string PRV_FEZ_TRATAMENTO { get; set; }

        [StringLength(100)]
        [DisplayName("LOCAL DO TRATAMENTO?")]
        public string PRV_LOCAL_TRATAMENTO { get; set; }

        [StringLength(50)]
        [DisplayName("TEMPO DE TRATAMENTO?")]
        public string PRV_TEMPO_TRATAMENTO { get; set; }

        [StringLength(1)]
        [DisplayName("FAZ USO DE MEDICAMENTO?")]
        public string PRV_FAZ_USO_MEDICAMENTO { get; set; }

        [StringLength(200)]
        [DisplayName("NOME MEDICAMENTO")]
        public string PRV_NOME_MEDICAMENTO { get; set; }

        public virtual PRV_CONSTITUICAO_FAMILIAR PRV_CONSTITUICAO_FAMILIAR { get; set; }
    }
}
