namespace Domain.Model
{
    public class Consulta
    {
        public int Id { get; private set; }
        public int TurnoId { get; private set; }
        public TurnoOdontologico? Turno { get; private set; }
        public string Observaciones { get; private set; } = string.Empty;
        public string Diagnostico { get; private set; } = string.Empty; 
        public bool Estado { get; private set; } = true;
        public string Tratamiento { get; private set; } = string.Empty;
        public bool AnestesiaLocal { get; private set; } = false;
        public bool Radiografias { get; private set; } = false;
        public string? Valoracion { get; private set; }
        public int? CalificacionEstrellas { get; private set; } 
        public DateTime Fecha { get; private set; } = DateTime.Now;

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

        public void SetTurnoId(int turnoId)
        {
            if (turnoId <= 0)
                throw new ArgumentException("El ID del turno es obligatorio y debe ser mayor a cero.", nameof(turnoId));
            TurnoId = turnoId;
        }

        public void SetObservac(string observaciones) => Observaciones = observaciones ?? string.Empty;
        public void SetObservaciones(string observaciones) => SetObservac(observaciones);

        public void SetDiag(string diagnostico)
        {
            if (string.IsNullOrWhiteSpace(diagnostico))
                throw new ArgumentException("El diagnóstico es obligatorio.", nameof(diagnostico));
            Diagnostico = diagnostico;
        }
        public void SetDiagnostico(string diagnostico) => SetDiag(diagnostico);

        public void SetTratamiento(string tratamiento)
        {
            if (string.IsNullOrWhiteSpace(tratamiento))
                throw new ArgumentException("El tratamiento es obligatorio.", nameof(tratamiento));
            Tratamiento = tratamiento;
        }

        public void SetEstado(bool estado) => Estado = estado;

        public void SetAnestesiaLocal(bool anestesiaLocal) => AnestesiaLocal = anestesiaLocal;

        public void SetRadiografias(bool radiografias) => Radiografias = radiografias;

        public void SetValoracion(string? valoracion) => Valoracion = valoracion;

        public void SetCalificacion(int? calificacion)
        {
            if (calificacion.HasValue && (calificacion.Value < 1 || calificacion.Value > 5))
                throw new ArgumentOutOfRangeException(nameof(calificacion), "La calificación debe estar entre 1 y 5 estrellas.");
            CalificacionEstrellas = calificacion;
        }

        public void SetFecha(DateTime fecha) => Fecha = fecha;
    }
}
