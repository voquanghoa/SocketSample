namespace ReceiverApp
{
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
            txtResult = new TextBox();
            btClear = new Button();
            SuspendLayout();
            // 
            // txtResult
            // 
            txtResult.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtResult.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txtResult.Location = new Point(52, 75);
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(644, 47);
            txtResult.TabIndex = 0;
            txtResult.TextAlign = HorizontalAlignment.Center;
            // 
            // btClear
            // 
            btClear.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btClear.Location = new Point(256, 162);
            btClear.Name = "btClear";
            btClear.Size = new Size(249, 60);
            btClear.TabIndex = 1;
            btClear.Text = "Clear";
            btClear.UseVisualStyleBackColor = true;
            btClear.Click += btClear_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(765, 318);
            Controls.Add(btClear);
            Controls.Add(txtResult);
            Name = "MainForm";
            Text = "Form1";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtResult;
        private Button btClear;
    }
}
