using System.ComponentModel;

namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_TIPO_MORADIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRV_TIPO_MORADIA()
        {
            PRV_MORADIA = new HashSet<PRV_MORADIA>();
        }

        [Key]
        public int PRV_ID_TIPO_MORADIA { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("TIPO DE MORADIA")]
        public string PRV_DESCRICAO_TIPO_MORADIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRV_MORADIA> PRV_MORADIA { get; set; }
    }
}
