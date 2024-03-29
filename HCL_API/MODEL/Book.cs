using System;
using System.ComponentModel.DataAnnotations;

namespace HCL_API.MODEL
{
	public class Book
	{
        [Key]
		public int B_ID { get; set; }

        //[Required(ErrorMessage = "B_Name not given")]
        //      [RegularExpression("ur expression")]
        //[EmailAddress]
        //[MaxLength(10)]
        //[MinLength(5)]
        //[StringLength(25)]
        //[Required,EmailAddress]
        [Required]
        public string B_Name { get; set; } = null!;

	}
}

