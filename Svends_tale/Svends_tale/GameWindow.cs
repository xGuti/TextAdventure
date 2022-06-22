using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svends_tale
{
    
    class GameWindow
    {        
        public void Show_Menu(string menuName)
        {
            Write_Header();

            var lines = System.Configuration.ConfigurationManager.AppSettings[$"{menuName}-{Program.us.Language}"];

            Console.WriteLine("\t\t" + lines);
        }

        public void Write_Header()
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
        }
    }
}
