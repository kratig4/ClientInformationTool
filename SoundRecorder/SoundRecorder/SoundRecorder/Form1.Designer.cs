namespace SoundRecorder
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            saveFileDialog1 = new SaveFileDialog();
            textBox1 = new TextBox();
            button5 = new Button();
            textBox2 = new TextBox();
            fileSystemWatcher1 = new FileSystemWatcher();
            openFileDialog1 = new OpenFileDialog();
            button6 = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(154, 67);
            button1.Name = "button1";
            button1.Size = new Size(139, 23);
            button1.TabIndex = 0;
            button1.Text = "Upload Image";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(299, 67);
            button2.Name = "button2";
            button2.Size = new Size(204, 23);
            button2.TabIndex = 1;
            button2.Text = "Upload PDF";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(602, 117);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(70, 23);
            textBox1.TabIndex = 4;
            textBox1.Text = "0";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button5
            // 
            button5.Location = new Point(122, 199);
            button5.Name = "button5";
            button5.Size = new Size(155, 23);
            button5.TabIndex = 6;
            button5.Text = "Convert to text";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(342, 172);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(300, 50);
            textBox2.TabIndex = 7;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button6
            // 
            button6.Image = (Image)resources.GetObject("button6.Image");
            button6.Location = new Point(109, 96);
            button6.Name = "button6";
            button6.Size = new Size(184, 69);
            button6.TabIndex = 10;
            button6.Text = "Audio Record Start";
            button6.TextAlign = ContentAlignment.MiddleRight;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click_1;
            // 
            // button7
            // 
            button7.Location = new Point(299, 117);
            button7.Name = "button7";
            button7.Size = new Size(204, 23);
            button7.TabIndex = 11;
            button7.Text = "Audio Record Stop";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(textBox2);
            Controls.Add(button5);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private System.Windows.Forms.Timer timer1;
        private SaveFileDialog saveFileDialog1;
        private TextBox textBox1;
        private Button button5;
        private TextBox textBox2;
        private FileSystemWatcher fileSystemWatcher1;
        private OpenFileDialog openFileDialog1;
        private Button button6;
        private Button button7;
    }
}