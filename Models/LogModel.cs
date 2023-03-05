namespace Models
{
    public class LogModel
    {
        public int? Id { get; set; }
        public string? Type { get; set; }
        public string? Message { get; set; }
        public string? Description { get; set; }
        public string? Section { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
