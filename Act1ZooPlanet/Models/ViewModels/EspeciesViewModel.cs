namespace Act1ZooPlanet.Models.ViewModels
{
    public class EspeciesViewModel
    {
        public int IdClase { get; set; }
        public string NombreClase { get; set; }
        public IEnumerable<EspecieModel> Especie { get; set; } 
    }
    public class EspecieModel
    {
        public int IdEspecie { get; set; }
        public string NombreEspecie { get; set; } = null!;
    }
}
