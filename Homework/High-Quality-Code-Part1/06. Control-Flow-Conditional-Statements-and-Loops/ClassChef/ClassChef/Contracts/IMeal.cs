namespace ClassChef.Contracts
{
    using System.Collections.Generic;

    public interface IMeal
    {
        int Calories { get; set; }

        int PortionSize { get; set; }

        IList<IIngredient> Ingredients { get; set; }
    }
}