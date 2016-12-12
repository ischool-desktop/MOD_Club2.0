﻿namespace K12.Club.Volunteer
{
    partial class OpenClubJoinDateTime
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTimes = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.lblSemester = new DevComponents.DotNetBar.LabelX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chGradeYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chStage1_Mode = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.chStartTime1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chEndTime1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chStage2_Mode = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.chStartTime2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chEndTime2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTimes
            // 
            this.dgvTimes.AllowUserToAddRows = false;
            this.dgvTimes.AllowUserToDeleteRows = false;
            this.dgvTimes.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chGradeYear,
            this.chStage1_Mode,
            this.chStartTime1,
            this.chEndTime1,
            this.chStage2_Mode,
            this.chStartTime2,
            this.chEndTime2});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTimes.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTimes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvTimes.Location = new System.Drawing.Point(13, 38);
            this.dgvTimes.Name = "dgvTimes";
            this.dgvTimes.RowTemplate.Height = 24;
            this.dgvTimes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTimes.Size = new System.Drawing.Size(943, 148);
            this.dgvTimes.TabIndex = 1;
            this.dgvTimes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimes_CellClick);
            this.dgvTimes.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimes_CellEndEdit);
            this.dgvTimes.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvTimes_CellValidating);
            this.dgvTimes.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimes_RowValidated);
            this.dgvTimes.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvTimes_RowValidating);
            // 
            // lblSemester
            // 
            this.lblSemester.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblSemester.BackgroundStyle.Class = "";
            this.lblSemester.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSemester.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.lblSemester.Location = new System.Drawing.Point(13, 9);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(142, 23);
            this.lblSemester.TabIndex = 0;
            this.lblSemester.Text = "97學年度　第１學期";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.btnClose.Location = new System.Drawing.Point(882, 223);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "離開";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.btnSave.Location = new System.Drawing.Point(801, 223);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "儲存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.labelX1.Location = new System.Drawing.Point(12, 207);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(299, 39);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "說明：時間格式範例（2012/7/23 13:00）\r\n輸入（7/23）會自動替換為（2012/7/23 00:00）";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightCyan;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.HeaderText = "年級";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "開始時間";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "截止時間";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "開始時間2";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "截止時間2";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // chGradeYear
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightCyan;
            this.chGradeYear.DefaultCellStyle = dataGridViewCellStyle4;
            this.chGradeYear.HeaderText = "年級";
            this.chGradeYear.Name = "chGradeYear";
            this.chGradeYear.ReadOnly = true;
            // 
            // chStage1_Mode
            // 
            this.chStage1_Mode.DropDownHeight = 106;
            this.chStage1_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chStage1_Mode.DropDownWidth = 121;
            this.chStage1_Mode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chStage1_Mode.HeaderText = "階段1模式";
            this.chStage1_Mode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chStage1_Mode.ItemHeight = 17;
            this.chStage1_Mode.Name = "chStage1_Mode";
            this.chStage1_Mode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chStage1_Mode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // chStartTime1
            // 
            this.chStartTime1.HeaderText = "階段1開始時間";
            this.chStartTime1.Name = "chStartTime1";
            this.chStartTime1.Width = 150;
            // 
            // chEndTime1
            // 
            this.chEndTime1.HeaderText = "階段1截止時間";
            this.chEndTime1.Name = "chEndTime1";
            this.chEndTime1.Width = 150;
            // 
            // chStage2_Mode
            // 
            this.chStage2_Mode.DropDownHeight = 106;
            this.chStage2_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chStage2_Mode.DropDownWidth = 121;
            this.chStage2_Mode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chStage2_Mode.HeaderText = "階段2模式";
            this.chStage2_Mode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chStage2_Mode.ItemHeight = 17;
            this.chStage2_Mode.Name = "chStage2_Mode";
            this.chStage2_Mode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chStage2_Mode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // chStartTime2
            // 
            this.chStartTime2.HeaderText = "階段2開始時間";
            this.chStartTime2.Name = "chStartTime2";
            this.chStartTime2.Width = 150;
            // 
            // chEndTime2
            // 
            this.chEndTime2.HeaderText = "階段2截止時間";
            this.chEndTime2.Name = "chEndTime2";
            this.chEndTime2.Width = 150;
            // 
            // OpenClubJoinDateTime
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSave;
            this.ClientSize = new System.Drawing.Size(968, 253);
            this.Controls.Add(this.dgvTimes);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.lblSemester);
            this.DoubleBuffered = true;
            this.Name = "OpenClubJoinDateTime";
            this.Text = "開放選社時間";
            this.Load += new System.EventHandler(this.DailyLifeInputControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvTimes;
        private DevComponents.DotNetBar.LabelX lblSemester;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn chGradeYear;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn chStage1_Mode;
        private System.Windows.Forms.DataGridViewTextBoxColumn chStartTime1;
        private System.Windows.Forms.DataGridViewTextBoxColumn chEndTime1;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn chStage2_Mode;
        private System.Windows.Forms.DataGridViewTextBoxColumn chStartTime2;
        private System.Windows.Forms.DataGridViewTextBoxColumn chEndTime2;
    }
}