//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace IT_Club_Model
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Product
    {
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string ProductPic { get; set; }
        [DataMember]
        public Nullable<decimal> ProductPrice { get; set; }
        [DataMember]
        public string ProductDesc { get; set; }
        [DataMember]
        public Nullable<int> ClassID { get; set; }
        [DataMember]
        public Nullable<System.DateTime> AddTime { get; set; }
        [DataMember]
        public Nullable<System.DateTime> ExpireTime { get; set; }
        [DataMember]
        public Nullable<int> SalesVolume { get; set; }
        [DataMember]
        public Nullable<int> InventoryQuantity { get; set; }
        public LuceneTypeEnum LuceneTypeEnum { get; set; }
    }
}