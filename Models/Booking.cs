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
    
    public partial class Booking
    {
        public int BookingId { get; set; }
        public string BookingStatus { get; set; }
        public int CustomerCustId { get; set; }
        public int EventEventId { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Event Event { get; set; }
    }


}
