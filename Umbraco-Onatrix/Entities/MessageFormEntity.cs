namespace Umbraco_Onatrix.Entities
{
    public class MessageFormEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Question { get; set; } = null!;
    }
}
