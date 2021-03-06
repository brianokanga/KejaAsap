//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KejaAsapAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class House
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public House()
        {
            this.HousePictures = new HashSet<HousePicture>();
        }
    
        public long ID { get; set; }
        public string Name { get; set; }
        public Nullable<long> AmenitiesId { get; set; }
        public string Description { get; set; }
        public string BuildingId { get; set; }
        public string Price { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string Floor { get; set; }
    
        public virtual Amenity Amenity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HousePicture> HousePictures { get; set; }
    }
}
