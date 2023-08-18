
namespace Cap_Cut_Recorder
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblRecordingStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button2.BackgroundImage = global::Cap_Cut_Recorder.Properties.Resources.THH_25121916_25131916_25126916_25136916_001;
            this.button2.Image = global::Cap_Cut_Recorder.Properties.Resources._20230819_032959;
            this.button2.Location = new System.Drawing.Point(394, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 105);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Cap_Cut_Recorder.Properties.Resources.THH_25121916_25131916_25126916_25136916_001;
            this.button1.Image = global::Cap_Cut_Recorder.Properties.Resources._20230819_032727;
            this.button1.Location = new System.Drawing.Point(171, 78);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 105);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblRecordingStatus
            // 
            this.lblRecordingStatus.AutoSize = true;
            this.lblRecordingStatus.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRecordingStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordingStatus.ForeColor = System.Drawing.Color.White;
            this.lblRecordingStatus.Location = new System.Drawing.Point(243, 218);
            this.lblRecordingStatus.Name = "lblRecordingStatus";
            this.lblRecordingStatus.Size = new System.Drawing.Size(0, 20);
            this.lblRecordingStatus.TabIndex = 2;
            this.lblRecordingStatus.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = global::Cap_Cut_Recorder.Properties.Resources.THH_25121916_25131916_25126916_25136916_001;
            this.ClientSize = new System.Drawing.Size(665, 261);
            this.Controls.Add(this.lblRecordingStatus);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblRecordingStatus;
    }
}

