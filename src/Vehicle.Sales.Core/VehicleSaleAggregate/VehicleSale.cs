using Vehicle.Sales.Shared;

namespace Vehicle.Sales.Core.VehicleSaleAggregate
{
    public class VehicleSale: BaseEntity
    {
        public int DealNumber { get; private set; }
        public string CustomerName { get; private set; } = string.Empty;
        public string DealershipName { get; private set; } = string.Empty;
        public string Vehicle { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public DateTime Date { get; private set; }

        public VehicleSale() { }
        
        public VehicleSale(int dealNumber, string customerName, string dealershipName, string vehicle, decimal price, DateTime date)
        {
            DealNumber = dealNumber;
            CustomerName = customerName;
            DealershipName = dealershipName;
            Vehicle = vehicle;
            Price = price;
            Date = date;
        }

        /// <summary>
        /// A static method to create a vehicle sale from a Csv line
        /// </summary>
        public static VehicleSale CreateFromCsvLine(string line)
        {
            // Removing the coma symbol before spliting the line columns
            var groupsToReplace = new System.Text.RegularExpressions.Regex(@"\""(.*?)\""").Matches(line);

            groupsToReplace.ToList().ForEach(g => line.Replace(g.Value, g.Value.Replace(",", "")));

            foreach (var item in groupsToReplace.ToList())
            {
                var stringToReplace = item.Value;
                var newString = item.Value.Replace(",", "");

                line = line.Replace(stringToReplace, newString);
            }

            string[] values = line.Split(',');

            var dealNumber = Convert.ToInt32(values[0]);
            var customerName = values[1].Replace("\"", "");
            var dealershipName = values[2].Replace("\"", "");
            var vehicle = values[3].Replace("\"", "");
            var price = Convert.ToDecimal(values[4].Replace("\"", ""));
            var date = Convert.ToDateTime(values[5]);

            return new VehicleSale(dealNumber, customerName, dealershipName, vehicle, price, date);
        }
    }
}
