namespace HoltinModels.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public Hotel Hotel { get; set; }
        public int HotelId { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public int Guests { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
