using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAccess.InternalModel
{
    [Table("dbo.Tbl_Venues")]
    internal class Venue
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int VenueId { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public int? Capacity { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Directions { get; set; }
        [Column("StreetmapURI")]
        public string StreetmapUri { get; set; }
        [Column("Customerid")]
        public int? CustomerId { get; set; }
        [Column("Associationid")]
        public int? AssociationId { get; set; }
        public string Postcode { get; set; }
        [Column("Hideitem")]
        public bool HideItem { get; set; }
        public string ImageFile { get; set; }
    }
}
