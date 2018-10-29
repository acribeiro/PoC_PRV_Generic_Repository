using System.ComponentModel;

namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_UNIDADE
    {
        [Key]
        public int PRV_ID_UNIDADE { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("UNIDADE")]
        public string PRV_NOME_UNIDADE { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("CNPJ")]
        public string PRV_CNPJ_UNIDADE { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("CEP")]
        public string PRV_CEP_UNIDADE { get; set; }

        [Required]
        [StringLength(500)]
        [DisplayName("ENDEREÇO")]
        public string PRV_ENDEREÇO_UNIDADE { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("EMAIL")]
        public string PRV_EMAIL_UNIDADE { get; set; }

        [Required]
        [StringLength(16)]
        [DisplayName("TELEFONE")]
        public string PRV_TELEFONE_UNIDADE { get; set; }
    }
}
