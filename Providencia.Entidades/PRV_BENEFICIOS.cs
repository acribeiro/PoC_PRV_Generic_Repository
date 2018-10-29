using System.ComponentModel;

namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_BENEFICIOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRV_BENEFICIOS()
        {
            PRV_BENEFICIOS_FAMILIA = new HashSet<PRV_BENEFICIOS_FAMILIA>();
        }

        [Key]
        public int PRV_ID_BENEFICIOS { get; set; }

        [Required]
        [StringLength(100)]
        //[DisplayName("Benefício")]
        public string PRV_DESCRICAO_BENEFICIOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRV_BENEFICIOS_FAMILIA> PRV_BENEFICIOS_FAMILIA { get; set; }
    }
}
