namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_BENEFICIOS_FAMILIA
    {
        [Key]
        public int PRV_ID_BENEFICIOS_FAMILIA { get; set; }

        public int PRV_ID_MEMBRO_FAMILIA { get; set; }

        public int PRV_ID_BENEFICIO { get; set; }

        public virtual PRV_BENEFICIOS PRV_BENEFICIOS { get; set; }

        public virtual PRV_CONSTITUICAO_FAMILIAR PRV_CONSTITUICAO_FAMILIAR { get; set; }
    }
}
