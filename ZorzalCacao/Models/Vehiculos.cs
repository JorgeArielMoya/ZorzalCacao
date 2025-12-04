using System.ComponentModel.DataAnnotations;

namespace ZorzalCacao.Models;
public class Vehiculo
{
    [Key]
    public int VehiculoId { get; set; }

    [Required(ErrorMessage = "La marca es obligatoria")]
    public string Marca { get; set; } = string.Empty;

    [Required(ErrorMessage = "El modelo es obligatorio")]
    public string Modelo { get; set; } = string.Empty;

    [Required(ErrorMessage = "La placa es obligatoria")]
    public string Placa { get; set; } = string.Empty;

    [Range(1980, 2100, ErrorMessage = "El año debe ser válido")]
    public int Anio { get; set; }

    [Required(ErrorMessage = "El color es obligatorio")]
    public string Color { get; set; } = string.Empty;

    [Required(ErrorMessage = "El tipo de vehículo es obligatorio")]
    public string TipoVehiculo { get; set; } = string.Empty;
    public int? ChoferId { get; set; }   
    public Choferes? Chofer { get; set; }  
}

