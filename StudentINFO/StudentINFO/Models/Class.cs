//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentINFO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Class
    {
        public int ClassId { get; set; }
        public int NumClass { get; set; }
        public int FK_DisciplineId { get; set; }
        public int FK_DayId { get; set; }
        public int FK_GroupId { get; set; }
    
        public virtual DaysOfWeek DaysOfWeek { get; set; }
        public virtual Discipline Discipline { get; set; }
        public virtual Group Group { get; set; }
    }
}
