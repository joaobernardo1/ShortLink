namespace ShortLink.Domain.Entities
{
    public class Link
    {
        public long Id { get; set; }
        public string ShortLink { get; set; } = string.Empty;
        public string LongLink { get; set; } = string.Empty;

        public DateTime ExpirationDate { get; set; }= DateTime.UtcNow.AddDays(15);
    }
}
