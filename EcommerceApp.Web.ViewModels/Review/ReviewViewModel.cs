namespace EcommerceApp.Web.ViewModels.Review
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public string User { get; set; } = string.Empty;
    }
}
