//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wpf_TechMarketMangement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class InputInfo
    {
        public int Id { get; set; }
        public int IdObject { get; set; }
        public int IdInput { get; set; }
        public Nullable<int> Counts { get; set; }
        public Nullable<double> InputPrice { get; set; }
        public Nullable<double> OutputPrice { get; set; }
        public Nullable<int> Condition { get; set; }
        public string Description { get; set; }
        public Nullable<int> BoughtYear { get; set; }
        public string Color { get; set; }
        public string Address { get; set; }
    
        public virtual Input Input { get; set; }
        public virtual Object Object { get; set; }
    }
}
