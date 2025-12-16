using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WorkPlanner.Models;
using WorkPlanner.Services;

namespace WorkPlanner
{
    public partial class Form1 : Form
    {
        private TaskService taskService;
        private BindingSource currentBinding = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            taskService = new TaskService();

            ConfigureControls();

            RefreshAllGrids();
        }

        private void ConfigureControls()
        {
            cbPriority.Items.Clear();
            cbPriority.Items.AddRange(new object[] { PriorityEnum.High, PriorityEnum.Medium, PriorityEnum.Low });
            cbPriority.SelectedIndex = 1;

            cbStatus.Items.Clear();
            cbStatus.Items.AddRange(new object[] { StatusEnum.Planned, StatusEnum.InProgress, StatusEnum.Completed });
            cbStatus.SelectedIndex = 0;

            cbFilterStatus.Items.Clear();
            cbFilterStatus.Items.Add("All");
            cbFilterStatus.Items.AddRange(new object[] { StatusEnum.Planned, StatusEnum.InProgress, StatusEnum.Completed });
            cbFilterStatus.SelectedIndex = 0;

            dateTimePickerDate.Value = DateTime.Today;
            dateTimePickerStart.Format = DateTimePickerFormat.Time;
            dateTimePickerStart.ShowUpDown = true;
            dateTimePickerStart.Value = DateTime.Today.AddHours(9);
            dateTimePickerEnd.Format = DateTimePickerFormat.Time;
            dateTimePickerEnd.ShowUpDown = true;
            dateTimePickerEnd.Value = DateTime.Today.AddHours(17);

            ConfigureGrid(dgvBazarErtesi);
            ConfigureGrid(dgvCarsenbeAxsami);
            ConfigureGrid(dgvCarsenbe);
            ConfigureGrid(dgvCumeAxsami);
            ConfigureGrid(dgvCume);
            ConfigureGrid(dgvShenbe);
            ConfigureGrid(dgvBazar);
        }

        private void ConfigureGrid(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            dgv.Columns.Clear();

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Title",
                HeaderText = "Title",
                DataPropertyName = "Title",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TimeRange",
                HeaderText = "Time",
                DataPropertyName = "",
                Width = 120
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Priority",
                HeaderText = "Priority",
                DataPropertyName = "Priority",
                Width = 80
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                DataPropertyName = "Status",
                Width = 100
            });

            dgv.CellFormatting += Dgv_CellFormatting;
            dgv.CellDoubleClick += Dgv_CellDoubleClick;
        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dgv = sender as DataGridView;
            var task = dgv.Rows[e.RowIndex].DataBoundItem as TaskItem;
            if (task != null)
            {
                LoadTaskToForm(task);
            }
        }

        private void Dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv?.Rows[e.RowIndex].DataBoundItem is TaskItem task)
            {
                if (dgv.Columns[e.ColumnIndex].Name == "TimeRange")
                {
                    e.Value = $"{task.StartTime:hh\\:mm} - {task.EndTime:hh\\:mm}";
                }
                else if (dgv.Columns[e.ColumnIndex].Name == "Priority")
                {
                    e.Value = task.Priority.ToString();
                }
                else if (dgv.Columns[e.ColumnIndex].Name == "Status")
                {
                    e.Value = task.Status.ToString();
                }

                var priorityCol = dgv.Columns["Priority"];
                if (priorityCol != null)
                {
                    var row = dgv.Rows[e.RowIndex];
                    if (task.Priority == PriorityEnum.High)
                        row.DefaultCellStyle.BackColor = Color.MistyRose;
                    else if (task.Priority == PriorityEnum.Medium)
                        row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                    else
                        row.DefaultCellStyle.BackColor = Color.Honeydew;

                    if (task.Date.Date == DateTime.Today)
                    {
                        row.DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
                    }
                }
            }
        }

        private void RefreshAllGrids(string searchText = null, StatusEnum? filterStatus = null)
        {
            var all = taskService.GetAll();
            var filteredTasks = all.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                string lowerSearchText = searchText.Trim().ToLower();
                filteredTasks = filteredTasks.Where(t =>
                    t.Title.ToLower().Contains(lowerSearchText) ||
                    t.Description.ToLower().Contains(lowerSearchText)
                );
            }

            if (filterStatus.HasValue)
            {
                filteredTasks = filteredTasks.Where(t => t.Status == filterStatus.Value);
            }

            var finalTasks = filteredTasks.ToList();

            dgvBazarErtesi.DataSource = finalTasks.Where(t => t.Date.DayOfWeek == DayOfWeek.Monday).ToList();
            dgvCarsenbeAxsami.DataSource = finalTasks.Where(t => t.Date.DayOfWeek == DayOfWeek.Tuesday).ToList();
            dgvCarsenbe.DataSource = finalTasks.Where(t => t.Date.DayOfWeek == DayOfWeek.Wednesday).ToList();
            dgvCumeAxsami.DataSource = finalTasks.Where(t => t.Date.DayOfWeek == DayOfWeek.Thursday).ToList();
            dgvCume.DataSource = finalTasks.Where(t => t.Date.DayOfWeek == DayOfWeek.Friday).ToList();
            dgvShenbe.DataSource = finalTasks.Where(t => t.Date.DayOfWeek == DayOfWeek.Saturday).ToList();
            dgvBazar.DataSource = finalTasks.Where(t => t.Date.DayOfWeek == DayOfWeek.Sunday).ToList();
        }

        private bool CheckForOverlap(DateTime date, TimeSpan startTime, TimeSpan endTime, Guid? excludedTaskId, out string message)
        {
            message = string.Empty;
            var tasksOnSameDay = taskService.GetAll().Where(t => t.Date.Date == date.Date);

            if (excludedTaskId.HasValue)
            {
                tasksOnSameDay = tasksOnSameDay.Where(t => t.Id != excludedTaskId.Value);
            }

            var overlappingTask = tasksOnSameDay.FirstOrDefault(t =>
                (startTime >= t.StartTime && startTime < t.EndTime) ||
                (endTime > t.StartTime && endTime <= t.EndTime) ||
                (startTime <= t.StartTime && endTime >= t.EndTime)
            );

            if (overlappingTask != null)
            {
                message = $"Bu vaxt intervalında ({startTime:hh\\:mm} - {endTime:hh\\:mm}) '{overlappingTask.Title}' adlı başqa bir tapşırıq var.";
                return true;
            }

            return false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm(out string msg))
            {
                MessageBox.Show(msg, "Validasiya", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var taskDate = dateTimePickerDate.Value.Date;
            var taskStart = dateTimePickerStart.Value.TimeOfDay;
            var taskEnd = dateTimePickerEnd.Value.TimeOfDay;

            if (CheckForOverlap(taskDate, taskStart, taskEnd, null, out msg))
            {
                MessageBox.Show(msg, "Task Overlap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var task = new TaskItem
            {
                Title = txtTitle.Text.Trim(),
                Description = rtbDescription.Text.Trim(),
                Date = taskDate,
                StartTime = taskStart,
                EndTime = taskEnd,
                Priority = (PriorityEnum)cbPriority.SelectedItem,
                Status = (StatusEnum)cbStatus.SelectedItem
            };

            taskService.Add(task);
            ClearForm();
            RefreshAllGrids();
            MessageBox.Show("Tapşırıq uğurla əlavə edildi.", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHiddenId.Text))
            {
                MessageBox.Show("Yeniləmək üçün zəhmət olmasa bir tapşırığı iki dəfə klikləyin.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateForm(out string msg))
            {
                MessageBox.Show(msg, "Validasiya", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var id = Guid.Parse(txtHiddenId.Text);
            var taskDate = dateTimePickerDate.Value.Date;
            var taskStart = dateTimePickerStart.Value.TimeOfDay;
            var taskEnd = dateTimePickerEnd.Value.TimeOfDay;

            if (CheckForOverlap(taskDate, taskStart, taskEnd, id, out msg))
            {
                MessageBox.Show(msg, "Task Overlap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var task = new TaskItem
            {
                Id = id,
                Title = txtTitle.Text.Trim(),
                Description = rtbDescription.Text.Trim(),
                Date = taskDate,
                StartTime = taskStart,
                EndTime = taskEnd,
                Priority = (PriorityEnum)cbPriority.SelectedItem,
                Status = (StatusEnum)cbStatus.SelectedItem
            };

            taskService.Update(task);
            ClearForm();
            RefreshAllGrids();
            MessageBox.Show("Tapşırıq uğurla yeniləndi.", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var dgv = GetCurrentGrid();
            if (dgv == null || dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silmək üçün bir sıra seçin.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var task = dgv.SelectedRows[0].DataBoundItem as TaskItem;
            if (task != null)
            {
                var ok = MessageBox.Show($"'{task.Title}' adlı seçilmiş tapşırığı silməyə əminsinizmi?", "Təsdiqləyin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ok == DialogResult.Yes)
                {
                    taskService.Delete(task.Id);
                    ClearForm();
                    RefreshAllGrids();
                }
            }
        }

        private DataGridView GetCurrentGrid()
        {
            var tp = tabControlDays.SelectedTab;
            if (tp != null)
            {
                foreach (Control c in tp.Controls)
                {
                    if (c is DataGridView dgv) return dgv;
                }
            }
            return null;
        }

        private void ClearForm()
        {
            txtTitle.Clear();
            rtbDescription.Clear();
            dateTimePickerDate.Value = DateTime.Today;
            dateTimePickerStart.Value = DateTime.Today.AddHours(9);
            dateTimePickerEnd.Value = DateTime.Today.AddHours(17);
            cbPriority.SelectedIndex = 1;
            cbStatus.SelectedIndex = 0;
            txtHiddenId.Text = string.Empty;
        }

        private bool ValidateForm(out string message)
        {
            message = string.Empty;
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                message = "Başlıq (Title) tələb olunur.";
                return false;
            }

            if (dateTimePickerEnd.Value.TimeOfDay <= dateTimePickerStart.Value.TimeOfDay)
            {
                message = "Bitmə vaxtı başlanğıc vaxtından sonra olmalıdır.";
                return false;
            }

            if (cbPriority.SelectedItem == null)
            {
                message = "Prioriteti seçin.";
                return false;
            }

            if (cbStatus.SelectedItem == null)
            {
                message = "Statusu seçin.";
                return false;
            }

            return true;
        }

        private void LoadTaskToForm(TaskItem task)
        {
            txtHiddenId.Text = task.Id.ToString();
            txtTitle.Text = task.Title;
            rtbDescription.Text = task.Description;
            dateTimePickerDate.Value = task.Date;
            dateTimePickerStart.Value = DateTime.Today.Date.Add(task.StartTime);
            dateTimePickerEnd.Value = DateTime.Today.Date.Add(task.EndTime);
            cbPriority.SelectedItem = task.Priority;
            cbStatus.SelectedItem = task.Status;
        }

        // Təsdiq pəncərəsi ilə bütün taskları silən metod
        private void btnClear_Click(object sender, EventArgs e)
        {
            var ok = MessageBox.Show(
                "Diqqət! Bu, yaddaşda saxlanılan bütün tapşırıqları siləcək. Davam etməyə əminsinizmi?",
                "Bütün Tapşırıqları Silin",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (ok == DialogResult.Yes)
            {
                // TaskService-də ClearAll() metodu çağırılır
                taskService.ClearAll();

                ClearForm();
                RefreshAllGrids();

                MessageBox.Show("Bütün tapşırıqlar yaddaşdan uğurla silindi.", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private StatusEnum? GetSelectedFilterStatus()
        {
            if (cbFilterStatus.SelectedItem == null || cbFilterStatus.SelectedItem.ToString() == "All")
            {
                return null;
            }

            return (StatusEnum)cbFilterStatus.SelectedItem;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            StatusEnum? filterStatus = GetSelectedFilterStatus();
            RefreshAllGrids(searchText, filterStatus);
        }

        private void cbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            StatusEnum? filterStatus = GetSelectedFilterStatus();
            RefreshAllGrids(searchText, filterStatus);
        }

        private void dgvBazarErtesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvBazarErtesi_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void cbFilterPriority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}