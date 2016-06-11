namespace Main
{
    public class Call
    {
        private string date;
        private string time;
        private string dialedPhoneNumber;
        private ushort duration;

        public Call (string date, string time, string dialedPhoneNumber, ushort duration)
        {
            this.date = date;
            this.time = time;
            this.dialedPhoneNumber = dialedPhoneNumber;
            this.duration = duration;
        }

        public string CallTime
        {
            get { return this.time; }
        }

        public string CallDate
        {
            get { return this.date; }
        }

        public string GetDialedPhoneNumber
        {
            get { return this.dialedPhoneNumber; }
        }

        public ushort CallDuration
        {
            get { return this.duration; }
        }
    }
}
