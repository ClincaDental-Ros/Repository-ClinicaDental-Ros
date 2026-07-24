using System;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Model
{
    public class Paciente : Persona
    {
        public int Id { get; private set; }
        public bool EstadoHabilitado { get; private set; }

        private static int _nextId = 0;

        public Paciente(int id, string nombre, string apellido, int dni, int telefono, string mail, string domicilio, bool estadoHabilitado = true)
            : base(nombre, apellido, dni, telefono, mail, domicilio)
        {
            SetEstadoHabilitado(estadoHabilitado);
            SetIncrementalID();

        }

        public void SetEstadoHabilitado(bool habilitado)
        {
            EstadoHabilitado = habilitado;
        }
        public void SetIncrementalID()
        {
            _nextId++;
            Id = _nextId;
        }
    }
}