using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinData.QueriesBuilders
{
    public class ReservationQueryBuilder
    {
        private const string MainQuery = $"SELECT * FROM Reservation {WherePlaceholder}";

        private const string WherePlaceholder = "/***WHERE***/";

        private const string WhereHotelId = $"HotelId = {HotelIdParameterName}";
        private const string WhereRoomId = $"RoomId = {RoomIdParameterName}";
        private const string WhereClientId = $"ClientId = {ClientIdParameterName}";
        private const string WhereGuests = $"Guests = {GuestsParameterName}";
        private const string WhereCheckIn = $"CheckIn = {CheckInParameterName}";
        private const string WhereCheckOut = $"CheckOut = {CheckInParameterName}";
        private const string WhereTotalPrice = $"TotalPrice = {TotalPriceParameterName}";

        private const string HotelIdParameterName = "@id";
        private const string RoomIdParameterName = "@roomId";
        private const string ClientIdParameterName = "@clientId";
        private const string GuestsParameterName = "@guests";
        private const string CheckInParameterName = "@checkIn";
        private const string CheckOutParameterName = "@checkOut";
        private const string TotalPriceParameterName = "@totalPrice"; 

        private List<string> Wheres { get; set; }
        private Dictionary<string, object> QueryParameters { get; set; }
        private QueryBuilderResult Result { get; set; }


        private ReservationQueryBuilder()
        {
            Wheres = new List<string>();
            QueryParameters = new Dictionary<string, object>();
        }

        public static ReservationQueryBuilder Create() => new();

        public ReservationQueryBuilder WithHotelId(int hotelId)
        {
            if (hotelId == 0)
            {
                return this;
            }
            Wheres.Add(WhereHotelId);
            QueryParameters.Add(HotelIdParameterName, hotelId);
            return this;
        }

        public ReservationQueryBuilder WithRoomId(int roomId)
        {
            if (roomId == 0)
            {
                return this;
            }
            Wheres.Add(WhereRoomId);
            QueryParameters.Add(RoomIdParameterName, roomId);
            return this;
        }

        public ReservationQueryBuilder WithClientId(int clientId)
        {
            if (clientId == 0)
            {
                return this;
            }
            Wheres.Add(WhereClientId);
            QueryParameters.Add(ClientIdParameterName, clientId);
            return this;
        }

        public ReservationQueryBuilder WithGuests(int guests)
        {
            if (guests == 0)
            {
                return this;
            }
            Wheres.Add(WhereGuests);
            QueryParameters.Add(GuestsParameterName, guests);
            return this;
        }

        public ReservationQueryBuilder WithCheckIn(DateTime checkIn)
        {
            if (checkIn == DateTime.MinValue)
            {
                return this;
            }
            Wheres.Add(WhereCheckIn);
            QueryParameters.Add(CheckInParameterName, checkIn);
            return this;
        }

        public ReservationQueryBuilder WithCheckOut(DateTime checkOut)
        {
            if (checkOut == DateTime.MinValue)
            {
                return this;
            }
            Wheres.Add(WhereCheckOut);
            QueryParameters.Add(CheckOutParameterName, checkOut);
            return this;
        }

        public ReservationQueryBuilder WithTotalPrice(decimal totalPrice)
        {
            if (totalPrice == 0)
            {
                return this;
            }
            Wheres.Add(WhereTotalPrice);
            QueryParameters.Add(TotalPriceParameterName, totalPrice);
            return this;
        }

        public QueryBuilderResult Build()
        {
            var wheresStrings = string.Empty;
            if (Wheres.Any())
            {
                wheresStrings = $"{Environment.NewLine}WHERE {string.Join($" AND ", Wheres)}";
            }
            return new QueryBuilderResult
            {
                Query = MainQuery.Replace(WherePlaceholder, wheresStrings),
                Parameters = QueryParameters
            };
        }
    }
}
