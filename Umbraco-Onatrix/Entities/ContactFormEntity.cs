namespace Umbraco_Onatrix.Entities
{
	public class ContactFormEntity
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Phone { get; set; } = null!;
	}
}
