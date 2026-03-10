namespace WebApiProject.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int PatientId { get; set; }
        public string ReferringPhysician { get; set; }
        public string DiagnosisCodes { get; set; }
        public string ExamType { get; set; }
        public string Priority { get; set; }
        public string AuthStatus { get; set; }
        public string ClinicalNotes { get; set; }
        public string InsurancePreAuthInfo { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
        public double TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
    }

    public class OrderItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
