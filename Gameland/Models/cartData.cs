//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gameland.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class cartData
    {
        public string userName { get; set; }
        public string productName { get; set; }
        public string productImg { get; set; }
        public string productType { get; set; }
        public Nullable<int> price { get; set; }
    
        public virtual usersData usersData { get; set; }
    }
}
