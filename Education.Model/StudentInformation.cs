//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Education.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentInformation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentInformation()
        {
            this.StudentAttendance = new HashSet<StudentAttendance>();
        }
    
        public int StudentId { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string RollNo { get; set; }
        public byte[] Pic { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentAttendance> StudentAttendance { get; set; }
    }
}
