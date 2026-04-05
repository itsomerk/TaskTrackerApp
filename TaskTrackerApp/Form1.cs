using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskTrackerApp
{
    public partial class Form1 : Form
    {
        TaskManager manager = new TaskManager();

        public Form1()
        {
            InitializeComponent();

            LoadTasks();

            dataGridView1.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dataGridView1.IsCurrentCellDirty)
                {
                    dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            };

            dataGridView1.CellValueChanged += (s, e) =>
            {
                if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "IsCompleted")
                {
                    int id = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
                    bool isCompleted = (bool)dataGridView1.Rows[e.RowIndex].Cells["IsCompleted"].Value;

                    if (isCompleted)
                        manager.MarkAsCompleted(id);
                    else
                        manager.MarkAsNotCompleted(id);

                    LoadTasks();
                }
            };

            dataGridView1.RowPrePaint += (s, e) =>
            {
                var value = dataGridView1.Rows[e.RowIndex].Cells["IsCompleted"].Value;

                if (value != null && (bool)value)
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                else
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
            };
        }

        private void LoadTasks()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = manager.GetAllTasks();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTaskForm form = new AddTaskForm();
            form.ShowDialog();

            LoadTasks();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["Id"].Value;

                manager.DeleteTask(id);
                LoadTasks();
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["Id"].Value;

                manager.MarkAsCompleted(id);
                LoadTasks();
            }
        }
    }
}