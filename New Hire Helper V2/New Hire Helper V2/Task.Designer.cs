namespace New_Hire_Helper_V2
{
    partial class Task
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
            this.taskCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // taskCheckListBox
            // 
            this.taskCheckListBox.FormattingEnabled = true;
            this.taskCheckListBox.Location = new System.Drawing.Point(68, 42);
            this.taskCheckListBox.Name = "taskCheckListBox";
            this.taskCheckListBox.Size = new System.Drawing.Size(180, 169);
            this.taskCheckListBox.TabIndex = 0;
            this.taskCheckListBox.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 450);
            this.Controls.Add(this.taskCheckListBox);
            this.Name = "Task";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Task_FormClosed);
            this.Load += new System.EventHandler(this.Task_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox taskCheckListBox;
    }
}