using HoltinData.QueriesBuilders;
using HoltinModels.Requests.HotelRequest;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HoltinData.Queries
{
    public class HotelQueryBuilder
    {
        private const string MainQuery = $"SELECT * FROM Hotel {WherePlaceholder}";

        private const string WherePlaceholder = "/***WHERE***/";

        private const string WhereCity = $"City = {CityParameterName}";
        private const string WhereName = $"Name = {NameParameterName}";
        private const string CityParameterName = "@city";
        private const string NameParameterName = "@name";

        private List<string> Wheres { get; set; }
        private Dictionary<string, object> QueryParameters { get; set; }

        private HotelQueryBuilder ()
        {
            Wheres = new List<string>();
            QueryParameters = new Dictionary<string, object>();
        }

        public static HotelQueryBuilder Create() => new();

        public HotelQueryBuilder WithName (string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return this;
            }
            Wheres.Add(WhereName);
            QueryParameters.Add(NameParameterName, name);
            return this;
        }

        public HotelQueryBuilder WithCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return this;
            }
            Wheres.Add(WhereCity);
            QueryParameters.Add(CityParameterName, city);
            return this;
        }

        public QueryBuilderResult Build()
        {
            var wheresString = string.Empty;
            if (Wheres.Any())
            {
                wheresString = $"{Environment.NewLine}WHERE {string.Join($" AND ", Wheres)}"; 
            }
            return new QueryBuilderResult()
            {
                Query = MainQuery.Replace(WherePlaceholder, wheresString),
                Parameters = QueryParameters
            };
        }
    }
}
