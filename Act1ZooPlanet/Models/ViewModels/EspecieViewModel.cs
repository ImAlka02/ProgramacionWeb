namespace Act1ZooPlanet.Models.ViewModels
{
    public class EspecieViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Clase { get; set; } = null!;
        public double? Peso { get; set; }
        public int? Size { get; set; }
        public string Habitad { get; set; } = null!;
        public string Observaciones { get; set;} = null!;
    }
}
