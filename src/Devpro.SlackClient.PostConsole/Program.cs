namespace Devpro.SlackClient.PostConsole
{
    class Program
    {
        static int Main(string[] args)
        {
            //TODO: should be done more nicely :)
            if (args.Length != 4) return -1;

            var urlWithAccessToken = args[0];
            var username           = args[1];
            var message            = args[2];
            var channel            = args[3];

            var client = new SlackClient(urlWithAccessToken);

            client.PostMessage(username: username, text: message, channel: channel);

            return 0;
        }
    }
}
