namespace Refactor
{
    using System;

    using Common;

    public class ConditionalStatements
    {
        public void RefactorIfStatements()
        {
            Potato potato = new Potato();

            if (potato == null)
            {
                throw new NullReferenceException("Potato cannot be null!");
            }

            if (!potato.HasNotBeenPeeled && !potato.IsRotten)
            {
                this.Cook(potato);
            }

            // ------------------------------
            const int MIN_X = default(int);
            const int MAX_X = default(int);
            const int MIN_Y = default(int);
            const int MAX_Y = default(int);

            int x = default(int);
            int y = default(int);

            bool isXInRange = x >= MIN_X && x <= MAX_X;
            bool isYInRange = y >= MIN_Y && y <= MAX_Y;

            bool shouldNotVisitCell = default(bool);

            if (isXInRange && isYInRange && !shouldNotVisitCell)
            {
                this.VisitCell();
            }
        }

        private void VisitCell()
        {
            throw new NotImplementedException();
        }

        private void Cook(Potato potato)
        {
            throw new NotImplementedException();
        }
    }
}