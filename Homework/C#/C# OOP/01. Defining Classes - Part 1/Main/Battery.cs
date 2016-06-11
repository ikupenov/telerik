namespace Main
{
    public class Battery
    {
        private string batteryModel;
        private ushort? batteryHoursIdle;
        private ushort? batteryHoursTalk;
        private BatteryType? batteryType;

        public Battery(string model = null, BatteryType? type = null, ushort? hoursIdle = null, ushort? hoursTalk = null)
        {
            this.batteryModel = model;
            this.batteryType = type;
            this.batteryHoursIdle = hoursIdle;
            this.batteryHoursTalk = hoursTalk;
        }

        public string Model
        {
            get { return this.batteryModel; }
            private set { this.batteryModel = value; }
        }

        public ushort? HoursIdle
        {
            get { return this.batteryHoursIdle; }
            private set { this.batteryHoursIdle = value; }
        }

        public ushort? HoursTalk
        {
            get { return this.batteryHoursTalk; }
            private set { this.batteryHoursTalk = value; }
        }

        public BatteryType? Type 
        {
            get { return this.batteryType; }
            private set { this.batteryType = value; }
        }
    }
}