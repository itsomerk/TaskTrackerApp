namespace TaskTrackerApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnComplete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();
            btnComplete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(560, 250);
            dataGridView1.TabIndex = 0;
            // 
            btnAdd.Location = new Point(157, 280);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 30);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;
            // 
            btnDelete.Location = new Point(255, 280);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 30);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            // 
            btnComplete.Location = new Point(350, 280);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(75, 30);
            btnComplete.TabIndex = 3;
            btnComplete.Text = "Complete";
            btnComplete.Click += btnComplete_Click;
            // 
            ClientSize = new Size(600, 330);
            Controls.Add(dataGridView1);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(btnComplete);
            Name = "Form1";
            Text = "Task Tracker";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }
    }
}