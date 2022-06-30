using System;
using System.IO;
using System.Net;
using System.Net.Http;
using ConsoleTables;
using Newtonsoft.Json.Linq;

namespace Global_Ip
{
    class Program
    {

        // Função responsável por centralizar o texto no terminal
        static void Center(string message, bool slow = false,  int time = 0)
        {
            int screenWidth = Console.WindowWidth;
            int stringWidth = message.Length;
            int spaces = (screenWidth / 2) + (stringWidth / 2);

            if(slow == false)
            {
                Console.WriteLine(message.PadLeft(spaces));
            }
            else
            {
                TypeLine(message.PadLeft(spaces), time);
                Console.WriteLine();
            }
        }

        // Função responsável por simular barra de carregamento no terminal
        public static void ProgressBarCiz(int sol, int ust, int deger, int isaret, ConsoleColor color)
        {
            char[] symbol = new char[5] { '\u25A0', '\u2592', '\u2588', '\u2551', '\u2502' };

            int maxBarSize = Console.BufferWidth - 1;
            int barSize = deger;
            decimal f = 1;
            if (barSize + sol > maxBarSize)
            {
                barSize = maxBarSize - (sol + 5);
                f = (decimal)deger / (decimal)barSize;
            }
            Console.CursorVisible = false;
            Console.ForegroundColor = color;
            Console.SetCursorPosition(sol + 5, ust);

            for (int i = 0; i < barSize + 1; i++)
            {
                System.Threading.Thread.Sleep(10);
                Console.Write(symbol[isaret]);
                Console.SetCursorPosition(sol, ust);
                Console.Write("%" + (i * f).ToString("0,0"));
                Console.SetCursorPosition(sol + 5 + i, ust);
            }
            Console.ResetColor();
        }

        // Função responsável por fazer o efeito de escrita letra por letra
        public static void TypeLine(string line, int time)
        {
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                System.Threading.Thread.Sleep(time);
            }
        }

        // Função com o código necessário para a tela de carregamento
        public static void LoadingScreen()
        {

            string loading = @"
 _____   ___  ____________ _____ _____   ___   _   _______ _____      
/  __ \ / _ \ | ___ \ ___ \  ___|  __ \ / _ \ | \ | |  _  \  _  |     
| /  \// /_\ \| |_/ / |_/ / |__ | |  \// /_\ \|  \| | | | | | | |     
| |    |  _  ||    /|    /|  __|| | __ |  _  || . ` | | | | | | |     
| \__/\| | | || |\ \| |\ \| |___| |_\ \| | | || |\  | |/ /\ \_/ / _ _ 
 \____/\_| |_/\_| \_\_| \_\____/ \____/\_| |_/\_| \_/___/  \___(_|_|_)
                                                                      
                                                                      
";
            using (StringReader reader = new StringReader(loading))
            {
                Console.WriteLine("\n\n\n\n");
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                        TypeLine(line, 3);
                        Console.WriteLine();
                    }
                } while (line != null);
            }

            ProgressBarCiz(7, 15, 100, 2, ConsoleColor.Green);
            Console.WriteLine("\n\n\n\n");
            Center("Pressione qualquer tecla para continuar!!!", true, 60);
            Console.ReadKey();
            Console.Clear();
        }

        // Função com o código necessário para a tela do criador
        public static void AuthorLoadingScreen()
        {

            string info = @"
______                               _       _           _                             
|  _  \                             | |     (_)         | |                         _  
| | | |___  ___  ___ _ ____   _____ | |_   ___ _ __   __| | ___    _ __   ___  _ __(_) 
| | | / _ \/ __|/ _ \ '_ \ \ / / _ \| \ \ / / | '_ \ / _` |/ _ \  | '_ \ / _ \| '__|   
| |/ /  __/\__ \  __/ | | \ V / (_) | |\ V /| | | | | (_| | (_) | | |_) | (_) | |   _  
|___/ \___||___/\___|_| |_|\_/ \___/|_| \_/ |_|_| |_|\__,_|\___/  | .__/ \___/|_|  (_) 
                                                                  | |                  
                                                                  |_|                  
                     _   _ _            _     _        ______                                              
                    | | | (_)          | |   | |       | ___ \                                             
                    | | | |___   ____ _| | __| | ___   | |_/ /___   __ _ _   _  ___                        
                    | | | | \ \ / / _` | |/ _` |/ _ \  |    // _ \ / _` | | | |/ _ \                       
                    \ \_/ / |\ V / (_| | | (_| | (_) | | |\ \ (_) | (_| | |_| |  __/                       
                     \___/|_| \_/ \__,_|_|\__,_|\___/  \_| \_\___/ \__, |\__,_|\___|                       
                                                                      | |                                  
                                                                      |_|                                  
";
            using (StringReader reader = new StringReader(info))
            {
                Console.WriteLine("\n\n\n\n");
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                        TypeLine(line, 3);
                        Console.WriteLine();
                    }
                } while (line != null);
            }

            Console.WriteLine("\n\n\n\n");
            Center("Pressione qualquer tecla para continuar!!!", true, 60);
            Console.ReadKey();
            Console.Clear();
        }

        // Função com o código necessário para a tela do criador
        public static void LogoLoadingScreen()
        {

            string info = @"
   _____ _      ____  ____          _              _____ _____  
  / ____| |    / __ \|  _ \   /\   | |            |_   _|  __ \ 
 | |  __| |   | |  | | |_) | /  \  | |              | | | |__) |
 | | |_ | |   | |  | |  _ < / /\ \ | |              | | |  ___/ 
 | |__| | |___| |__| | |_) / ____ \| |____         _| |_| |     
  \_____|______\____/|____/_/    \_\______|       |_____|_|     
                                                                
";
            using (StringReader reader = new StringReader(info))
            {
                Console.WriteLine("\n\n\n\n");
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                        TypeLine(line, 3);
                        Console.WriteLine();
                    }
                } while (line != null);
            }

            Console.WriteLine("\n\n\n\n");
            Center("Pressione qualquer tecla para continuar!!!", true, 60);
            Console.ReadKey();
            Console.Clear();
        }


        static async System.Threading.Tasks.Task Main()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (client.GetAsync("http://www.google.com/"))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        LoadingScreen();
                        Console.ForegroundColor = ConsoleColor.Green;
                        
                        // Pegar o IP e dados realacionados a ele
                        var httpClient = new HttpClient();
                        var ip = await httpClient.GetStringAsync("https://api.ipify.org");
                        var geoString = String.Format("http://ip-api.com/json/{0}?fields=26341375", ip);
                        JObject parsed = JObject.Parse(await httpClient.GetStringAsync(geoString));

                        AuthorLoadingScreen();
                        LogoLoadingScreen();
                        //Console.WriteLine(info);
                        Console.WriteLine();

                        Center($"Seu endereço IP na internet: {ip}\n", true, 60);

                        System.Threading.Thread.Sleep(150);

                        var table = new ConsoleTable("Names", "values");

                        foreach (var pair in parsed)
                        {
                            //Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                            table.AddRow(pair.Key, pair.Value);
                        }

                        //table.Write(Format.Alternative);

                        using (StringReader reader = new StringReader(table.ToString().Remove(table.ToString().TrimEnd().LastIndexOf(Environment.NewLine))))
                        {
                            string line = string.Empty;
                            do
                            {
                                line = reader.ReadLine();
                                if (line != null)
                                {
                                    Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                                    Console.WriteLine(line);
                                }
                            } while (line != null);
                        }

                        Console.ReadKey();
                    }
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Center("Verifique sua conexão com a internet e tente novamente!!!");
                Console.ReadKey();
            }
        }
    }
}