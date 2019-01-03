namespace Web1.Areas.Masters.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("VEHICLE")]
    public partial class VEHICLE
    {
        public double vehicleid { get; set; }

        public double transporterid { get; set; }

        [Required]
        [StringLength(15)]
        public string regno { get; set; }

        [Required]
        [StringLength(15)]
        public string vehicleno { get; set; }

        [Required]
        [StringLength(10)]
        public string vehicletypecode { get; set; }

        public double bpid { get; set; }

        public DateTime? dtmanufacture { get; set; }

        [Required]
        [StringLength(1)]
        public string active { get; set; }

        public double? kmlimit { get; set; }

        public DateTime? createdon { get; set; }

        public DateTime? modon { get; set; }

        public double? modby { get; set; }

        public DateTime? effdt { get; set; }

        [Required]
        [StringLength(10)]
        public string loccode { get; set; }

        [StringLength(1)]
        public string isgpsinstalled { get; set; }

        public DateTime? gps_install_date { get; set; }

        [StringLength(4000)]
        public string remarks { get; set; }
    }
}
