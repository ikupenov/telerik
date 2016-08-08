namespace Cosmetics.Tests.Engine
{
    using System.Collections.Generic;

    using Cosmetics.Engine;
    using Contracts;

    internal class CosmeticsEngineExtended : CosmeticsEngine
    {
        public CosmeticsEngineExtended(ICosmeticsFactory factory, IShoppingCart shoppingCart) : base(factory, shoppingCart)
        {
        }

        public IDictionary<string, ICategory> Categories
        {
            get
            {
                return base.categories;
            }
        }

        public IDictionary<string, IProduct> Products
        {
            get
            {
                return base.products;
            }
        }
    }
}
