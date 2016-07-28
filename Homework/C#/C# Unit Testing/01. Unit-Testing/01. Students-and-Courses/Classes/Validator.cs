namespace Classes
{
    using System;

    public static class Validator
    {
        public static void NullValidator(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}