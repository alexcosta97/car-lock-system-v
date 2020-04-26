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
            Logger.Log("Initialized Script");
        }

        private ContainerElement container;
        private Vehicle previous;
        private Vehicle current;
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
                Vehicle nearby = World.GetClosestVehicle(player.Position, 5.0f, new Model[0]);
                eligibilityChecker(nearby);
                return;
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e) { }

        private void OnKeyUp(object sender, KeyEventArgs e) {

            if (e.KeyCode == Keys.L && eligible && current != null)
            {
                locker();
            }
            container.Items.Clear();
            container.Enabled = false;
        }

        private void eligibilityChecker(Vehicle nearby)
        {
            Vehicle last = player.LastVehicle;
            if (nearby != null && last != null && last.Equals(nearby))
            {
                // Set eligibility
                eligible = true;

                // Update UI on screen
                container.Enabled = true;
                container.Items.Clear();
                if (nearby.LockStatus == VehicleLockStatus.Locked) displayText("Press L to Unlock Car");
                else displayText("Press L to Lock Car");

                // Manage vehicles
                vehicleManager(nearby);
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
            switch (current.LockStatus)
            {
                case VehicleLockStatus.Locked:
                    current.LockStatus = VehicleLockStatus.Unlocked;
                    current.IsAlarmSet = false;
                    Logger.Log("Unlocked Current Car");
                    break;
                case VehicleLockStatus.Unlocked:
                    current.LockStatus = VehicleLockStatus.Locked;
                    current.IsAlarmSet = true;
                    Logger.Log("Locked Current Car");
                    break;
                default:
                    current.LockStatus = VehicleLockStatus.Unlocked;
                    current.IsAlarmSet = false;
                    Logger.Log("Unlocked Current Car when Status wasn't Locked or Unlocked");
                    break;
            }
        }

        private void vehicleManager(Vehicle nearby)
        {
            current = nearby;
            if (previous == null)
            {
                previous = current;
                Logger.Log("Previous car has been set to current");
            }

            if (!previous.Equals(current))
            {
                previous.LockStatus = VehicleLockStatus.Unlocked;
                previous.IsAlarmSet = false;
                Logger.Log("Unlocked Previous Car");
                previous = current;
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
