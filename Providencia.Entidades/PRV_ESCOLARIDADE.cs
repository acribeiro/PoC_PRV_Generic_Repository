using System.ComponentModel;

namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_ESCOLARIDADE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRV_ESCOLARIDADE()
        {
            PRV_DADOS_ESCOLARES_FAMILIA = new HashSet<PRV_DADOS_ESCOLARES_FAMILIA>();
        }

        [Key]
        public int PRV_ID_ESCOLARIDADE { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("ESCOLARIDADE")]
        public string PRV_DESCRICAO_ESCOLARIDADE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRV_DADOS_ESCOLARES_FAMILIA> PRV_DADOS_ESCOLARES_FAMILIA { get; set; }
    }
}
