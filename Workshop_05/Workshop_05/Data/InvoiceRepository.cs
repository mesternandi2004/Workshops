using Workshop_05.Models;

namespace Workshop_05.Data
{
    public class InvoiceRepository
    {
        private static List<Invoice> invoices = new List<Invoice>();
        private static int nextId = 1;

        public List<Invoice> GetAll()
        {
            return invoices;
        }

        public Invoice GetById(int id)
        {
            return invoices.FirstOrDefault(i => i.Id == id);
        }

        public void Add(Invoice invoice)
        {
            invoice.Id = nextId++;
            invoices.Add(invoice);
        }

        public void Update(Invoice invoice)
        {
            var existing = GetById(invoice.Id);
            if (existing != null)
            {
                existing.PayerName = invoice.PayerName;
                existing.Amount = invoice.Amount;
                existing.IsPaid = invoice.IsPaid;
            }
        }

        public void Delete(int id)
        {
            var invoice = GetById(id);
            if (invoice != null)
            {
                invoices.Remove(invoice);
            }
        }
    }
}
