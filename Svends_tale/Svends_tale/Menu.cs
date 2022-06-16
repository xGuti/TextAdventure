using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svends_tale
{
    class Menu
    {
        //TODO: create settings variables
        public void Run()
        {
            Console.Clear();
            Console.WriteLine(
                " _______           _______  _        ______   _  _______   _________ _______  _        _______     \n" +
                "(  ____ \\|\\     /|(  ____ \\( (    /|(  __  \\ ( )(  ____ \\  \\__   __/(  ___  )( \\      (  ____ \\    \n" +
                "| (    \\/| )   ( || (    \\/|  \\  ( || (  \\  )|/ | (    \\/     ) (   | (   ) || (      | (    \\/    \n" +
                "| (_____ | |   | || (__    |   \\ | || |   ) |   | (_____      | |   | (___) || |      | (__        \n" +
                "(_____  )( (   ) )|  __)   | (\\ \\) || |   | |   (_____  )     | |   |  ___  || |      |  __)       \n" +
                "      ) | \\ \\_/ / | (      | | \\   || |   ) |         ) |     | |   | (   ) || |      | (          \n" +
                "/\\____) |  \\   /  | (____/\\| )  \\  || (__/  )   /\\____) |     | |   | )   ( || (____/\\| (____/\\    \n" +
                "\\_______)   \\_/   (_______/|/    )_)(______/    \\_______)     )_(   |/     \\|(_______/(_______/    \n" +

                 "\n\n");

            //TODO: move it to file and translate
            Console.Write("\t\t\t1. Nowa gra\n" +
                "\t\t\t2. Wczytaj grę\n" +
                "\t\t\t3. Komendy\n" +
                "\t\t\t4. Wyjście\n" +
                "\n> ");
        }

        public void Show_Commands()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("COMMANDS\n\n");

                //TODO: move it to file and translate
                Console.Write("look around\t-\topis co widzi postać\n" +
                    "go forward\t-\tidź do przodu\n" +
                    "back\t-\tcofnij się\n" +
                    "go left/right\t-\tidź w lewo/prawo\n" +
                    "go to temple/blacksmith/tavern/shop\t-\tidż do kaplicy/kowala/karczmy/sklepu" +
                    "come to ...\t-\tpodejdź do ...\n" +
                    "talk\t-\trozmawiaj\n" +
                    "use ...\t-\tużyj przedmiotu\n" +
                    "give ...\t-\tdaj przedmiot\n" +
                    "attack\t-\tatakuje najbliższą postać mieczem\n" +
                    "defend\t-\tobrona przed atakiem\n" +
                    "dodge\t-\tunik\n" +
                    "try\t-\tpodjęcie próby (rzut kością)\n" +
                    "\nWpisz 'back' aby wrócić do menu głównego\n" +
                    "\n>");
            } while (Console.ReadLine() != "back");
        }
    }
}
