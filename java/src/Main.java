import java.io.IOException;

public class Main {
    private static final String usage = " usage: verb (GET, POST, PUT, DELETE) [languageName] [index] ";

    public static void main(String[] args) throws IOException {

        if (args.length == 0)
        {
            System.out.println(usage);
            return;
        }

        String verb = args[0];
        LanguageHttpClient languageHttpClient = new LanguageHttpClient();

        if (verb.equals("GET"))
        {
            if (args.length == 2)
            {
                languageHttpClient.GetItem(Integer.parseInt(args[1]));
            }
            else
            {
                languageHttpClient.GetAll();
            }
            return;
        }

        if (verb.equals("POST") && args.length == 2)
        {
            languageHttpClient.Post(args[1]);
            return;
        }

        if (verb.equals("PUT") && args.length == 3)
        {
            languageHttpClient.Put(args[1], Integer.parseInt(args[2]));
            return;
        }

        if (verb.equals("DELETE") && args.length == 2)
        {
            languageHttpClient.Delete(Integer.parseInt(args[1]));
            return;
        }

        System.out.println(usage);
    }
}
