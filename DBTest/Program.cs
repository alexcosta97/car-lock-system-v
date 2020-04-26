using LiteDB;
using System;
using System.Drawing;
using System.Linq;

namespace DBTest
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new LiteDatabase(@"C:\Temp\database.db"))
            {
                var collection = db.GetCollection<Vehicle>("vehicles");
                collection.EnsureIndex(x => x.LicensePlate);

                var vehicle = new Vehicle
                {
                    Name = "Patriot",
                    DirtLevel = 0f,
                    CanTiresBurst = true,
                    PrimaryColor = 111,
                    SecondaryColor = 0,
                    RimColor = 156,
                    PearlescentColor = 0,
                    TrimColor = 0,
                    DashboardColor = 0,
                    TireSmokeColor = Color.FromArgb(255, 255, 255),
                    NeonLightsColor = Color.FromArgb(255, 0, 255),
                    HasCustomPrimaryColor = false,
                    HasCustomSecondaryColor = false,
                    LicensePlate = "00RPA937",
                    LicensePlateStyle = 0,
                    WindowTint = 0,
                    HasNeonLightBack = false,
                    HasNeonLightFront = false,
                    HasNeonLightLeft = false,
                    HasNeonLightRight = false,
                    WheelType = 3
                };

                collection.Insert(vehicle);

                var r = collection.FindOne(x => x.LicensePlate.Equals(vehicle.LicensePlate));
                Console.WriteLine(r.Name);
                Console.WriteLine(r.LicensePlate);

                var results = collection.FindAll();
                Console.WriteLine(results.Count());
            }
        }
    }

    class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float DirtLevel { get; set; }
        public bool CanTiresBurst { get; set; }
        public int PrimaryColor { get; set; }
        public int SecondaryColor { get; set; }
        public int RimColor { get; set; }
        public int PearlescentColor { get; set; }
        public int TrimColor { get; set; }
        public int DashboardColor { get; set; }
        public Color TireSmokeColor { get; set; }
        public Color NeonLightsColor { get; set; }
        public bool HasCustomPrimaryColor { get; set; }
        public bool HasCustomSecondaryColor { get; set; }
        public Color CustomPrimaryColor { get; set; }
        public Color CustomSecondaryColor { get; set; }
        public string LicensePlate { get; set; }
        public int LicensePlateStyle { get; set; }
        public int WindowTint { get; set; }
        public bool HasNeonLightBack { get; set; }
        public bool HasNeonLightFront { get; set; }
        public bool HasNeonLightLeft { get; set; }
        public bool HasNeonLightRight { get; set; }
        public int WheelType { get; set; }
    }
}
