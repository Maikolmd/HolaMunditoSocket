using HolaMunditoSocket.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HolaMunditoSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);

            Console.WriteLine("Iniciando Servidor en puerto {0}", puerto);
            ServerSocket servidor = new ServerSocket(puerto);

            if (servidor.Iniciar())
            {
                //Ok, pude conectar
                Console.WriteLine("Servidor iniciado");
                //Solicitando clientes infinitamente
                while (true)
                {
                    Console.WriteLine("Esperando Cliente");
                    Socket socketCliente = servidor.ObtenerCliente();
                    //Construir el mecanismo para escribirle y leerle
                    ClienteCom cliente = new ClienteCom(socketCliente);
                    //aqui está el protocolo de comunicación, ambos deben conocerlo
                    cliente.Escribir("Hola Mundo cliente, dime tu nombre:");
                    string respuesta = cliente.Leer();
                    Console.WriteLine("El cliente mandó:{0}", respuesta);
                    cliente.Escribir("Chao, loh vimoh "+respuesta);
                    cliente.Desconectar();


                }

            }  else
            {
                Console.WriteLine("Error, el puerto {0} está en uso", puerto);
            }

        }
    }
}
