//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FIT5032_Assignment_Portfolio_Final.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            this.Bookings = new HashSet<Booking>();
        }
    
        public int EventId { get; set; }
        [Required]
        public string EventName { get; set; }
        public string Description { get; set; }

        [Required]       
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:MM/dd/yyyy}")]

        public System.DateTime Date { get; set; }
        [Required]
        public decimal Rating { get; set; }
        [Required]
        [Range(1, 1000.00, ErrorMessage = "Enter a Price than is greater than Zero")]
        public decimal Price { get; set; }
        [Required]
        public decimal Latitude { get; set; }
        [Required]
        public decimal Longitude { get; set; }
        public int CustomerCustId { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
    }


}
