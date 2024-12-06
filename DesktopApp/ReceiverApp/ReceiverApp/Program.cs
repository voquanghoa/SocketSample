namespace ReceiverApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            SocketManager.Instance.Start();

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());

            SocketManager.Instance.Close();
        }
    }
}