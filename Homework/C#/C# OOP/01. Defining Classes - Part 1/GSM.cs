namespace Main
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GSM
    {
        static Battery iPhoneBattery = new Battery(null, BatteryType.LiPo, 200, 14);
        static Display iPhoneDisplay = new Display(3.5, 16000000);
        public static GSM iPhone4S = new GSM("iPhone 4S", "Apple", 203.274m, null, iPhoneBattery, iPhoneDisplay);

        private string model;
        private string manafacturer;
        private decimal? price;
        private string owner;
        private Battery Battery;
        private Display Display;

        private List<Call> CallHistory = new List<Call>();

        public GSM(string phoneModel, string phoneManafacturer)
        {
            this.model = phoneModel;
            this.manafacturer = phoneManafacturer;
        }

        public GSM(string phoneModel, string phoneManafacturer, decimal? phonePrice = null,
                   string phoneOwner = null, Battery phoneBattery = null, Display phoneDisplay = null)
                   : this(phoneModel, phoneManafacturer)
        {
            this.price = phonePrice;
            this.owner = phoneOwner;
            this.Battery = phoneBattery;
            this.Display = phoneDisplay;
        }

        public string Model
        {
            get { return this.model; }
        }

        public string Manafacturer
        {
            get { return this.manafacturer; }
        }

        public decimal? Price
        {
            get { return this.price; }
            private set { this.price = value; }
        }

        public string Owner
        {
            get { return this.owner; }
            private set { this.owner = value; }
        }

        public string ModelOfBattery
        {
            get { return this.Battery.Model; }
        }

        public BatteryType? TypeOfBattery
        {
            get { return this.Battery.Type; }
        }

        public ushort? BatteryHoursIdle
        {
            get { return this.Battery.HoursIdle; }
        }

        public ushort? BatteryHoursTalk
        {
            get { return this.Battery.HoursTalk; }
        }

        public ulong? DisplayNumberOfColors
        {
            get { return this.Display.NumberOfColors; }
        }

        public double? DisplaySize
        {
            get { return this.Display.Size; }
        }

        public List<Call> GetCallHistory
        {
            get { return this.CallHistory; }
        }

        public void AddCall(Call currentCall)
        {
            this.CallHistory.Add(currentCall);
        }

        public void RemoveCall(Call currentCall)
        {
            this.CallHistory.Remove(currentCall);
        }

        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }

        public decimal CallPrice(List<Call> callHistory, decimal pricePerMin)
        {
            decimal totalDuration = 0;

            foreach (var call in callHistory)
            {
                totalDuration += call.CallDuration;
            }

            decimal callDurationAsMinutes = Math.Ceiling(totalDuration / 60m);
            decimal price = callDurationAsMinutes * pricePerMin;

            return price;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Manafacturer " + this.manafacturer);
            builder.AppendLine("Phone Model: " + this.model);
            if (this.price != null)
                builder.AppendLine("Price: " + this.price);
            if (this.owner != null)
                builder.AppendLine("Owner: " + this.owner);
            if (this.Battery != null)
            {
                if (this.Battery.Model != null)
                    builder.AppendLine("Battery Model: " + this.Battery.Model);
                if (this.Battery.Type != null)
                    builder.AppendLine("Battery Type: " + this.Battery.Type);
                if (this.Battery.HoursIdle != null)
                    builder.AppendLine("Hours Idle: " + this.Battery.HoursIdle +"H");
                if (this.Battery.HoursTalk != null)
                    builder.AppendLine("Hours Talk: " + this.Battery.HoursTalk + "H");
            }
            if (this.Display != null)
            {
                if (this.Display.Size != null)
                    builder.AppendLine("Display Size: " + this.Display.Size + @"""");
                if (this.Display.NumberOfColors != null)
                    builder.AppendLine("Number Of Colors: " + this.Display.NumberOfColors);
            }

            return builder.ToString().Trim();
        }
    }
}