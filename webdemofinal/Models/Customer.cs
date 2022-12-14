//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webdemofinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Data.Entity;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.OrderProes = new HashSet<OrderPro>();
            this.ChucNangs = new HashSet<ChucNang>();
        }
        [Required]
        public int IDCus { get; set; }
        [Required]
        public string NameCus { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneCus { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailCus { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PassCus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderPro> OrderProes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChucNang> ChucNangs { get; set; }
    }
}
