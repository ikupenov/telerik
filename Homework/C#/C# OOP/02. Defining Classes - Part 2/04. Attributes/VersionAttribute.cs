namespace NumberMatrix
{
    using System;

    public class VersionAttribute : Attribute
    {
        private ushort Major { get; set; }
        private ushort Minor { get; set; }

        public VersionAttribute(ushort major, ushort minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public string Version
        {
            get
            {
                return string.Format("{0}.{1}", this.Major, this.Minor);
            }
        }
    }
}