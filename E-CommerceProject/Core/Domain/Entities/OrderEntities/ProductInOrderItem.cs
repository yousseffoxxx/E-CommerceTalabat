namespace Domain.Entities.OrderEntities
{
    public class ProductInOrderItem
    {
        public ProductInOrderItem()
        {

        }
        public ProductInOrderItem(int productid, string productName, string pictureUrl)
        {
            ProductId = productid;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }

    }
}
