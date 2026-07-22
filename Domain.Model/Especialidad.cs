namespace Domain.Model
{
	public class Especialidad
	{
		public string Nombre { get; private set; }
		public string Descripcion { get; private set; }
		public int Id { get; private set; }
		private static int _nextId = 0;


		public Especialidad(string nombre, string descripcion)
		{
			SetNom(nombre);
			SetDesc(descripcion);
			_nextId++;
			Id = _nextId;
		}


		public void SetNom(string nombre)
		{
			if (string.IsNullOrWhiteSpace(nombre))
				throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));
			Nombre = nombre;
		}

		public void SetDesc(string descripcion)
		{
			if (string.IsNullOrWhiteSpace(descripcion))
				throw new ArgumentException("El descripción no puede ser nulo o vacío.", nameof(descripcion));
			Descripcion = descripcion;
		}
	}
