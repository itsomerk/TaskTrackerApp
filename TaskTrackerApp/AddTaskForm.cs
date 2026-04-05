using System;
using System.Windows.Forms;

namespace TaskTrackerApp
{
    public partial class AddTaskForm : Form
    {
        public AddTaskForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TaskManager manager = new TaskManager();

            TaskItem task = new TaskItem()
            {
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                DueDate = dateTimePicker1.Value,
                IsCompleted = false
            };

            manager.AddTask(task);

            MessageBox.Show("Task Added!");
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}