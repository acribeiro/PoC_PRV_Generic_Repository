using System.ComponentModel;

namespace Providencia.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRV_MORADIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRV_MORADIA()
        {
            PRV_EDUCANDO1 = new HashSet<PRV_EDUCANDO>();
        }

        [Key]
        [DisplayName("MORADIA")]
        public int PRV_ID_MORADIA { get; set; }

        [DisplayName("ID EDUCANDO")]
        public int PRV_ID_EDUCANDO { get; set; }

        [DisplayName("TIPO MORADIA RESPONSÁVEL")]
        public int PRV_ID_TIPO_MORADIA_RESPONSAVEL { get; set; }

        [DisplayName("QUANTIDADE DE QUARTOS")]
        public int PRV_QUANTIDADE_QUARTOS { get; set; }

        [DisplayName("QUANTIDA DE SALAS")]
        public int PRV_QUANTIDADE_SALAS { get; set; }

        [DisplayName("QUANTIDADE DE BANHEIROS")]
        public int PRV_QUANTIDADE_BANHEIROS { get; set; }

        [DisplayName("QUANTIDADE DE COZINHAS")]
        public int PRV_QUANTIDADE_COZINHAS { get; set; }

        [DisplayName("QUANTIDADE ÁREAS DE SERVIÇO")]
        public int PRV_QUANTIDADE_AREA_DE_SERVICO { get; set; }

        [DisplayName("QUANTIDADE DE QUINTAIS")]
        public int PRV_QUANTIDADE_QUINTAL { get; set; }

        [DisplayName("EDUCANDO")]
        public virtual PRV_EDUCANDO PRV_EDUCANDO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DisplayName("NOME RESPONSÁVEL")]
        public virtual ICollection<PRV_EDUCANDO> PRV_EDUCANDO1 { get; set; }

        [DisplayName("TIPO DE MORADIA")]
        public virtual PRV_TIPO_MORADIA PRV_TIPO_MORADIA { get; set; }
    }
}
