using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.Entities
{
    public class Room
    {
        public int Id { get; init; }
        public Hotel Hotel { get; init; }
        public int HotelId { get; init; }
        public int Number { get; set; }
        public bool Booked { get; set; }
        public int SingleBeds { get; set; }
        public int DoubleBeds { get; set; }
        public bool WiFi { get; set; }
        public bool RoomService { get; set; }
        public bool AirConditioning { get; set; }
        public bool Tv { get; set; }
        public decimal NightPrice { get; set; }

        public override string ToString()
        {
            return $"Hotel: {Hotel}, Number: {Number}, Booked: {Booked}, SingleBeds: {SingleBeds}, DoubleBeds: {DoubleBeds}, WiFi: {WiFi}, RoomService: {RoomService}, AirConditioning: {AirConditioning}, Tv: {Tv}, NightPrice: {NightPrice}";
        }
    }
}
