namespace Domain.Model
{
    public class Consulta
    {
        public int Id { get; set; }
        public int TurnoId { get; set; }
        public TurnoOdontologico? Turno { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public string Diagnostico { get; set; } = string.Empty; // CIE-10 u observaciones diagnósticas
        public bool Estado { get; set; } = true;
        public string Tratamiento { get; set; } = string.Empty;
        public bool AnestesiaLocal { get; set; } = false;
        public bool Radiografias { get; set; } = false;
        public string? Valoracion { get; set; }
        public int? CalificacionEstrellas { get; set; } // 1 a 5 estrellas
        public DateTime Fecha { get; set; } = DateTime.Now;

        public Consulta() { }

        public Consulta(int id, int turnoId, string diagnostico, string tratamiento, string observaciones, bool anestesiaLocal = false, bool radiografias = false, string? valoracion = null, int? calificacionEstrellas = null)
        {
            Id = id;
            TurnoId = turnoId;
            Diagnostico = diagnostico;
            Tratamiento = tratamiento;
            Observaciones = observaciones;
            AnestesiaLocal = anestesiaLocal;
            Radiografias = radiografias;
            Valoracion = valoracion;
            CalificacionEstrellas = calificacionEstrellas;
            Fecha = DateTime.Now;
        }

        public void SetObservac(string observaciones) => Observaciones = observaciones;
        public void SetDiag(string diagnostico) => Diagnostico = diagnostico;
        public void SetEstado(bool estado) => Estado = estado;
        public void SetValoracion(string? valoracion) => Valoracion = valoracion;
    }
}
