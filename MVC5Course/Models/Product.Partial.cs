namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.ProductId == default(int))
            {
                // Create Data Only
            }
            else
            {
                // Update Data Only
            }

            //if (this.Stock > 10 && this.Price < 100)
            //{
            //    yield return new ValidationResult("價格設定錯誤",
            //        new string[] { "Price" });
            //}

            //if (this.Stock < 5)
            //{
            //    yield return new ValidationResult("庫存量過低，無法新增商品");
            //}

            yield break;
        }
    }

    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
        
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
        [Required]
        //[產品名稱必須至少包含兩個空白字元(ErrorMessage = "產品名稱必須至少包含兩個空白字元")]
        public string ProductName { get; set; }
        [Required]
        public Nullable<decimal> Price { get; set; }
        [Required]
        public Nullable<bool> Active { get; set; }
        [Required]
        public Nullable<decimal> Stock { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
