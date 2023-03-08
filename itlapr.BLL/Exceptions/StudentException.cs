using System;


namespace itlapr.BLL.Exceptions
{
    public class StudentException : Exception
    {
        public StudentException(string message) : base(message)
        {
            // usted agregar x logica: Enviar una notificacion, persistir local file system, bd, etc.//
        }
    }
}
