using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace DeliveryService.Models;

[Table("Orders")]
public class Order
{
    [Key]
    public int Id { get; set; }
        
    [Required(ErrorMessage = "ошибка: город отправителя обязателен")]
    [Display(Name = "город отправителя")]
    [StringLength(20)]
    public string SenderCity { get; set; }
        
    [Required(ErrorMessage = "ошибка: адрес отправителя обязателен")]
    [Display(Name = "адрес отправителя")]
    [StringLength(20)]
    public string SenderAddress { get; set; }
        
    [Required(ErrorMessage = "ошибка: город получателя обязателен")]
    [Display(Name = "город получателя")]
    [StringLength(20)]
    public string ReceiverCity { get; set; }
        
    [Required(ErrorMessage = "ошибка: адрес получателя обязателен")]
    [Display(Name = "адрес получателя")]
    [StringLength(20)]
    public string ReceiverAddress { get; set; }
        
    [Required(ErrorMessage = "ошибка: ес груза обязателен")]
    [Display(Name = "вес груза в кг")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Weight { get; set; }
        
    [Required(ErrorMessage = "ошибка дата забора груза обязательна")]
    [Display(Name = "дата забора груза")]
    [DataType(DataType.Date)]
    public DateTime PickupDate { get; set; }
        
    [Display(Name = "номер заказа")]
    public Guid OrderNumber { get; set; }
        
    [Display(Name = "дата создания")]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}