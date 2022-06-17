using System;
using System.Reflection;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Svends_tale
{
    class Program
    {
        public static UserSettings us;

        static List<string> activeCommands;
        static Menu menu;

        static void Main(string[] args)
        {
            us = new UserSettings();

            Load_User_Settings();
            //var value = System.Configuration.ConfigurationManager.AppSettings["a"];
            //Console.WriteLine(value);

            activeCommands = new List<string>();

            string command = "";
            menu = new Menu();

            do
            {
                //main menu
                menu.Run();
                command = Read_Command($"menu-{Program.us.Language}-commands");

                //CHANGE SWITCH TO SWITCH8.0    powered by Oskar Szymański
                switch (command.ToLower())
                {   //new | nowa
                    case string c when c.Equals(activeCommands[1]):
                        break;
                    //load | wczytaj
                    case string c when c.Equals(activeCommands[2]):
                        break;

                    //commands | komendy
                    case string c when c.Equals(activeCommands[3]):
                        do
                        {
                            menu.Show_Commands();
                            command = Read_Command($"commands-{Program.us.Language}-commands").ToLower();
                        } while (command != activeCommands[0]);
                        break;

                    //settings | ustawienia
                    case string c when c.Equals(activeCommands[4]):
                        do
                        {
                            menu.Show_Settings();
                            command = Read_Command($"settings-{Program.us.Language}-commands").ToLower();

                            switch (command)
                            {   //background | tło
                                case string c2 when c2.Equals(activeCommands[1]):
                                    Change_Setting(typeof(ConsoleColor), "ConsoleBackgroundColor");
                                    break;
                                //foreground | czcionka
                                case string c2 when c2.Equals(activeCommands[2]):
                                    Change_Setting(typeof(ConsoleColor), "ConsoleForegroundColor");
                                    break;
                                //language | język
                                case string c2 when c2.Equals(activeCommands[3]):
                                    Change_Setting(typeof(string), "Language");
                                    break;
                                //back | wróć
                                case string c2 when c2.Equals(activeCommands[0]):
                                    break;

                                default:
                                    Console.WriteLine("E404: Command not found!");
                                    break;
                            }
                            Set_Active_Commands($"settings-{Program.us.Language}-commands");
                        } while (command != activeCommands[0]);
                        break;

                    default:
                        Console.Write("Brak opcji. . .");
                        System.Threading.Thread.Sleep(5000);
                        break;
                }
                Set_Active_Commands($"menu-{Program.us.Language}-commands");
            } while (command != activeCommands[0]);
        }

        public static void Set_Active_Commands(string usable)
        {
            activeCommands.Clear();
            //only english works
            //TODO: ADD -pl TO APP.CONFIG
            try
            {
                var value = System.Configuration.ConfigurationManager.AppSettings[usable];
                foreach (string v in value.Split(" "))
                    activeCommands.Add(v.ToLower());
            }
            catch(Exception )
            {
                us.Language = "en";
                us.Save();
            }
        }

        public static string Read_Command(string usable)
        {

            Set_Active_Commands(usable);

            Console.Write(">");
            string userCommand = Console.ReadLine();

            if(activeCommands.Contains(userCommand))
                return userCommand;

            else return "error";
        }

        public static void Change_Setting(Type type, string name)
        {
            dynamic value;
            string command;
            if (type == typeof(ConsoleColor))
            {
                menu.Show_Colors();
                command = Read_Command($"colors-{Program.us.Language}-commands");
                value = command switch
                {
                    string s when s.Equals(activeCommands[1]) => ConsoleColor.Black,
                    string s when s.Equals(activeCommands[2]) => name == "ConsoleBackgroundColor" ? ConsoleColor.DarkBlue : ConsoleColor.Blue,
                    string s when s.Equals(activeCommands[3]) => name == "ConsoleBackgroundColor" ? ConsoleColor.DarkGreen : ConsoleColor.Green,
                    string s when s.Equals(activeCommands[4]) => name == "ConsoleBackgroundColor" ? ConsoleColor.DarkCyan : ConsoleColor.Cyan,
                    string s when s.Equals(activeCommands[5]) => name == "ConsoleBackgroundColor" ? ConsoleColor.DarkRed : ConsoleColor.Red,
                    string s when s.Equals(activeCommands[6]) => name == "ConsoleBackgroundColor" ? ConsoleColor.DarkMagenta : ConsoleColor.Magenta,
                    string s when s.Equals(activeCommands[7]) => name == "ConsoleBackgroundColor" ? ConsoleColor.DarkYellow : ConsoleColor.Yellow,
                    string s when s.Equals(activeCommands[8]) => name == "ConsoleBackgroundColor" ? ConsoleColor.DarkGray : ConsoleColor.Gray,
                    string s when s.Equals(activeCommands[9]) => ConsoleColor.White,
                    _ => name== "ConsoleBackgroundColor" ? us.ConsoleBackgroundColor : us.ConsoleForegroundColor
                };
            }
            else
            {
                menu.Show_Languages();
                command = Read_Command($"languages-commands");
                value = command switch
                {
                    "english" => "en",
                    "polski" => "pl",
                    _=> us.Language
                };
            }

            us.ConsoleBackgroundColor = name == "ConsoleBackgroundColor" ? value : us.ConsoleBackgroundColor;
            us.ConsoleForegroundColor = name == "ConsoleForegroundColor" ? value : us.ConsoleForegroundColor;
            us.Language = name == "Language" ? value : us.Language;

            us.Save();
            Load_User_Settings();
        }

        static void Load_User_Settings()
        {
            Console.BackgroundColor = us.ConsoleBackgroundColor;
            Console.ForegroundColor = us.ConsoleForegroundColor;
        }
    }
}
