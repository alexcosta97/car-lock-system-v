using System.Drawing;
using GTA;

namespace Car_Lock_System.Models
{
    class Vehicle
    {
        public string Name { get; set; }
        public float DirtLevel { get; set; }
        public bool CanTiresBurst { get; set; }
        public VehicleColor PrimaryColor { get; set; }
        public VehicleColor SecondaryColor { get; set; }
        public VehicleColor RimColor { get; set; }
        public VehicleColor PearlescentColor { get; set; }
        public VehicleColor TrimColor { get; set; }
        public VehicleColor DashboardColor { get; set; }
        public Color TireSmokeColor { get; set; }
        public Color NeonLightsColor { get; set; }
        public bool HasCustomPrimaryColor { get; set; }
        public bool HasCustomSecondaryColor { get; set; }
        public Color CustomPrimaryColor { get; set; }
        public Color CustomSecondaryColor { get; set; }
        public string LicensePlate { get; set; }
        public LicensePlateStyle LicensePlateStyle { get; set; }
        public VehicleWindowTint WindowTint { get; set; }
        public bool HasNeonLightBack { get; set; }
        public bool HasNeonLightFront { get; set; }
        public bool HasNeonLightLeft { get; set; }
        public bool HasNeonLightRight { get; set; }
        public VehicleWheelType WheelType { get; set; }
    }
}