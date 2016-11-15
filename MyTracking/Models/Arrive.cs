namespace MyTracking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Arrive")]
    public partial class Arrive
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Fecha llegada")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Nombre Lugar")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Lugar de llegada")]
        public DbGeography Location { get; set; }

        [Required]
        [Display(Name = "Numero de seguimiento")]
        public int IdPackage { get; set; }

        public virtual Package Package { get; set; }
    }
}
