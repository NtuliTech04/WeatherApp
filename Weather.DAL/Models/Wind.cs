namespace Weather.DAL.Models
{
    public sealed class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
        public decimal gust { get; set; }
    }
}
