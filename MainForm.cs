using Newtonsoft.Json;

namespace thesis_integration_platform;

public partial class MainForm : Form
{
    readonly MessageSubscriber<ServiceBusEvent> _subscriber;
    readonly Emailer _emailer = new();

    public MainForm()
    {
        InitializeComponent();
        _subscriber = new MessageSubscriber<ServiceBusEvent>(ProcessMessageHandler, ErrorHandler);
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        Task.Run(_subscriber.DisposeAsync);
    }

    async Task ProcessMessageHandler(ServiceBusEvent message)
    {
        if (message == null) return;

        var student = JsonConvert.DeserializeObject<Student>(message.Body);
        if (student != null)
        {
            SetText($"{student.FirstName} {student.LastName} was updated.....\r\n");

            if (!string.IsNullOrEmpty(student.InstitutionalEmail))
            {
                SetText("Sending email...");
                SendEmail(new Emailer.EmailDetails
                {
                    To = student.InstitutionalEmail,
                    Body = $"Dear {student.FirstName},\r\n\r\nCongratulations, your user account details were successfully updated. Should you have any questions, please reach out.\r\n\r\nRegards\r\n\r\nThe Thesis Team!",
                    Recipient = $"{student.FirstName} {student.LastName}",
                    Subject = "Congratulations, your user was updated"
                });
                SetText("Done\r\n");
            }
        }
        await Task.CompletedTask;
    }

    Task ErrorHandler(Exception ex)
    {
        SetText("An error occurred", false);
        while (ex != null)
        {
            SetText($"{ex.Message}\r\n");
            ex = ex.InnerException;
        }
        return Task.CompletedTask;
    }

    void SetText(string text, bool append = true)
    {
        // InvokeRequired required compares the thread ID of the calling thread to the thread
        // ID of the creating thread. If these threads are different, it returns true.
        if (txtOutput.InvokeRequired)
        {
            Invoke(SetText, [text, append]);
            return;
        }

        if (!append)
            txtOutput.Text = "";

        foreach (var character in text)
        {
            txtOutput.AppendText($"{character}");
            Thread.Sleep(100);
        }
    }

    void SendEmail(Emailer.EmailDetails model)
    {
        // InvokeRequired required compares the thread ID of the calling thread to the thread
        // ID of the creating thread. If these threads are different, it returns true.
        if (txtOutput.InvokeRequired)
        {
            Invoke(SendEmail, [model]);
            return;
        }

        _emailer.Send(model);
    }
}