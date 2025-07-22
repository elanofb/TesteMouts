namespace MoutsOrder.Common.Security
{
    /// <summary>
    /// Define o contrato para representação de um usuário no sistema.
    /// </summary>
    public interface IOrder
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string Customer { get; set; }
        public string ExternalId { get; set; }
        public decimal TotalValue { get; set; }
    }
}
