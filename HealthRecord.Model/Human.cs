//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HealthRecord.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Human
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Gender { get; set; }
        public double Activity { get; set; }
        public double Goal { get; set; }
        public bool isHighintensity { get; set; }
        public bool isLabor { get; set; }
        public string Account { get; set; }
    }
}