namespace WorkPlanner
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabControlDays;
        private System.Windows.Forms.Panel panelBottom;

        // Grid controls
        private System.Windows.Forms.DataGridView dgvBazarErtesi;
        private System.Windows.Forms.DataGridView dgvCarsenbeAxsami;
        private System.Windows.Forms.DataGridView dgvCarsenbe;
        private System.Windows.Forms.DataGridView dgvCumeAxsami;
        private System.Windows.Forms.DataGridView dgvCume;
        private System.Windows.Forms.DataGridView dgvShenbe;
        private System.Windows.Forms.DataGridView dgvBazar;

        // Input controls
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.ComboBox cbPriority;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtHiddenId;

        // Search / Filter
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbFilterPriority;
        private System.Windows.Forms.ComboBox cbFilterStatus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnFilter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tabControlDays = new TabControl();
            tp1 = new TabPage();
            dgvBazarErtesi = new DataGridView();
            tp2 = new TabPage();
            dgvCarsenbeAxsami = new DataGridView();
            tp3 = new TabPage();
            dgvCarsenbe = new DataGridView();
            tp4 = new TabPage();
            dgvCumeAxsami = new DataGridView();
            tp5 = new TabPage();
            dgvCume = new DataGridView();
            tp6 = new TabPage();
            dgvShenbe = new DataGridView();
            tp7 = new TabPage();
            dgvBazar = new DataGridView();
            txtTitle = new TextBox();
            rtbDescription = new RichTextBox();
            dateTimePickerDate = new DateTimePicker();
            dateTimePickerStart = new DateTimePicker();
            dateTimePickerEnd = new DateTimePicker();
            cbPriority = new ComboBox();
            cbStatus = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            txtHiddenId = new TextBox();
            txtSearch = new TextBox();
            cbFilterPriority = new ComboBox();
            cbFilterStatus = new ComboBox();
            btnSearch = new Button();
            btnFilter = new Button();
            panelBottom = new Panel();
            tabControlDays.SuspendLayout();
            tp1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBazarErtesi).BeginInit();
            tp2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarsenbeAxsami).BeginInit();
            tp3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarsenbe).BeginInit();
            tp4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCumeAxsami).BeginInit();
            tp5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCume).BeginInit();
            tp6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShenbe).BeginInit();
            tp7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBazar).BeginInit();
            SuspendLayout();
            // 
            // tabControlDays
            // 
            tabControlDays.Controls.Add(tp1);
            tabControlDays.Controls.Add(tp2);
            tabControlDays.Controls.Add(tp3);
            tabControlDays.Controls.Add(tp4);
            tabControlDays.Controls.Add(tp5);
            tabControlDays.Controls.Add(tp6);
            tabControlDays.Controls.Add(tp7);
            tabControlDays.Dock = DockStyle.Top;
            tabControlDays.Location = new Point(0, 0);
            tabControlDays.Name = "tabControlDays";
            tabControlDays.SelectedIndex = 0;
            tabControlDays.Size = new Size(1208, 360);
            tabControlDays.TabIndex = 0;
            // 
            // tp1
            // 
            tp1.Controls.Add(dgvBazarErtesi);
            tp1.Location = new Point(4, 29);
            tp1.Name = "tp1";
            tp1.Size = new Size(1200, 327);
            tp1.TabIndex = 0;
            tp1.Text = "Bazar Ertəsi";
            // 
            // dgvBazarErtesi
            // 
            dgvBazarErtesi.ColumnHeadersHeight = 29;
            dgvBazarErtesi.Dock = DockStyle.Fill;
            dgvBazarErtesi.Location = new Point(0, 0);
            dgvBazarErtesi.Name = "dgvBazarErtesi";
            dgvBazarErtesi.RowHeadersWidth = 51;
            dgvBazarErtesi.Size = new Size(1200, 327);
            dgvBazarErtesi.TabIndex = 0;
            dgvBazarErtesi.CellContentClick += dgvBazarErtesi_CellContentClick_1;
            // 
            // tp2
            // 
            tp2.Controls.Add(dgvCarsenbeAxsami);
            tp2.Location = new Point(4, 29);
            tp2.Name = "tp2";
            tp2.Size = new Size(1200, 327);
            tp2.TabIndex = 1;
            tp2.Text = "Çərşənbə Axşamı";
            // 
            // dgvCarsenbeAxsami
            // 
            dgvCarsenbeAxsami.ColumnHeadersHeight = 29;
            dgvCarsenbeAxsami.Dock = DockStyle.Fill;
            dgvCarsenbeAxsami.Location = new Point(0, 0);
            dgvCarsenbeAxsami.Name = "dgvCarsenbeAxsami";
            dgvCarsenbeAxsami.RowHeadersWidth = 51;
            dgvCarsenbeAxsami.Size = new Size(1200, 327);
            dgvCarsenbeAxsami.TabIndex = 0;
            // 
            // tp3
            // 
            tp3.Controls.Add(dgvCarsenbe);
            tp3.Location = new Point(4, 29);
            tp3.Name = "tp3";
            tp3.Size = new Size(1200, 327);
            tp3.TabIndex = 2;
            tp3.Text = "Çərşənbə";
            // 
            // dgvCarsenbe
            // 
            dgvCarsenbe.ColumnHeadersHeight = 29;
            dgvCarsenbe.Dock = DockStyle.Fill;
            dgvCarsenbe.Location = new Point(0, 0);
            dgvCarsenbe.Name = "dgvCarsenbe";
            dgvCarsenbe.RowHeadersWidth = 51;
            dgvCarsenbe.Size = new Size(1200, 327);
            dgvCarsenbe.TabIndex = 0;
            // 
            // tp4
            // 
            tp4.Controls.Add(dgvCumeAxsami);
            tp4.Location = new Point(4, 29);
            tp4.Name = "tp4";
            tp4.Size = new Size(1200, 327);
            tp4.TabIndex = 3;
            tp4.Text = "Cümə Axşamı";
            // 
            // dgvCumeAxsami
            // 
            dgvCumeAxsami.ColumnHeadersHeight = 29;
            dgvCumeAxsami.Dock = DockStyle.Fill;
            dgvCumeAxsami.Location = new Point(0, 0);
            dgvCumeAxsami.Name = "dgvCumeAxsami";
            dgvCumeAxsami.RowHeadersWidth = 51;
            dgvCumeAxsami.Size = new Size(1200, 327);
            dgvCumeAxsami.TabIndex = 0;
            // 
            // tp5
            // 
            tp5.Controls.Add(dgvCume);
            tp5.Location = new Point(4, 29);
            tp5.Name = "tp5";
            tp5.Size = new Size(1200, 327);
            tp5.TabIndex = 4;
            tp5.Text = "Cümə";
            // 
            // dgvCume
            // 
            dgvCume.ColumnHeadersHeight = 29;
            dgvCume.Dock = DockStyle.Fill;
            dgvCume.Location = new Point(0, 0);
            dgvCume.Name = "dgvCume";
            dgvCume.RowHeadersWidth = 51;
            dgvCume.Size = new Size(1200, 327);
            dgvCume.TabIndex = 0;
            // 
            // tp6
            // 
            tp6.Controls.Add(dgvShenbe);
            tp6.Location = new Point(4, 29);
            tp6.Name = "tp6";
            tp6.Size = new Size(1200, 327);
            tp6.TabIndex = 5;
            tp6.Text = "Şənbə";
            // 
            // dgvShenbe
            // 
            dgvShenbe.ColumnHeadersHeight = 29;
            dgvShenbe.Dock = DockStyle.Fill;
            dgvShenbe.Location = new Point(0, 0);
            dgvShenbe.Name = "dgvShenbe";
            dgvShenbe.RowHeadersWidth = 51;
            dgvShenbe.Size = new Size(1200, 327);
            dgvShenbe.TabIndex = 0;
            // 
            // tp7
            // 
            tp7.Controls.Add(dgvBazar);
            tp7.Location = new Point(4, 29);
            tp7.Name = "tp7";
            tp7.Size = new Size(1200, 327);
            tp7.TabIndex = 6;
            tp7.Text = "Bazar";
            // 
            // dgvBazar
            // 
            dgvBazar.ColumnHeadersHeight = 29;
            dgvBazar.Dock = DockStyle.Fill;
            dgvBazar.Location = new Point(0, 0);
            dgvBazar.Name = "dgvBazar";
            dgvBazar.RowHeadersWidth = 51;
            dgvBazar.Size = new Size(1200, 327);
            dgvBazar.TabIndex = 0;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(12, 370);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "Task title";
            txtTitle.Size = new Size(300, 27);
            txtTitle.TabIndex = 1;
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new Point(12, 400);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(300, 120);
            rtbDescription.TabIndex = 2;
            rtbDescription.Text = "";
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Format = DateTimePickerFormat.Short;
            dateTimePickerDate.Location = new Point(330, 370);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(200, 27);
            dateTimePickerDate.TabIndex = 3;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Format = DateTimePickerFormat.Time;
            dateTimePickerStart.Location = new Point(330, 400);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.ShowUpDown = true;
            dateTimePickerStart.Size = new Size(200, 27);
            dateTimePickerStart.TabIndex = 4;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Format = DateTimePickerFormat.Time;
            dateTimePickerEnd.Location = new Point(330, 430);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.ShowUpDown = true;
            dateTimePickerEnd.Size = new Size(200, 27);
            dateTimePickerEnd.TabIndex = 5;
            // 
            // cbPriority
            // 
            cbPriority.Location = new Point(330, 460);
            cbPriority.Name = "cbPriority";
            cbPriority.Size = new Size(120, 28);
            cbPriority.TabIndex = 6;
            // 
            // cbStatus
            // 
            cbStatus.Location = new Point(330, 490);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(120, 28);
            cbStatus.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(566, 366);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 27);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add Task";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(566, 402);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 27);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update Task";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(566, 432);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 27);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete Task";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(566, 465);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 29);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear Fields";
            btnClear.Click += btnClear_Click;
            // 
            // txtHiddenId
            // 
            txtHiddenId.Location = new Point(701, 370);
            txtHiddenId.Name = "txtHiddenId";
            txtHiddenId.Size = new Size(100, 27);
            txtHiddenId.TabIndex = 12;
            txtHiddenId.Visible = false;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(807, 370);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by title";
            txtSearch.Size = new Size(220, 27);
            txtSearch.TabIndex = 13;
            // 
            // cbFilterPriority
            // 
            cbFilterPriority.Location = new Point(781, 408);
            cbFilterPriority.Name = "cbFilterPriority";
            cbFilterPriority.Size = new Size(120, 28);
            cbFilterPriority.TabIndex = 15;
            cbFilterPriority.SelectedIndexChanged += cbFilterPriority_SelectedIndexChanged;
            // 
            // cbFilterStatus
            // 
            cbFilterStatus.Location = new Point(907, 408);
            cbFilterStatus.Name = "cbFilterStatus";
            cbFilterStatus.Size = new Size(120, 28);
            cbFilterStatus.TabIndex = 16;
            cbFilterStatus.SelectedIndexChanged += cbFilterStatus_SelectedIndexChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(1034, 367);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 32);
            btnSearch.TabIndex = 14;
            btnSearch.Text = "Search";
            btnSearch.Click += btnSearch_Click;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(1034, 411);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(75, 28);
            btnFilter.TabIndex = 17;
            btnFilter.Text = "Filter";
            // 
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Fill;
            panelBottom.Location = new Point(0, 0);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(8);
            panelBottom.Size = new Size(200, 100);
            panelBottom.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1208, 640);
            Controls.Add(tabControlDays);
            Controls.Add(txtTitle);
            Controls.Add(rtbDescription);
            Controls.Add(dateTimePickerDate);
            Controls.Add(dateTimePickerStart);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(cbPriority);
            Controls.Add(cbStatus);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(txtHiddenId);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(cbFilterPriority);
            Controls.Add(cbFilterStatus);
            Controls.Add(btnFilter);
            Name = "Form1";
            Text = "Həftəlik İş Planlayıcısı";
            Load += Form1_Load;
            tabControlDays.ResumeLayout(false);
            tp1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBazarErtesi).EndInit();
            tp2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCarsenbeAxsami).EndInit();
            tp3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCarsenbe).EndInit();
            tp4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCumeAxsami).EndInit();
            tp5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCume).EndInit();
            tp6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvShenbe).EndInit();
            tp7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBazar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabPage tp1;
        private TabPage tp2;
        private TabPage tp3;
        private TabPage tp4;
        private TabPage tp5;
        private TabPage tp6;
        private TabPage tp7;
    }
}
