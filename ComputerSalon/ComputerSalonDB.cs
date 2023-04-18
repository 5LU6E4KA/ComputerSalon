namespace ComputerSalon
{
    static class ComputerSalonDB
    {
        private static readonly Entities.Entities _context = new Entities.Entities();

        public static Entities.Entities Context => _context;  
    }
}
