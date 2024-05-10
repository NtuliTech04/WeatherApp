namespace Weather.DAL.Models
{
    public sealed class Main
    {
        public decimal temp { get; set; }
        public decimal feels_like { get; set; }
        public decimal temp_min { get; set; }
        public decimal temp_max { get; set; }
        public int pressure { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
        public int humidity { get; set; }
        public int temp_kf { get; set; }
    }
}