namespace DatingAPP.Extinsion
{
    public static class DateTimeExtinsion
    {

        public static int calculateAge(this DateTime dob)
        {
            var today=DateOnly.FromDateTime(DateTime.UtcNow);
            var x=DateOnly.FromDateTime(dob);
            var age=today.Year-dob.Year;
            if (x > today.AddYears(-age)) 
            { age--; }

            return age;
        }
    }
}
