using System;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Model
{
    public class Paciente : Persona
    {
        public int Id { get; set; }
        public bool EstadoHabilitado { get; private set; }

        public Paciente(int id, string nombre, string apellido, int dni, int telefono, string mail, string domicilio, bool estadoHabilitado = true)
            : base(nombre, apellido, dni, telefono, mail, domicilio)
        {
            Id = id;
            SetEstadoHabilitado(estadoHabilitado);
        }

        public void SetEstadoHabilitado(bool habilitado)
        {
            EstadoHabilitado = habilitado;
        }
    }
}