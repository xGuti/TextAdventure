using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svends_tale
{
    
    class Menu
    {        
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

            //TODO: Change static path to project path
            
            var lines = System.Configuration.ConfigurationManager.AppSettings[$"menu-{Program.us.Language}"];

            Console.WriteLine("\t\t" + lines);

        }

        public void Show_Commands()
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
            var lines = System.Configuration.ConfigurationManager.AppSettings[$"commands-{Program.us.Language}"];

            Console.WriteLine(lines);

        }

        public void Show_Settings()
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

            var lines = System.Configuration.ConfigurationManager.AppSettings[$"settings-{Program.us.Language}"];

            Console.WriteLine(lines);
        }

        public void Show_Colors()
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

            var lines = System.Configuration.ConfigurationManager.AppSettings[$"colors-{Program.us.Language}"];

            Console.WriteLine(lines);
        }

        public void Show_Languages()
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

            var lines = System.Configuration.ConfigurationManager.AppSettings[$"languages-{Program.us.Language}"];

            Console.WriteLine(lines);
        }
    }
}
