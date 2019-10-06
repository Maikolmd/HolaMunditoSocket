using ClienteHolaMunditoS.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteHolaMunditoS
{
    class Program
    {
        static void Main(string[] args)
        {
            //  int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            // string servidor = ConfigurationManager.AppSettings["servidor"];
            Console.WriteLine("Ingrese servidor");
            string servidor = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese puerto");
            int puerto = Convert.ToInt32(Console.ReadLine().Trim());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Conectando a Servidor {0} en puerto {1}", servidor, puerto);
            ClienteSocket clienteSocket = new ClienteSocket(servidor, puerto);
            if (clienteSocket.Conectar())
            {
                Console.WriteLine("Conectado..");
                //recibir lo que envió el servidor, el orden de estas acciones depende del protocolo
                string mensaje = clienteSocket.Leer();
                Console.WriteLine("M:{0}", mensaje);
                string nombre = Console.ReadLine().Trim();
                clienteSocket.Escribir(nombre);
                mensaje = clienteSocket.Leer();
                Console.WriteLine("M:{0}", mensaje);
                clienteSocket.Desconectar();

            } else
            {
                Console.WriteLine("Error de Comunicación");
            }
            Console.ReadKey();

        }
    }
}
