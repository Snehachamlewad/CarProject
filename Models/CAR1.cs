namespace C_INFO.Models
{
    public class CAR1
    {
        public int Id { get; set; }

        public string? Model { get; set; }
        public int ManufacturerId { get; set; }
        public int TypeId { get; set; }
        public string Engine { get; set; }
        public int BHP { get; set; }

        public int TransmissionId { get; set; }
        public int? Mileage { get; set; }
        public int? Seat { get; set; }

        public string? AirBagDetails { get; set; }

        public string? BootSpace { get; set; }
        public decimal? Price { get; set; }
    }
}
