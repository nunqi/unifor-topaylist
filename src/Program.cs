using System;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {

            Controller controller = new Controller();
            
            while (true) {

                String comando = Console.ReadLine();
                switch(comando) {
                    case "add": controller.Add();
                        break;
                    case "list": controller.PrintList();
                        break;
                    case "exit": goto exit;
                    default: Console.WriteLine("Comando inválido");
                        break;
                }

            }
            exit:; // Ficou meio estranho, mas precisa do ; depois do label

        }
    }
}
