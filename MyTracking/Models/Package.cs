namespace MyTracking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Package")]
    public partial class Package
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Package()
        {
            Arrives = new HashSet<Arrive>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El Numero de seguimiento debe tener 10 caracteres")]
        [Index("TrackingNoIndex", IsUnique = true)]
        [Display(Name = "Numero de seguimiento")]
        public string TrackingNo { get; set; }

        [Required]
        [Display(Name = "Peso del paquete")]
        public short Weight { get; set; }

        [Required]
        [Display(Name = "Esta en transito?")]
        public bool InTransit { get; set; }

        [Required]
        [Display(Name = "Dueño del paquete")]
        public string Owner { get; set; }

        [Required]
        [Display(Name = "Lugar de Destino")]
        public DbGeography Destination { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Arrive> Arrives { get; set; }
    }
}
