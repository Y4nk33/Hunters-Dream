namespace Forms_Wurds
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.DG_whole_chat = new System.Windows.Forms.DataGridView();
            this.DG_words = new System.Windows.Forms.DataGridView();
            this.DG_words_col_word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_words_col_sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.split_DG_whole_chat_DG_words = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DG_whole_chat_filteredByWord = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chart_Words = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.DG_whole_chat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG_words)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.split_DG_whole_chat_DG_words)).BeginInit();
            this.split_DG_whole_chat_DG_words.Panel1.SuspendLayout();
            this.split_DG_whole_chat_DG_words.Panel2.SuspendLayout();
            this.split_DG_whole_chat_DG_words.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_whole_chat_filteredByWord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Words)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(687, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Auswertung beginnen";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(687, 18);
            this.progressBar1.TabIndex = 2;
            // 
            // progressBar2
            // 
            this.progressBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar2.Location = new System.Drawing.Point(0, 0);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(214, 18);
            this.progressBar2.TabIndex = 2;
            // 
            // DG_whole_chat
            // 
            this.DG_whole_chat.AllowUserToAddRows = false;
            this.DG_whole_chat.AllowUserToDeleteRows = false;
            this.DG_whole_chat.AllowUserToResizeColumns = false;
            this.DG_whole_chat.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.DG_whole_chat.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DG_whole_chat.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DG_whole_chat.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DG_whole_chat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DG_whole_chat.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DG_whole_chat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG_whole_chat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DG_whole_chat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_whole_chat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_whole_chat.EnableHeadersVisualStyles = false;
            this.DG_whole_chat.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.DG_whole_chat.Location = new System.Drawing.Point(0, 0);
            this.DG_whole_chat.MultiSelect = false;
            this.DG_whole_chat.Name = "DG_whole_chat";
            this.DG_whole_chat.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG_whole_chat.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DG_whole_chat.RowHeadersVisible = false;
            this.DG_whole_chat.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG_whole_chat.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DG_whole_chat.Size = new System.Drawing.Size(687, 405);
            this.DG_whole_chat.TabIndex = 11;
            this.DG_whole_chat.SelectionChanged += new System.EventHandler(this.DG_whole_chat_SelectionChanged);
            // 
            // DG_words
            // 
            this.DG_words.AllowUserToAddRows = false;
            this.DG_words.AllowUserToDeleteRows = false;
            this.DG_words.AllowUserToResizeColumns = false;
            this.DG_words.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            this.DG_words.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DG_words.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DG_words.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DG_words.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DG_words.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DG_words.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.DG_words.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG_words.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DG_words.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_words.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DG_words_col_word,
            this.DG_words_col_sum});
            this.DG_words.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_words.EnableHeadersVisualStyles = false;
            this.DG_words.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.DG_words.Location = new System.Drawing.Point(0, 0);
            this.DG_words.MultiSelect = false;
            this.DG_words.Name = "DG_words";
            this.DG_words.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG_words.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DG_words.RowHeadersVisible = false;
            this.DG_words.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG_words.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DG_words.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG_words.Size = new System.Drawing.Size(214, 447);
            this.DG_words.TabIndex = 11;
            this.DG_words.SelectionChanged += new System.EventHandler(this.DG_words_SelectionChanged);
            // 
            // DG_words_col_word
            // 
            this.DG_words_col_word.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.NullValue = "word";
            this.DG_words_col_word.DefaultCellStyle = dataGridViewCellStyle7;
            this.DG_words_col_word.HeaderText = "Word";
            this.DG_words_col_word.Name = "DG_words_col_word";
            this.DG_words_col_word.ReadOnly = true;
            // 
            // DG_words_col_sum
            // 
            this.DG_words_col_sum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = "0";
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG_words_col_sum.DefaultCellStyle = dataGridViewCellStyle8;
            this.DG_words_col_sum.HeaderText = "Sum";
            this.DG_words_col_sum.Name = "DG_words_col_sum";
            this.DG_words_col_sum.ReadOnly = true;
            this.DG_words_col_sum.Width = 55;
            // 
            // split_DG_whole_chat_DG_words
            // 
            this.split_DG_whole_chat_DG_words.BackColor = System.Drawing.Color.Teal;
            this.split_DG_whole_chat_DG_words.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_DG_whole_chat_DG_words.Location = new System.Drawing.Point(0, 0);
            this.split_DG_whole_chat_DG_words.Name = "split_DG_whole_chat_DG_words";
            // 
            // split_DG_whole_chat_DG_words.Panel1
            // 
            this.split_DG_whole_chat_DG_words.Panel1.Controls.Add(this.button1);
            this.split_DG_whole_chat_DG_words.Panel1.Controls.Add(this.progressBar1);
            this.split_DG_whole_chat_DG_words.Panel1.Controls.Add(this.splitContainer1);
            // 
            // split_DG_whole_chat_DG_words.Panel2
            // 
            this.split_DG_whole_chat_DG_words.Panel2.Controls.Add(this.progressBar2);
            this.split_DG_whole_chat_DG_words.Panel2.Controls.Add(this.DG_words);
            this.split_DG_whole_chat_DG_words.Panel2.Controls.Add(this.Chart_Words);
            this.split_DG_whole_chat_DG_words.Size = new System.Drawing.Size(909, 747);
            this.split_DG_whole_chat_DG_words.SplitterDistance = 687;
            this.split_DG_whole_chat_DG_words.SplitterWidth = 8;
            this.split_DG_whole_chat_DG_words.TabIndex = 12;
            this.split_DG_whole_chat_DG_words.MouseDown += new System.Windows.Forms.MouseEventHandler(this.split_DG_whole_chat_DG_words_MouseDown);
            this.split_DG_whole_chat_DG_words.MouseMove += new System.Windows.Forms.MouseEventHandler(this.split_DG_whole_chat_DG_words_MouseMove);
            this.split_DG_whole_chat_DG_words.MouseUp += new System.Windows.Forms.MouseEventHandler(this.split_DG_whole_chat_DG_words_MouseUp);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DG_whole_chat);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DG_whole_chat_filteredByWord);
            this.splitContainer1.Size = new System.Drawing.Size(687, 747);
            this.splitContainer1.SplitterDistance = 405;
            this.splitContainer1.TabIndex = 12;
            // 
            // DG_whole_chat_filteredByWord
            // 
            this.DG_whole_chat_filteredByWord.AllowUserToAddRows = false;
            this.DG_whole_chat_filteredByWord.AllowUserToDeleteRows = false;
            this.DG_whole_chat_filteredByWord.AllowUserToResizeColumns = false;
            this.DG_whole_chat_filteredByWord.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            this.DG_whole_chat_filteredByWord.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.DG_whole_chat_filteredByWord.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DG_whole_chat_filteredByWord.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DG_whole_chat_filteredByWord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DG_whole_chat_filteredByWord.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DG_whole_chat_filteredByWord.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG_whole_chat_filteredByWord.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.DG_whole_chat_filteredByWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_whole_chat_filteredByWord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.DG_whole_chat_filteredByWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_whole_chat_filteredByWord.EnableHeadersVisualStyles = false;
            this.DG_whole_chat_filteredByWord.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.DG_whole_chat_filteredByWord.Location = new System.Drawing.Point(0, 0);
            this.DG_whole_chat_filteredByWord.MultiSelect = false;
            this.DG_whole_chat_filteredByWord.Name = "DG_whole_chat_filteredByWord";
            this.DG_whole_chat_filteredByWord.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG_whole_chat_filteredByWord.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.DG_whole_chat_filteredByWord.RowHeadersVisible = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG_whole_chat_filteredByWord.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.DG_whole_chat_filteredByWord.Size = new System.Drawing.Size(687, 338);
            this.DG_whole_chat_filteredByWord.TabIndex = 11;
            this.DG_whole_chat_filteredByWord.SelectionChanged += new System.EventHandler(this.DG_whole_chat_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle13.Format = "G";
            dataGridViewCellStyle13.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn1.HeaderText = "Date Time";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.dataGridViewTextBoxColumn2.HeaderText = "Author";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 5;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn3.HeaderText = "Message";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Chart_Words
            // 
            this.Chart_Words.BackColor = System.Drawing.Color.Teal;
            this.Chart_Words.BorderlineColor = System.Drawing.Color.Red;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.Chart_Words.ChartAreas.Add(chartArea1);
            this.Chart_Words.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Chart_Words.Location = new System.Drawing.Point(0, 447);
            this.Chart_Words.Name = "Chart_Words";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Name = "Series1";
            series1.YValuesPerPoint = 3;
            this.Chart_Words.Series.Add(series1);
            this.Chart_Words.Size = new System.Drawing.Size(214, 300);
            this.Chart_Words.TabIndex = 13;
            this.Chart_Words.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(909, 747);
            this.Controls.Add(this.split_DG_whole_chat_DG_words);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wurds";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DG_whole_chat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG_words)).EndInit();
            this.split_DG_whole_chat_DG_words.Panel1.ResumeLayout(false);
            this.split_DG_whole_chat_DG_words.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_DG_whole_chat_DG_words)).EndInit();
            this.split_DG_whole_chat_DG_words.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_whole_chat_filteredByWord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Words)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.DataGridView DG_whole_chat;
        private System.Windows.Forms.DataGridView DG_words;
        private System.Windows.Forms.SplitContainer split_DG_whole_chat_DG_words;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView DG_whole_chat_filteredByWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_words_col_word;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_words_col_sum;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_Words;
    }
}

