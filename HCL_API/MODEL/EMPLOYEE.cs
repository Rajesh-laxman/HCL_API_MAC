using System;
using System.ComponentModel.DataAnnotations;


/* 1.CREATE MODEL */
namespace HCL_API.MODEL
{
    public class EMPLOYEE
    {
        public EMPLOYEE()
        {
        }
        [Key]
        public int E_ID { get; set; }
        public string E_Name { get; set; } = null!;
        public string? E_City { get; set; }
        [Required]
        public string E_Design { get; set; } = null!;

    }
}

/* 2.ADD PACKAGES[4] */
/* 3.ADD DB_CONTEXT_CLASS */
