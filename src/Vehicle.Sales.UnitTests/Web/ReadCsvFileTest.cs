using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using Vehicle.Sales.Web.Api;
using Xunit;

namespace Vehicle.Sales.UnitTests.Core
{
    public class ReadCsvFileTest
    {
        private string _csvLine = "";

        public ReadCsvFileTest()
        {
            _csvLine = "1234,Leandro,Ford Marcas,2022 Tucson,\"30,000\",2/20/2022";
        }

        [Fact]
        public void Should_read_csv_file()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Web\", "CsvTest.csv");

            using var stream = new MemoryStream(File.ReadAllBytes(path).ToArray());
            var formFile = new FormFile(stream, 0, stream.Length, "streamFile", "CsvTest.csv");

            var csvLine = formFile.ReadAsList().Skip(1).FirstOrDefault() ?? "";
            
            Assert.Equal(_csvLine, csvLine);
        }
    }
}
