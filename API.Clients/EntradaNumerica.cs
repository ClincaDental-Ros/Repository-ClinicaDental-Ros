using System.Globalization;

namespace API.Clients
{
    /// <summary>
    /// Interpreta importes escritos por el usuario sin depender de la configuración regional de la PC:
    /// "980.50", "980,50", "1.250,75" y "1,250.75" se leen igual. El último punto o coma es el separador decimal.
    /// </summary>
    public static class EntradaNumerica
    {
        public static bool TryParseImporte(string? texto, out decimal importe)
        {
            importe = 0m;
            if (string.IsNullOrWhiteSpace(texto)) return false;

            var limpio = texto.Trim().Replace("$", "").Replace(" ", "");
            var ultimoSeparador = limpio.LastIndexOfAny(new[] { '.', ',' });

            if (ultimoSeparador >= 0)
            {
                var decimales = limpio.Length - ultimoSeparador - 1;
                var separadores = limpio.Count(c => c == '.' || c == ',');
                // Un solo separador seguido de exactamente 3 dígitos ("1.250") se toma como miles.
                var esMiles = separadores == 1 && decimales == 3;

                var parteEntera = limpio[..ultimoSeparador].Replace(".", "").Replace(",", "");
                var parteDecimal = limpio[(ultimoSeparador + 1)..];
                limpio = esMiles ? parteEntera + parteDecimal : $"{parteEntera}.{parteDecimal}";
            }

            return decimal.TryParse(limpio, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                CultureInfo.InvariantCulture, out importe);
        }
    }
}
