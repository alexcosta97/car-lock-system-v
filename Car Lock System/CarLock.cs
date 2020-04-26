using System;
using System.Drawing;
using System.Windows.Forms;
using GTA;
using GTA.UI;

namespace Car_Lock_System
{
    public class CarLock : Script
    {
        public CarLock()
        {
            Tick += OnTick;
            KeyUp += OnKeyUp;
            KeyDown += OnKeyDown;
            container = new ContainerElement(new PointF(100.0f, 50.0f), new SizeF(100.0f, 25.0f));
        }

        private ContainerElement container;
        private Vehicle currentVehicle;
        private bool eligible = false;
        private Ped player = Game.Player.Character;

        private void OnTick(object sender, EventArgs e) {
            if (player.IsInVehicle() || player.IsGettingIntoVehicle)
            {
                eligible = false;
                return;
            }
            else
            {
                Vehicle nearbyVehicle = World.GetClosestVehicle(player.Position, 5.0f, new Model[0]);
                eligibilityChecker(nearbyVehicle);
                return;
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e) { }

        private void OnKeyUp(object sender, KeyEventArgs e) {

            if (e.KeyCode == Keys.L && eligible && currentVehicle != null)
            {
                locker();
            }
            container.Items.Clear();
            container.Enabled = false;
        }

        private void eligibilityChecker(Vehicle nearbyVehicle)
        {
            Vehicle lastVehicle = player.LastVehicle;
            if (nearbyVehicle != null && lastVehicle != null && player.LastVehicle.Equals(nearbyVehicle))
            {
                eligible = true;
                currentVehicle = nearbyVehicle;
                container.Enabled = true;
                container.Items.Clear();
                if (nearbyVehicle.LockStatus == VehicleLockStatus.Locked) displayText("Press L to Unlock Car");
                else displayText("Press L to Lock Car");
                return;
            }
            else
            {
                eligible = false;
                return;
            }
        }

        private void locker()
        {
            switch (currentVehicle.LockStatus)
            {
                case VehicleLockStatus.Locked:
                    currentVehicle.LockStatus = VehicleLockStatus.Unlocked;
                    currentVehicle.IsAlarmSet = false;
                    break;
                case VehicleLockStatus.Unlocked:
                    currentVehicle.LockStatus = VehicleLockStatus.Locked;
                    currentVehicle.IsAlarmSet = true;
                    break;
                default:
                    currentVehicle.LockStatus = VehicleLockStatus.Unlocked;
                    currentVehicle.IsAlarmSet = false;
                    break;
            }
        }

        private void displayText(String text)
        {
            container.Centered = true;
            TextElement textElement = new TextElement(text, new PointF(5.0f, 5.0f), 0.3f);
            container.Items.Add(textElement);
            container.ScaledDraw();
        }
    }
}
