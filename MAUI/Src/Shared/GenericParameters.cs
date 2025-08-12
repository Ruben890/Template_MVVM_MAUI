namespace Shared
{
    public class GenericParameters
    {
        public string? Services { get; set; } = null!;
        public string? User { get; set; } = null!;
        public DateOnly? Fecha { get; set; } = null!;
        public TimeOnly? Hora { get; set; } = null!;
        public bool? isSapRequest { get; set; } = null;
        public DateTime? GetDateTime()
        {
            if (Fecha.HasValue && Hora.HasValue)
            {
                return Fecha.Value.ToDateTime(Hora.Value);
            }

            return null;
        }
    }
}
