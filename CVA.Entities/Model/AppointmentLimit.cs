namespace CVA.Entity.Model
{
    public class AppointmentLimit
    {
        public string AppointmentDate { get; set; } = string.Empty;

        public string AppointmentTime { get; set; } = string.Empty;

        public int DayLimit { get; set; }

        public int TimeLimit { get; set; }
    }
}
