using System.ComponentModel;

namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_CONSTITUICAO_FAMILIAR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRV_CONSTITUICAO_FAMILIAR()
        {
            PRV_BENEFICIOS_FAMILIA = new HashSet<PRV_BENEFICIOS_FAMILIA>();
            PRV_DADOS_ESCOLARES_FAMILIA = new HashSet<PRV_DADOS_ESCOLARES_FAMILIA>();
            PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR = new HashSet<PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR>();
            PRV_MORADORES_RESIDENCIA_EDUCANDO = new HashSet<PRV_MORADORES_RESIDENCIA_EDUCANDO>();
            PRV_VIOLENCIA_NA_FAMILIA = new HashSet<PRV_VIOLENCIA_NA_FAMILIA>();
        }

        [Key]
        public int PRV_ID_CONSTITUICAO_FAMILIAR { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("MEMBRO DA FAMÍLIA")]
        public string PRV_NOME_MEMBRO_FAMILIA { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("PARENTESCO")]
        public string PRV_PARENTESCO { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("PROFISSÃO")]
        public string PRV_PROFISSAO { get; set; }

        [DisplayName("EDUCANDO")]
        public int PRV_ID_EDUCANDO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRV_BENEFICIOS_FAMILIA> PRV_BENEFICIOS_FAMILIA { get; set; }

        public virtual PRV_EDUCANDO PRV_EDUCANDO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRV_DADOS_ESCOLARES_FAMILIA> PRV_DADOS_ESCOLARES_FAMILIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR> PRV_HISTORICO_DEPENDENCIA_QUIMICA_FAMILIAR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRV_MORADORES_RESIDENCIA_EDUCANDO> PRV_MORADORES_RESIDENCIA_EDUCANDO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRV_VIOLENCIA_NA_FAMILIA> PRV_VIOLENCIA_NA_FAMILIA { get; set; }
    }
}
