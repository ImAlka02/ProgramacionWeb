namespace RazaPerros.Models.ViewModels
{
    public class InfoRazaViewModel
    {
        public uint Id { get; set; }
        public string NombreRaza { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string OtrosNombres { get; set; } = null!;
        public string Pais { get; set; } = null!;
        public string Peso{ get; set; } = null!;
        public string Altura { get; set; } = null!;
        public uint EsperanzaVida { get; set; }
        public uint NivelEnergia { get; set; }
        public uint FacilidadEntrenamiento { get; set; }
        public uint EjercicioObligatiorio { get; set; }
        public uint AmigableExtraños { get; set; }
        public uint AmigablePerros { get; set; }
        public uint NecesidadCepillado { get; set; }
        public string Patas { get; set; } = null!;
        public string Cola { get; set; } = null!;
        public string Hocico { get; set; } = null!;
        public string Pelo { get; set; } = null!;
        public string Color { get; set; } = null!;

        public IEnumerable<PerroModel> Perros { get; set; } 
    }

    public class PerroModel
    {
        public uint Id { get; set; }
        public string Nombre { get; set; } = null!;

    }
}
