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
    
    public partial class WishList
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdObject { get; set; }
    
        public virtual Object Object { get; set; }
        public virtual User User { get; set; }
    }
}
