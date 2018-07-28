using System;
using EmailService;
using System.Net.Mail;

namespace EmailServiceCliente
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GestorCorreo gestor = new GestorCorreo();
                MailMessage correo = new MailMessage("tucuenta@gmail.com", "tucuenta@gmail.com", "Reporte Mensual.", "Por favor ve el reporte adjunto.");  
                gestor.EnviarCorreo(correo);
                gestor.EnviarCorreo("tucuenta@gmail.com", "Prueba", "Mensaje en texto plano");
                gestor.EnviarCorreo("tucuenta@gmail.com", "Prueba", "<h1>Mensaje en HTML<h1><p><s>Super Awesome html Message.</s></p>",true);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}