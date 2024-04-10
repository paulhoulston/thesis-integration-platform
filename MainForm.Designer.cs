namespace thesis_integration_platform;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        txtOutput = new TextBox();
        SuspendLayout();
        // 
        // txtOutput
        // 
        txtOutput.Dock = DockStyle.Fill;
        txtOutput.Location = new Point(0, 0);
        txtOutput.Multiline = true;
        txtOutput.Name = "txtOutput";
        txtOutput.Size = new Size(800, 450);
        txtOutput.TabIndex = 0;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(txtOutput);
        Name = "MainForm";
        Text = "Integration Platform Subscriber";
        FormClosing += MainForm_FormClosing;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox txtOutput;
}
