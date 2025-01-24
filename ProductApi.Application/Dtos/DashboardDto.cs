namespace ProductApi.Application.Dtos
{
    public class DashboardDto
    {
        public string Type { get; set; }
        public int TotalQuantity { get; set; }
        public decimal AveragePrice { get; set; }
    }
}
