namespace Podium.Service.Primitives.Models.Product
{
    public class ProductResourceModel
    {
        public string Id { get; set; }

        public string Lender { get; set; }
        public decimal InterestRate { get; set; }
        public string LoanType { get; set; }
        public decimal LoanToValue { get; set; }
    }
}