namespace ReceiverApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SocketManager.Instance.EventReceived -= socket_EventReceived;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SocketManager.Instance.EventReceived += socket_EventReceived;
        }

        private void socket_EventReceived(SocketMessage socketMessage)
        {
            Invoke(() =>
            {
                txtResult.Text = socketMessage.Content;
            });
        }

    }
}
