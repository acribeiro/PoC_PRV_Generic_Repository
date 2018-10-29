using System.ComponentModel;

namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_USUARIO
    {
        [Key]
        public int PRV_ID_USUARIO { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("NOME")]
        public string PRV_NOME_USUARIO { get; set; }

        [StringLength(30)]
        [DisplayName("CPF")]
        public string PRV_CPF_USUARIO { get; set; }

        [DisplayName("DATA DE NASCIMENTO")]
        public DateTime PRV_DATA_NASCIMENTO { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("EMAIL")]
        public string PRV_EMAIL_USUARIO { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("LOGIN")]
        public string PRV_LOGIN_USUARIO { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("SENHA")]
        public string PRV_SENHA_USUARIO { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("CARGO")]
        public string PRV_CARGO_USUARIO { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("SETOR/ÁREA")]
        public string PRV_SETOR_AREA_USUARIO { get; set; }
    }
}
