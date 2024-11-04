using System.ComponentModel.DataAnnotations;

namespace Sda2.Cart.Persistance.Entites;

public class CartInprogress
{
    [Key]
    public int CID { get; set; }

    [Required]
    public int TicketId { get; set; }

    [Required]
    public int CustomerId { get; set; }

    public ICollection<Cart> Carts { get; set; } = new List<Cart>();
    public ICollection<ItemList> ItemLists { get; set; } = new List<ItemList>();
}
