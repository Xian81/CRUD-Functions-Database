//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Forest.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Music_Recording
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Genre { get; set; }
        public string Image_Name { get; set; }
        public Nullable<int> Num_Tracks { get; set; }
        public double Price { get; set; }
        public int Stock_Count { get; set; }
        public System.DateTime Released { get; set; }
    }
}
