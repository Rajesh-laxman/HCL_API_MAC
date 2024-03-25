using System;
namespace HCL_API.MODEL.DTO
{
	public class EMP_DTO
	{
		public EMP_DTO()
		{
		}
        public int E_ID { get; set; }
        public string E_Name { get; set; } = null!;
        public string? E_City { get; set; }
        public string E_Design { get; set; } = null!;
    }
}

