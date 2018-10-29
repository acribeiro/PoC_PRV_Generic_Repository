using System.ComponentModel;

namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_GRUPO_TERAPEUTICO
    {
        [Key]
        public int PRV_ID_GRUPO_TERAPEUTICO { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("NOME DO GRUPO")]
        public string PRV_NOME_GRUPO_TERAPEUTICO { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("ENDEREÇO")]
        public string PRV_ENDEREÇO_GRUPO_TERAPEUTICO { get; set; }
    }
}
