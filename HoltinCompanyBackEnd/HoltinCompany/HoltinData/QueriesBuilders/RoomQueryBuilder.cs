using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinData.QueriesBuilders
{
    public class RoomQueryBuilder
    {
        private const string MainQuery = $"SELECT * FROM Room {WherePlaceholder}";

        private const string WherePlaceholder = "/***WHERE***/";

        private const string WhereHotelId = $"HotelId = {HotelIdParameterName}";
        private const string WhereGuests = $"Room.DoubleBeds * 2 + Room.SingleBeds >= {GuestsParameterName}";
        private const string WhereBooked = $"Booked = {BookedParameterName}";
        private const string WhereSingleBeds = $"SingleBeds = {SingleBedsParameterName}";
        private const string WhereDoubleBeds = $"DoubleBeds = {DoubleBedsParameterName}";
        private const string WhereWiFi = $"WiFi = {WifiParametrName}";
        private const string WhereRoomService = $"RoomService = {RoomServiceParameterName}";
        private const string WhereAirConditioning = $"AirConditioning = {AirConditioningParameterName}";
        private const string WhereTv = $"TV = {TvParameterName}";
        private const string WhereNightPriceMax = $"NightPrice <= {NightPriceMaxParameterName}";
        private const string WhereNightPriceMin = $"NightPrice BETWEEN {NightPriceMinParameterName} AND (SELECT MAX(NightPrice) FROM Room)";

        private const string HotelIdParameterName = "@id";
        private const string GuestsParameterName = "@guests";
        private const string BookedParameterName = "@booked";
        private const string SingleBedsParameterName = "@singleBeds";
        private const string DoubleBedsParameterName = "@doubleBeds";
        private const string WifiParametrName = "@wifi";
        private const string RoomServiceParameterName = "@roomService";
        private const string AirConditioningParameterName = "@airConditioning";
        private const string TvParameterName = "@tv";
        private const string NightPriceMaxParameterName = "@nightPriceMax";
        private const string NightPriceMinParameterName = "@nightPriceMin";

        private List<string> Wheres { get; set; }
        private Dictionary<string, object> QueryParameters { get; set; }
        private QueryBuilderResult Result { get; set; }


        private RoomQueryBuilder() 
        { 
            Wheres = new List<string>();
            QueryParameters = new Dictionary<string, object>();
        }

        public static RoomQueryBuilder Create() => new ();

        public RoomQueryBuilder WithHotelId (int hotelId)
        {
            if(hotelId == 0)
            {
                return this;
            }
            Wheres.Add(WhereHotelId);
            QueryParameters.Add(HotelIdParameterName, hotelId);
            return this;
        }

        public RoomQueryBuilder WithGuests (int guests)
        {
            if (guests == 0)
            {
                return this;
            }
            Wheres.Add(WhereGuests);
            QueryParameters.Add(GuestsParameterName, guests);
            return this;
        }

        public RoomQueryBuilder WithBooked(bool booked)
        {
            if (!booked)
            {
                Wheres.Add(WhereBooked);
                QueryParameters.Add(BookedParameterName, booked);
                return this;
            }
            return this;
        }

        public RoomQueryBuilder WithSingleBeds (int singleBeds)
        {
            if (singleBeds == 0) return this;
            Wheres.Add(WhereSingleBeds);
            QueryParameters.Add(SingleBedsParameterName, singleBeds);
            return this;
        }

        public RoomQueryBuilder WithDoubleBeds (int doubleBeds)
        {
            if (doubleBeds== 0) return this;
            Wheres.Add(WhereDoubleBeds);
            QueryParameters.Add(DoubleBedsParameterName, doubleBeds);
            return this;
        }

        public RoomQueryBuilder WithWiFi (bool wifi)
        {
            if (wifi)
            {
                Wheres.Add(WhereWiFi);
                QueryParameters.Add(WifiParametrName, wifi);
                return this;
            }
            return this;
        }

        public RoomQueryBuilder WithRoomService (bool roomService)
        {
            if (roomService)
            {
                Wheres.Add(WhereRoomService);
                QueryParameters.Add(RoomServiceParameterName, roomService);
                return this;
            }
            return this;
        }

        public RoomQueryBuilder WithAirConditioning (bool airConditioning)
        {
            if (airConditioning)
            {
                Wheres.Add(WhereAirConditioning);
                QueryParameters.Add(AirConditioningParameterName, airConditioning);
                return this;
            }
            return this;
        }

        public RoomQueryBuilder WithTv (bool tv)
        {
            if (tv == true)
            {
                Wheres.Add(WhereTv);
                QueryParameters.Add(TvParameterName, tv);
                return this;
            }
            return this;
        }

        public RoomQueryBuilder WithNightPriceMax (decimal nightPriceMax)
        {
            if (nightPriceMax == 0) return this;
            Wheres.Add (WhereNightPriceMax);
            QueryParameters.Add(NightPriceMaxParameterName, nightPriceMax);
            return this;
        }

        public RoomQueryBuilder WithNightPriceMin (decimal nightPriceMin)
        {
            if (nightPriceMin == 0) return this;
            Wheres.Add (WhereNightPriceMin);
            QueryParameters.Add(NightPriceMinParameterName, nightPriceMin);
            return this;
        }

        public QueryBuilderResult Build ()
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
