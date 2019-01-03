namespace Web1.Areas.Masters.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("VENDOR")]
    public partial class VENDOR
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TRANSPORTERID { get; set; }

        [Display(Name = "Location Code")]
        [StringLength(10)]
        public string LOCCODE { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Company Name")]
        public string COMPANY_NAME { get; set; }

        [StringLength(20)]
        public string SHORT_NAME { get; set; }

        [StringLength(10)]
        public string PREFIXTAG { get; set; }

        [Required]
        [StringLength(1)]
        public string ACTIVE { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Valid From")]
        public DateTime? VALIDFROM { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Valid Till")]
        public DateTime? VALIDTILL { get; set; }

        [StringLength(250)]
        public string ADDRESS1 { get; set; }

        [StringLength(250)]
        public string ADDRESS2 { get; set; }

        [StringLength(100)]
        public string CITY { get; set; }

        [StringLength(150)]
        public string PHONE1 { get; set; }

        [StringLength(150)]
        public string PHONE2 { get; set; }

        [StringLength(50)]
        public string ZIPCODE { get; set; }

        [StringLength(150)]
        public string EMAILID { get; set; }

        [StringLength(100)]
        [Display(Name = "First Name")]
        public string FNAME { get; set; }

        [StringLength(100)]
        [Display(Name = "Middle Name")]
        public string MNAME { get; set; }

        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LNAME { get; set; }

        [StringLength(20)]
        [Display(Name = "Modified By")]
        public string MODBY { get; set; }

        [Display(Name = "Modified On")]
        public DateTime? MODON { get; set; }

        [Display(Name = "Date Created On")]
        public DateTime? CREATEDON { get; set; }

        public DateTime? EFFDT { get; set; }
    }
}
