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
        private Vehicle nearbyCar;
        private Vehicle currentVehicle;
        private bool locked = false;
        private Ped player = Game.Player.Character;

        private void OnTick(object sender, EventArgs e) {
            nearbyCar = World.GetClosestVehicle(player.Position, 5.0f, new Model[0]);
            manageVehicleState();
        }

        private void OnKeyDown(object sender, KeyEventArgs e) { }

        private void OnKeyUp(object sender, KeyEventArgs e) {

            if (container.Enabled == true)
            {
                if (e.KeyCode == Keys.L)
                {
                    locker();
                }
                container.Items.Clear();
                container.Enabled = false;
            }
        }

        private void manageVehicleState()
        {
            if (nearbyCar != null)
            {
                container.Items.Clear();
                container.Enabled = true;
                nearbyCar.DirtLevel = 0f;
                if (player.IsTryingToEnterALockedVehicle)
                {
                    displayText("The car is locked. Press L to Unlock Car");
                }
                else if (player.IsInVehicle(nearbyCar) || player.IsGettingIntoVehicle)
                {
                    displayText("Player in CarLockVehicle");
                }
                else if (nearbyCar.LockStatus == VehicleLockStatus.Unlocked)
                {
                    displayText("Press L to Lock Car");
                    locked = false;
                }
                else if (nearbyCar.LockStatus == VehicleLockStatus.Locked)
                {
                    displayText("Press L to Unlock Car");
                    locked = true;
                }
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
