//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApplication2
{
    using System;
    using System.Collections.Generic;
    
    public partial class TeacherContactInfo
    {
        public int ContactInfoId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int TeacherId { get; set; }
    
        public virtual Teacher Teacher { get; set; }
    }
}
