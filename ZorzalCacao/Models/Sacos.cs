using System.ComponentModel.DataAnnotations;

namespace ZorzalCacao.Models;

public class Sacos
{
    [Key]
    public int SacoId { get; set; } = 1;
    public double CantidadPesada { get; set; }
}
