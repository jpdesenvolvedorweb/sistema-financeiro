namespace Model.Entity.Exceptions
{
    public static class Message
    {

        private static string message;

        public static void MessageError(string error)
        {
            message = error;
        }

        public static string Mostrar()
        {
            return message;
        }
    }
}
