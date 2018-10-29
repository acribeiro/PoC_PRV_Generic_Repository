using System.ComponentModel;

namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_TIPO_DE_FAMILIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRV_TIPO_DE_FAMILIA()
        {
            PRV_EDUCANDO = new HashSet<PRV_EDUCANDO>();
        }

        [Key]
        public int PRV_ID_TIPO_DE_FAMILIA { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("TIPO DE FAMÍLIA")]
        public string PRV_DESCRICAO_TIPO_DE_FAMILIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRV_EDUCANDO> PRV_EDUCANDO { get; set; }
    }
}
