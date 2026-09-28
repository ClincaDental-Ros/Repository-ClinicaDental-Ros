namespace Domain.Model
{
    public class Consulta
    {
        public int Id { get; set; }
        public int TurnoId { get; set; }
        public TurnoOdontologico? Turno { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public string Diagnostico { get; set; } = string.Empty; 
        public bool Estado { get; set; } = true;
        public string Tratamiento { get; set; } = string.Empty;
        public bool AnestesiaLocal { get; set; } = false;
        public bool Radiografias { get; set; } = false;
        public string? Valoracion { get; set; }
        public int? CalificacionEstrellas { get; set; } 
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
            Validate();
        }

        public void Validate()
        {
            if (Id < 0)
                throw new ArgumentException("El ID de la consulta no puede ser negativo.", nameof(Id));

            if (TurnoId <= 0)
                throw new ArgumentException("El ID del turno es obligatorio y debe ser mayor a cero.", nameof(TurnoId));

            if (string.IsNullOrWhiteSpace(Diagnostico))
                throw new ArgumentException("El diagnóstico es obligatorio.", nameof(Diagnostico));

            if (string.IsNullOrWhiteSpace(Tratamiento))
                throw new ArgumentException("El tratamiento es obligatorio.", nameof(Tratamiento));

            if (CalificacionEstrellas.HasValue && (CalificacionEstrellas.Value < 1 || CalificacionEstrellas.Value > 5))
                throw new ArgumentOutOfRangeException(nameof(CalificacionEstrellas), "La calificación debe estar entre 1 y 5 estrellas.");
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El ID de la consulta no puede ser negativo.", nameof(id));
            Id = id;
        }

        public void SetObservac(string observaciones) => Observaciones = observaciones ?? string.Empty;

        public void SetDiag(string diagnostico)
        {
            if (string.IsNullOrWhiteSpace(diagnostico))
                throw new ArgumentException("El diagnóstico es obligatorio.", nameof(diagnostico));
            Diagnostico = diagnostico;
        }

        public void SetTratamiento(string tratamiento)
        {
            if (string.IsNullOrWhiteSpace(tratamiento))
                throw new ArgumentException("El tratamiento es obligatorio.", nameof(tratamiento));
            Tratamiento = tratamiento;
        }

        public void SetEstado(bool estado) => Estado = estado;

        public void SetValoracion(string? valoracion) => Valoracion = valoracion;

        public void SetCalificacion(int? calificacion)
        {
            if (calificacion.HasValue && (calificacion.Value < 1 || calificacion.Value > 5))
                throw new ArgumentOutOfRangeException(nameof(calificacion), "La calificación debe estar entre 1 y 5 estrellas.");
            CalificacionEstrellas = calificacion;
        }
    }
}
