namespace Programming.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("duyurular")]
    public partial class duyurular
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Baþlýk zorunludur")]
        [StringLength(50)]
        [MaxLength(3,ErrorMessage ="Baþlýk ikiden fazla olmalýdýr")]
        public string Baslik { get; set; }

        [StringLength(1000)]
        public string Duyuru { get; set; }

        public DateTime? Tarih { get; set; }
    }
}
