namespace SchoolClasses.Utilities
{
    public static class UniqueClassNumber
    {
        private static int counter;

        static UniqueClassNumber()
        {
            counter = 1;
        }

        public static int GenerateUniqueClassNumber()
        {
            return counter++;
        }
    }
}
