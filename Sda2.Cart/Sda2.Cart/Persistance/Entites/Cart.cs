using System.ComponentModel.DataAnnotations;

namespace Sda2.Cart.Persistance.Entites;

public class Cart
{
    [Key]
    public int CardId { get; set; }

    [Required]
    public int Qty { get; set; } = 0;

    [Required]
    public int ProductId { get; set; }

    [Required]
    public int CID { get; set; }

    public CartInprogress? CartInprogress { get; set; }
}
