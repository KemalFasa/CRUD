using SQL.Domain.Common;
namespace SQL.Domain.Entities
{
    public class Tran : EntityBase
    {
        public string UserName { get; set; } = default!; 
        public decimal TotalPrice { get; set; }

        // BillingAddress
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
      
    }
}