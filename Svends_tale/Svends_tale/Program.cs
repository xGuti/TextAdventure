using System;
using System.Reflection;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Svends_tale
{
    class Program
    {
        /// <summary>
        /// Global object of UserSettings class
        /// </summary>
        public static UserSettings us;

        static List<string> activeCommands;
        static GameWindow menu;

        /// <summary>
        /// Main game loop
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            us = new UserSettings();

            Load_User_Settings();
            //var value = System.Configuration.ConfigurationManager.AppSettings["a"];
            //Console.WriteLine(value);

            activeCommands = new List<string>();

            string command = "";
            menu = new GameWindow();

            while(true){
                
                //main menu
                menu.Show_Menu("menu");
                command = Read_Command($"menu-{Program.us.Language}-commands");

                //CHANGE SWITCH TO SWITCH8.0    powered by Oskar Szymański
                switch (command.ToLower())
                {   
                        //new | nowa
                    case string c when c.Equals(activeCommands[1]):
                        break;
                    
                        //load | wczytaj
                    case string c when c.Equals(activeCommands[2]):
                        break;

                        //commands | komendy
                    case string c when c.Equals(activeCommands[3]):
                        do
                        {
                            menu.Show_Menu("commands");
                            command = Read_Command($"commands-{Program.us.Language}-commands").ToLower();
                        } while (command != activeCommands[0]);
                        break;

                        //settings | ustawienia
                    case string c when c.Equals(activeCommands[4]):
                        do
                        {
                            menu.Show_Menu("settings");
                            command = Read_Command($"settings-{Program.us.Language}-commands").ToLower();

                            switch (command)
                            {   
                                    //background | tło
                                case string c2 when c2.Equals(activeCommands[1]):
                                    Change_Setting("ConsoleBackgroundColor");
                                    break;
                                
                                    //foreground | czcionka
                                case string c2 when c2.Equals(activeCommands[2]):
                                    Change_Setting("ConsoleForegroundColor");
                                    break;
                                
                                    //language | język
                                case string c2 when c2.Equals(activeCommands[3]):
                                    Change_Setting("Language");
                                    break;
                                
                                    //back | wróć
                                case string c2 when c2.Equals(activeCommands[0]):
                                    break;

                                default:
                                    Console.WriteLine("E404: Command not found!");
                                    System.Threading.Thread.Sleep(5000);
                                    break;
                            }
                            Set_Active_Commands($"settings-{Program.us.Language}-commands");
                        } while (command != activeCommands[0]);
                        break;

                    case string c when c.Equals(activeCommands[0]):
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Write("E404: Command not found!");
                        System.Threading.Thread.Sleep(5000);
                        break;
                }
            };
        }

        /// <summary>
        /// Sets commands that are active at current window. If no commands were found change language to default (English)
        /// </summary>
        /// <param name="window">Name of current window e.g. menu, settings, about etc.</param>
        public static void Set_Active_Commands(string window)
        {
            activeCommands.Clear();
            try
            {
                var value = System.Configuration.ConfigurationManager.AppSettings[window];
                foreach (string v in value.Split(" "))
                    activeCommands.Add(v.ToLower());
            }
            catch(Exception )
            {
                us.Language = "en";
                us.Save();
            }
        }

        /// <summary>
        /// Runs Set_Active_Commands(string) function and reads user input. Returns command name or 'error'
        /// </summary>
        /// <param name="window">Name of current window e.g. menu, settings, about etc. Only to forward to Set_Active_Commands function</param>
        /// <returns>Command name if users input equals to any of active commands or 'error' if command was not found</returns>
        public static string Read_Command(string window)
        {
            Set_Active_Commands(window);

            Console.Write("> ");
            string userCommand = Console.ReadLine();

            if(activeCommands.Contains(userCommand))
                return userCommand;

            else return "error";
        }

        /// <summary>
        /// Display the appropriate window with languages list or color list
        /// Read user input and change the settings according to the value specified by the user
        /// Save and reload all settings
        /// </summary>
        /// <param name="name">Name of setting to change e.g. Language, ConsoleBackgroundColor, ConsoleForegroundColor</param>
        public static void Change_Setting(string name)
        {
            dynamic value;
            string command;

            //Language settings
            if (name.Equals("Language"))
            {
                menu.Show_Menu("languages");
                command = Read_Command($"languages-commands");
                value = command switch
                {
                    "english" => "en",
                    "polski" => "pl",
                    _ => us.Language
                };
            }
            //Colors settings
            else
            {
                menu.Show_Menu("colors");
                command = Read_Command($"colors-{Program.us.Language}-commands");
                value = command switch
                {
                    string s when s.Equals(activeCommands[1]) => ConsoleColor.Black,
                    string s when s.Equals(activeCommands[2]) => name.Equals("ConsoleBackgroundColor") ? ConsoleColor.DarkBlue : ConsoleColor.Blue,
                    string s when s.Equals(activeCommands[3]) => name.Equals("ConsoleBackgroundColor") ? ConsoleColor.DarkGreen : ConsoleColor.Green,
                    string s when s.Equals(activeCommands[4]) => name.Equals("ConsoleBackgroundColor") ? ConsoleColor.DarkCyan : ConsoleColor.Cyan,
                    string s when s.Equals(activeCommands[5]) => name.Equals("ConsoleBackgroundColor") ? ConsoleColor.DarkRed : ConsoleColor.Red,
                    string s when s.Equals(activeCommands[6]) => name.Equals("ConsoleBackgroundColor") ? ConsoleColor.DarkMagenta : ConsoleColor.Magenta,
                    string s when s.Equals(activeCommands[7]) => name.Equals("ConsoleBackgroundColor") ? ConsoleColor.DarkYellow : ConsoleColor.Yellow,
                    string s when s.Equals(activeCommands[8]) => name.Equals("ConsoleBackgroundColor") ? ConsoleColor.DarkGray : ConsoleColor.Gray,
                    string s when s.Equals(activeCommands[9]) => ConsoleColor.White,
                    _ => name == "ConsoleBackgroundColor" ? us.ConsoleBackgroundColor : us.ConsoleForegroundColor
                };
            }

            //Save all user settings
            us.ConsoleBackgroundColor = name.Equals("ConsoleBackgroundColor") ? value : us.ConsoleBackgroundColor;
            us.ConsoleForegroundColor = name.Equals("ConsoleForegroundColor") ? value : us.ConsoleForegroundColor;
            us.Language = name.Equals("Language") ? value : us.Language;

            us.Save();

            //Reload changes
            Load_User_Settings();
        }

        /// <summary>
        /// Sets console view
        /// </summary>
        static void Load_User_Settings()
        {
            Console.BackgroundColor = us.ConsoleBackgroundColor;
            Console.ForegroundColor = us.ConsoleForegroundColor;
        }
    }
}
