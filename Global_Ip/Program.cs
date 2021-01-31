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

        static void center(string message)
        {
            int screenWidth = Console.WindowWidth;
            int stringWidth = message.Length;
            int spaces = (screenWidth / 2) + (stringWidth / 2);

            Console.WriteLine(message.PadLeft(spaces));
        }

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

        public static void loadingBar()
        {

            string pentagon = @"
 _____   ___  ____________ _____ _____   ___   _   _______ _____      
/  __ \ / _ \ | ___ \ ___ \  ___|  __ \ / _ \ | \ | |  _  \  _  |     
| /  \// /_\ \| |_/ / |_/ / |__ | |  \// /_\ \|  \| | | | | | | |     
| |    |  _  ||    /|    /|  __|| | __ |  _  || . ` | | | | | | |     
| \__/\| | | || |\ \| |\ \| |___| |_\ \| | | || |\  | |/ /\ \_/ / _ _ 
 \____/\_| |_/\_| \_\_| \_\____/ \____/\_| |_/\_| \_/___/  \___(_|_|_)
                                                                      
                                                                      
";
            using (StringReader reader = new StringReader(pentagon))
            {
                Console.WriteLine("\n\n\n\n");
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

            ProgressBarCiz(7, 15, 100, 2, ConsoleColor.Green);
            Console.WriteLine("\n\n\n\n");
            center("Pressione qualquer tecla para continuar!!!");
            Console.Read();
        }

    static async System.Threading.Tasks.Task Main(string[] args)
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

            try
            {
                using (WebClient client = new WebClient())
                {
                    using (client.OpenRead("http://www.google.com/"))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        loadingBar();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        var httpClient = new HttpClient();
                        var ip = await httpClient.GetStringAsync("https://api.ipify.org");
                        var geoString = String.Format("http://ip-api.com/json/{0}?fields=26341375", ip);
                        JObject parsed = JObject.Parse(await httpClient.GetStringAsync(geoString));

                        using (StringReader reader = new StringReader(info))
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

                        //Console.WriteLine(info);
                        Console.WriteLine();

                        center($"Seu endereço IP na internet: {ip}\n");

                        var table = new ConsoleTable("Names", "values");

                        foreach (var pair in parsed)
                        {
                            //Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                            table.AddRow(pair.Key, pair.Value);
                        }

                        table.Write(Format.Alternative);

                        Console.Read();
                    }
                }
            }
            catch
            {
                center("Verifique sua conexão com a internet e tente novamente!!!");
            }
        }
    }
}
