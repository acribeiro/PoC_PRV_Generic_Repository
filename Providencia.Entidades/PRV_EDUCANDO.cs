using System.ComponentModel;

namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_EDUCANDO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRV_EDUCANDO()
        {
            PRV_CONSTITUICAO_FAMILIAR = new HashSet<PRV_CONSTITUICAO_FAMILIAR>();
            PRV_MORADIA = new HashSet<PRV_MORADIA>();
            PRV_ESCOLARIDADE_EDUCANDO = new HashSet<PRV_ESCOLARIDADE_EDUCANDO>();
            PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR = new HashSet<PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR>();
        }

        [Key]
        public int PRV_ID_EDUCANDO { get; set; }

        [StringLength(100)]
        [DisplayName("EDUCANDO")]
        public string PRV_NOME_EDUCANDO { get; set; }

        public DateTime PRV_DATA_NASCIMENTO_EDUCANDO { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("RESPONSÁVEL")]
        public string PRV_NOME_RESPONSAVEL { get; set; }

        [StringLength(14)]
        [DisplayName("TELEFONE DO RESPONSÁVEL")]
        public string PRV_TELEFONE_RESPONSAVEL { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("NOME DA MÃE")]
        public string PRV_NOME_MAE { get; set; }

        [StringLength(14)]
        [DisplayName("TELEFONE DA MÃE")]
        public string PRV_TELEFONE_MAE { get; set; }

        [StringLength(100)]
        [DisplayName("NOME DO PAI")]
        public string PRV_NOME_PAI { get; set; }

        [StringLength(14)]
        [DisplayName("TELEFONE DO PAI")]
        public string PRV_TELEFONE_PAI { get; set; }

        [StringLength(14)]
        [DisplayName("TELEFONE RESIDENCIAL")]
        public string PRV_TELEFONE_RESIDENCIAL { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("RUA")]
        public string PRV_NOME_RUA { get; set; }

        [Required]
        [StringLength(5)]
        [DisplayName("NÚMERO")]
        public string PRV_NUMERO { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("BAIRRO")]
        public string PRV_BAIRRO { get; set; }

        [Required]
        [StringLength(9)]
        [DisplayName("CEP")]
        public string PRV_CEP { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("NA AUSÊNCIA DO RESPONSÁVEL")]
        public string PRV_NA_AUSENCIA_RESPONSAVEL { get; set; }

        public int PRV_ID_ESTADO_CIVIL_RESPONSAVEL { get; set; }

        public int PRV_ID_TIPO_DE_FAMILIA { get; set; }

        public int? PRV_ID_MORADIA_RESPONSAVEL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRV_CONSTITUICAO_FAMILIAR> PRV_CONSTITUICAO_FAMILIAR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRV_MORADIA> PRV_MORADIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRV_ESCOLARIDADE_EDUCANDO> PRV_ESCOLARIDADE_EDUCANDO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR> PRV_ROTINA_DAS_CRIANCAS_ADOLESCENTE_NUCLEO_FAMILIAR { get; set; }

        public virtual PRV_ESTADO_CIVIL PRV_ESTADO_CIVIL { get; set; }

        public virtual PRV_MORADIA PRV_MORADIA1 { get; set; }

        public virtual PRV_TIPO_DE_FAMILIA PRV_TIPO_DE_FAMILIA { get; set; }
    }
}
