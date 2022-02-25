using System.Text;

namespace Vehicle.Sales.Web.Api
{
    public static class Extensions
    {
        public static List<string> ReadAsList(this IFormFile file)
        {
            var result = new List<string>();
            using (var reader = new StreamReader(file.OpenReadStream(), Encoding.GetEncoding("iso-8859-1")))
            {
                while (reader.Peek() >= 0)
                    result.Add(reader.ReadLine() ?? "");
            }
            return result;
        }
    }
}
