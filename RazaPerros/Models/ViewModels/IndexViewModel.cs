namespace RazaPerros.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<char> Letra { get; set; } = null!;
        public IEnumerable<Raza> Razas { get; set; } = null!;
    }
    
    public class Raza
    {
        public uint Id { get; set; }
        public string NombreRaza { get; set; } = null!;
    }
}
