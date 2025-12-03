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

    [Required(ErrorMessage = "El año es obligatorio")]
    public int Anio { get; set; }

    [Required(ErrorMessage = "El color es obligatorio")]
    public string Color { get; set; } = string.Empty;

    [Required(ErrorMessage = "El tipo de vehículo es obligatorio")]
    public string TipoVehiculo { get; set; } = string.Empty;

    // 🔹 Relación futura con Chofer (AÚN NO IMPLEMENTADO)
    public int? ChoferId { get; set; }   // Nullable porque aún no existe Chofer
    // public Chofer? Chofer { get; set; }  // Se activará cuando crees el modelo Chofer
}

