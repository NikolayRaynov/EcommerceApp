namespace EcommerceApp.Common
{
    public static class EntityValidationConstants
    {
        public static class Product
        {
            public const int ProductNameMinLength = 3;
            public const int ProductNameMaxLength = 85;
            public const int ProductDescriptionMinLength = 10;
            public const int ProductDescriptionMaxLength = 800;
        }
    }
}
