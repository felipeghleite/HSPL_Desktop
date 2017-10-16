namespace CBA_Test
    {
    partial class Form1
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
            {
            if( disposing && (components != null) )
                {
                components.Dispose();
                }
            base.Dispose( disposing );
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
            {
            this.COM_ComboBox = new System.Windows.Forms.ComboBox();
            this.OpenCom_button = new System.Windows.Forms.Button();
            this.Terminal_textbox = new System.Windows.Forms.TextBox();
            this.command_textbox = new System.Windows.Forms.TextBox();
            this.command_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // COM_ComboBox
            // 
            this.COM_ComboBox.FormattingEnabled = true;
            this.COM_ComboBox.Location = new System.Drawing.Point(13, 13);
            this.COM_ComboBox.Name = "COM_ComboBox";
            this.COM_ComboBox.Size = new System.Drawing.Size(107, 28);
            this.COM_ComboBox.TabIndex = 0;
            this.COM_ComboBox.Text = "COM";
            // 
            // OpenCom_button
            // 
            this.OpenCom_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenCom_button.Location = new System.Drawing.Point(126, 12);
            this.OpenCom_button.Name = "OpenCom_button";
            this.OpenCom_button.Size = new System.Drawing.Size(107, 44);
            this.OpenCom_button.TabIndex = 1;
            this.OpenCom_button.Text = "Open COM";
            this.OpenCom_button.UseVisualStyleBackColor = true;
            this.OpenCom_button.Click += new System.EventHandler(this.OpenCom_button_Click);
            // 
            // Terminal_textbox
            // 
            this.Terminal_textbox.Location = new System.Drawing.Point(13, 62);
            this.Terminal_textbox.Multiline = true;
            this.Terminal_textbox.Name = "Terminal_textbox";
            this.Terminal_textbox.Size = new System.Drawing.Size(220, 259);
            this.Terminal_textbox.TabIndex = 2;
            // 
            // command_textbox
            // 
            this.command_textbox.Location = new System.Drawing.Point(240, 14);
            this.command_textbox.Name = "command_textbox";
            this.command_textbox.Size = new System.Drawing.Size(335, 26);
            this.command_textbox.TabIndex = 3;
            this.command_textbox.Text = "write your command...";
            // 
            // command_button
            // 
            this.command_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.command_button.Location = new System.Drawing.Point(582, 12);
            this.command_button.Name = "command_button";
            this.command_button.Size = new System.Drawing.Size(192, 44);
            this.command_button.TabIndex = 4;
            this.command_button.Text = "Send Command";
            this.command_button.UseVisualStyleBackColor = true;
            this.command_button.Click += new System.EventHandler(this.command_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 413);
            this.Controls.Add(this.command_button);
            this.Controls.Add(this.command_textbox);
            this.Controls.Add(this.Terminal_textbox);
            this.Controls.Add(this.OpenCom_button);
            this.Controls.Add(this.COM_ComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.ComboBox COM_ComboBox;
        private System.Windows.Forms.Button OpenCom_button;
        private System.Windows.Forms.TextBox Terminal_textbox;
        private System.Windows.Forms.TextBox command_textbox;
        private System.Windows.Forms.Button command_button;
        }
    }

