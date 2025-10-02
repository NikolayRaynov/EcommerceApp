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
            public const int ImageMaxLength = 2083;
            public const int MinQuantity = 1;
            public const int MaxQuantity = 20;
            public const string ProductPriceMinValue = "5.00";
            public const string ProductPriceMaxValue = "9999.99";
        }

        public static class Order
        {
            public const int OrderAddressMinLength = 10;
            public const int OrderAddressMaxLength = 255;
        }

        public static class Category
        {
            public const int CategoryNameMinLength = 3;
            public const int CategoryNameMaxLength = 45;
        }

        public static class Image
        {
            public const int ImageUrlMaxLength = 2083;
            public const int ImageDescriptionMinLength = 10;
            public const int ImageDescriptionMaxLength = 500;
        }

        public static class Review
        {
            public const int CommentMaxLength = 500;
        }
    }
}
