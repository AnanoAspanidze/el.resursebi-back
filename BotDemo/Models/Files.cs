//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BotDemo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Files
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Nullable<int> StudentId { get; set; }
    
        public virtual Students Students { get; set; }
    }
}