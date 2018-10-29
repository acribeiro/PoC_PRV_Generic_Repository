using System.ComponentModel;

namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_DADOS_ESCOLARES_FAMILIA
    {
        [Key]
        public int PRV_ID_DADOS_ESCOLARES_FAMILIA { get; set; }

        [DisplayName("MEMBRO FAMÍLIA")]
        [InverseProperty("MEMBRO FAMÍLIA")]
        public int PRV_ID_MEMBRO_FAMILIA { get; set; }

        [DisplayName("ESCOLARIDADE")]
        public int PRV_ID_ESCOLARIDADE { get; set; }

        public virtual PRV_CONSTITUICAO_FAMILIAR PRV_CONSTITUICAO_FAMILIAR { get; set; }

        public virtual PRV_ESCOLARIDADE PRV_ESCOLARIDADE { get; set; }
    }
}
