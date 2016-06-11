namespace Main
{
    public class Display
    {
        private double? displaySize;
        private ulong? displayNumberOfColors;

        public Display(double? size = null, ulong? numberOfColors = null)
        {
            this.displaySize = size;
            this.displayNumberOfColors = numberOfColors;
        }

        public double? Size
        {
            get { return this.displaySize; }
            private set { this.displaySize = value; }
        }

        public ulong? NumberOfColors
        {
            get { return this.displayNumberOfColors; }
            private set { this.displayNumberOfColors = value; }
        }
    }
}
