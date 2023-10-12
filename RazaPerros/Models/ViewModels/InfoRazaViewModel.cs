namespace RazaPerros.Models.ViewModels
{
    public class InfoRazaViewModel
    {
        public int Id { get; set; }
        public string NombreRaza { get; set; }
        public string Descripcion { get; set; }
        public string OtrosNombres { get; set; }
        public string Pais { get; set; }
        public double PesoMax{ get; set; }
        public double PesoMin { get; set; }
        public double AlturaMax { get; set; }
        public double AlturaMin { get; set; }
        public string EsperanzaVida { get; set; }
        public int NivelEnergia { get; set; }
        public int FacilidadEntrenamiento { get; set; }
        public int EjercicioObligatiorio { get; set; }
        public int AmigableExtraños { get; set; }
        public int AmigablePerros { get; set; }
        public int NecesidadCepillado { get; set; }
        public string Patas { get; set; }
        public string Cola { get; set; }
        public string Hocico { get; set; }
        public string Pelo { get; set; }
        public string Color { get; set; }

        public IEnumerable<Perro> Perros { get; set; } 
    }

    public class Perro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        
    }
}
