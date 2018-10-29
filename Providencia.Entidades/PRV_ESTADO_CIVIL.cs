using System.ComponentModel;

namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_ESTADO_CIVIL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRV_ESTADO_CIVIL()
        {
            PRV_EDUCANDO = new HashSet<PRV_EDUCANDO>();
        }

        [Key]
        public int PRV_ID_ESTADO_CIVIL { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("ESTADO CIVIL")]
        public string PRV_DESCRICAO_ESTADO_CIVIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRV_EDUCANDO> PRV_EDUCANDO { get; set; }
    }
}
