using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace Svends_tale
{
    class Program
    {
        public static string homePath = "C:\\Users\\Guti\\Documents\\GitHub\\TextAdventure\\Svends_tale\\Svends_tale";

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

                command = Read_Command($"menu-commands-{us.Language}");
                //CHANGE SWITCH TO SWITCH8.0    powered by Oskar Szymański
                switch (command.ToLower())
                {
                    case string c when c.Equals(activeCommands[0]):
                        break;

                    case string c when c.Equals(activeCommands[1]):
                        break;

                        //commands window
                    case string c when c.Equals(activeCommands[2]):
                        do
                        {
                            menu.Show_Commands();
                            command = Read_Command($"commands-commands-{us.Language}");
                        } while (command != activeCommands[0]);
                        break;

                        //settings window
                    case string c when c.Equals(activeCommands[3]):
                        do
                        {
                            menu.Show_Settings();
                            command = Read_Command($"settings-commands-{us.Language}");

                            switch (command)
                            {
                                case string c2 when c2.Equals(activeCommands[0]):
                                    Change_Setting(typeof(ConsoleColor), "ConsoleBackgroundColor");
                                    break;

                                case string c2 when c2.Equals(activeCommands[1]):
                                    Change_Setting(typeof(ConsoleColor), "ConsoleForegroundColor");
                                    break;

                                case string c2 when c2.Equals(activeCommands[2]):
                                    Change_Setting(typeof(string), "Language");
                                    break;

                                case string c2 when c2.Equals(activeCommands[3]):
                                    break;

                                default:
                                    Console.WriteLine("Brak opcji. . .");
                                    break;
                            }

                        } while (command != activeCommands[3]);

                        break;

                    case string c when c.Equals(activeCommands[4]):
                        command = "";
                        break;

                    default:
                        Console.Write("Brak opcji. . .");
                        System.Threading.Thread.Sleep(5000);
                        break;
                }
            } while (command != "");

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
            catch(Exception e)
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
            string command;
            if (type == typeof(ConsoleColor))
            {
                menu.Show_Colors();
                command = Read_Command($"colors-commands-{us.Language}");
            }
            else
            {
                menu.Show_Languages();
                command = Read_Command($"languages-commands");
            }
                dynamic value = command switch{
                    "black" => ConsoleColor.Black,
                    "white" => ConsoleColor.White,
                    "blue" => name == "ConsoleBackgroundColor" ? ConsoleColor.DarkBlue : ConsoleColor.Blue,
                    "green" => name == "ConsoleBackgroundColor" ? ConsoleColor.DarkGreen : ConsoleColor.Green,
                    "cyan" => name == "ConsoleBackgroundColor" ? ConsoleColor.DarkCyan : ConsoleColor.Cyan,
                    "red" => name == "ConsoleBackgroundColor" ? ConsoleColor.DarkRed : ConsoleColor.Red,
                    "magenta" => name == "ConsoleBackgroundColor" ? ConsoleColor.DarkMagenta : ConsoleColor.Magenta,
                    "yellow" => name == "ConsoleBackgroundColor" ? ConsoleColor.DarkYellow : ConsoleColor.Yellow,
                    "gray" => name == "ConsoleBackgroundColor" ? ConsoleColor.DarkGray : ConsoleColor.Gray,
                    "english" => "\"en\"",
                    "polski" => "\"pl\"",
                    _ => ""
                };

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
