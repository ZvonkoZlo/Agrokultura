namespace Agrokultura.Models
{
    public class CombinedViewModel
    {
         public IEnumerable<Order> Orders { get; set; }
    public IEnumerable<ChorePerson> Chores { get; set; }
    }
}
