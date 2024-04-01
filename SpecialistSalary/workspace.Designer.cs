namespace SpecialistSalary
{
    partial class workForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Отобразить = new System.Windows.Forms.Button();
            this.amountpayLabel = new System.Windows.Forms.Label();
            this.averagepayLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.fioTb = new System.Windows.Forms.TextBox();
            this.editBtn = new System.Windows.Forms.Button();
            this.depTb = new System.Windows.Forms.TextBox();
            this.hidesal = new System.Windows.Forms.Button();
            this.enterBtn = new System.Windows.Forms.Button();
            this.fioenterTb = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.depenterTb = new System.Windows.Forms.TextBox();
            this.fioenterLB = new System.Windows.Forms.Label();
            this.depenterLB = new System.Windows.Forms.Label();
            this.monthenterBox = new System.Windows.Forms.ListBox();
            this.monthenterLB = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.adduserBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 266);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(505, 172);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Используйте форму ниже, чтобы вывести всех сотрудников отдела с их зп за данный м" +
    "есяц: ";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "январь",
            "февраль",
            "март",
            "апрель",
            "май",
            "июнь",
            "июль",
            "август",
            "сентябрь",
            "октябрь",
            "ноябрь",
            "декабрь"});
            this.listBox1.Location = new System.Drawing.Point(183, 77);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(142, 43);
            this.listBox1.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(355, 100);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Введите название отдела";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // Отобразить
            // 
            this.Отобразить.Location = new System.Drawing.Point(11, 79);
            this.Отобразить.Name = "Отобразить";
            this.Отобразить.Size = new System.Drawing.Size(129, 41);
            this.Отобразить.TabIndex = 2;
            this.Отобразить.Text = "Вывести!";
            this.Отобразить.UseVisualStyleBackColor = true;
            this.Отобразить.Click += new System.EventHandler(this.button1_Click);
            // 
            // amountpayLabel
            // 
            this.amountpayLabel.AutoSize = true;
            this.amountpayLabel.Location = new System.Drawing.Point(537, 266);
            this.amountpayLabel.Name = "amountpayLabel";
            this.amountpayLabel.Size = new System.Drawing.Size(0, 13);
            this.amountpayLabel.TabIndex = 6;
            // 
            // averagepayLabel
            // 
            this.averagepayLabel.AutoSize = true;
            this.averagepayLabel.Location = new System.Drawing.Point(540, 303);
            this.averagepayLabel.Name = "averagepayLabel";
            this.averagepayLabel.Size = new System.Drawing.Size(0, 13);
            this.averagepayLabel.TabIndex = 7;
            this.averagepayLabel.UseWaitCursor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 45);
            this.button1.TabIndex = 8;
            this.button1.Text = "Отобразить выплаты за год";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(15, 215);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(125, 42);
            this.deleteButton.TabIndex = 9;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // fioTb
            // 
            this.fioTb.Location = new System.Drawing.Point(183, 210);
            this.fioTb.Name = "fioTb";
            this.fioTb.Size = new System.Drawing.Size(142, 20);
            this.fioTb.TabIndex = 10;
            this.fioTb.Text = "Введите ФИО";
            this.fioTb.Click += new System.EventHandler(this.fioTb_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(355, 215);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(161, 41);
            this.editBtn.TabIndex = 11;
            this.editBtn.Text = "Редактировать";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // depTb
            // 
            this.depTb.Location = new System.Drawing.Point(183, 236);
            this.depTb.Name = "depTb";
            this.depTb.Size = new System.Drawing.Size(142, 20);
            this.depTb.TabIndex = 12;
            this.depTb.Text = "Введите отдел";
            this.depTb.Click += new System.EventHandler(this.depTb_Click);
            // 
            // hidesal
            // 
            this.hidesal.Location = new System.Drawing.Point(183, 145);
            this.hidesal.Name = "hidesal";
            this.hidesal.Size = new System.Drawing.Size(142, 45);
            this.hidesal.TabIndex = 13;
            this.hidesal.Text = "Скрыть выплаты за год";
            this.hidesal.UseVisualStyleBackColor = true;
            this.hidesal.Click += new System.EventHandler(this.hidesal_Click);
            // 
            // enterBtn
            // 
            this.enterBtn.Location = new System.Drawing.Point(562, 77);
            this.enterBtn.Name = "enterBtn";
            this.enterBtn.Size = new System.Drawing.Size(126, 42);
            this.enterBtn.TabIndex = 14;
            this.enterBtn.Text = "Добавить запись";
            this.enterBtn.UseVisualStyleBackColor = true;
            this.enterBtn.Click += new System.EventHandler(this.enterBtn_Click);
            // 
            // fioenterTb
            // 
            this.fioenterTb.Location = new System.Drawing.Point(713, 99);
            this.fioenterTb.Name = "fioenterTb";
            this.fioenterTb.Size = new System.Drawing.Size(100, 20);
            this.fioenterTb.TabIndex = 15;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(562, 125);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 17);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Добавить доход";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // depenterTb
            // 
            this.depenterTb.Location = new System.Drawing.Point(840, 99);
            this.depenterTb.Name = "depenterTb";
            this.depenterTb.Size = new System.Drawing.Size(100, 20);
            this.depenterTb.TabIndex = 17;
            // 
            // fioenterLB
            // 
            this.fioenterLB.AutoSize = true;
            this.fioenterLB.Location = new System.Drawing.Point(710, 77);
            this.fioenterLB.Name = "fioenterLB";
            this.fioenterLB.Size = new System.Drawing.Size(82, 13);
            this.fioenterLB.TabIndex = 18;
            this.fioenterLB.Text = "Введите ФИО:";
            // 
            // depenterLB
            // 
            this.depenterLB.AutoSize = true;
            this.depenterLB.Location = new System.Drawing.Point(837, 77);
            this.depenterLB.Name = "depenterLB";
            this.depenterLB.Size = new System.Drawing.Size(84, 13);
            this.depenterLB.TabIndex = 19;
            this.depenterLB.Text = "Введите отдел:";
            // 
            // monthenterBox
            // 
            this.monthenterBox.FormattingEnabled = true;
            this.monthenterBox.Items.AddRange(new object[] {
            "январь",
            "февраль",
            "март",
            "апрель",
            "май",
            "июнь",
            "июль",
            "август",
            "сентябрь",
            "октябрь",
            "ноябрь",
            "декабрь"});
            this.monthenterBox.Location = new System.Drawing.Point(713, 147);
            this.monthenterBox.Name = "monthenterBox";
            this.monthenterBox.Size = new System.Drawing.Size(142, 43);
            this.monthenterBox.TabIndex = 20;
            // 
            // monthenterLB
            // 
            this.monthenterLB.AutoSize = true;
            this.monthenterLB.Location = new System.Drawing.Point(713, 128);
            this.monthenterLB.Name = "monthenterLB";
            this.monthenterLB.Size = new System.Drawing.Size(95, 13);
            this.monthenterLB.TabIndex = 21;
            this.monthenterLB.Text = "Выберите месяц:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(437, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Используйте форму, чтобы отображать работников с доходом за год либо без него:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(426, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Используйте форму, чтобы удалять специалиство по ФИО, либо менять их отдел:";
            // 
            // adduserBtn
            // 
            this.adduserBtn.Location = new System.Drawing.Point(15, 12);
            this.adduserBtn.Name = "adduserBtn";
            this.adduserBtn.Size = new System.Drawing.Size(125, 42);
            this.adduserBtn.TabIndex = 24;
            this.adduserBtn.Text = "Добавить пользователя";
            this.adduserBtn.UseVisualStyleBackColor = true;
            this.adduserBtn.Click += new System.EventHandler(this.adduserBtn_Click);
            // 
            // workForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 493);
            this.Controls.Add(this.adduserBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.monthenterLB);
            this.Controls.Add(this.monthenterBox);
            this.Controls.Add(this.depenterLB);
            this.Controls.Add(this.fioenterLB);
            this.Controls.Add(this.depenterTb);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.fioenterTb);
            this.Controls.Add(this.enterBtn);
            this.Controls.Add(this.hidesal);
            this.Controls.Add(this.depTb);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.fioTb);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.averagepayLabel);
            this.Controls.Add(this.amountpayLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Отобразить);
            this.Controls.Add(this.dataGridView1);
            this.Name = "workForm";
            this.Text = "SpecialistSalary";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.workForm_FormClosing);
            this.Load += new System.EventHandler(this.workForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Отобразить;
        private System.Windows.Forms.Label amountpayLabel;
        private System.Windows.Forms.Label averagepayLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox fioTb;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.TextBox depTb;
        private System.Windows.Forms.Button hidesal;
        private System.Windows.Forms.Button enterBtn;
        private System.Windows.Forms.TextBox fioenterTb;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox depenterTb;
        private System.Windows.Forms.Label fioenterLB;
        private System.Windows.Forms.Label depenterLB;
        private System.Windows.Forms.ListBox monthenterBox;
        private System.Windows.Forms.Label monthenterLB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button adduserBtn;
    }
}