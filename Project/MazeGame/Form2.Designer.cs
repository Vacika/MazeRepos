namespace MazeGame
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_HP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_time = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.btn_save = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_finish = new System.Windows.Forms.Label();
            this.btn_View = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_Score = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(56, 19);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(116, 20);
            this.txt_name.TabIndex = 1;
            // 
            // txt_HP
            // 
            this.txt_HP.Location = new System.Drawing.Point(56, 46);
            this.txt_HP.Name = "txt_HP";
            this.txt_HP.ReadOnly = true;
            this.txt_HP.Size = new System.Drawing.Size(116, 20);
            this.txt_HP.TabIndex = 2;
            this.txt_HP.TextChanged += new System.EventHandler(this.txt_HP_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "HP:";
            // 
            // txt_time
            // 
            this.txt_time.Location = new System.Drawing.Point(56, 72);
            this.txt_time.Name = "txt_time";
            this.txt_time.ReadOnly = true;
            this.txt_time.Size = new System.Drawing.Size(116, 20);
            this.txt_time.TabIndex = 4;
            this.txt_time.TextChanged += new System.EventHandler(this.txt_time_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Time:";
            // 
            // dataView
            // 
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Location = new System.Drawing.Point(4, 138);
            this.dataView.Name = "dataView";
            this.dataView.Size = new System.Drawing.Size(308, 170);
            this.dataView.TabIndex = 6;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(210, 19);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(91, 38);
            this.btn_save.TabIndex = 7;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Rank";
            // 
            // lbl_finish
            // 
            this.lbl_finish.AutoSize = true;
            this.lbl_finish.Location = new System.Drawing.Point(12, 9);
            this.lbl_finish.Name = "lbl_finish";
            this.lbl_finish.Size = new System.Drawing.Size(0, 13);
            this.lbl_finish.TabIndex = 9;
            // 
            // btn_View
            // 
            this.btn_View.Enabled = false;
            this.btn_View.Location = new System.Drawing.Point(210, 75);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(91, 42);
            this.btn_View.TabIndex = 10;
            this.btn_View.Text = "View Scores";
            this.btn_View.UseVisualStyleBackColor = true;
            this.btn_View.Click += new System.EventHandler(this.btn_View_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Score:";
            // 
            // tb_Score
            // 
            this.tb_Score.Location = new System.Drawing.Point(56, 98);
            this.tb_Score.Name = "tb_Score";
            this.tb_Score.ReadOnly = true;
            this.tb_Score.Size = new System.Drawing.Size(116, 20);
            this.tb_Score.TabIndex = 12;
            this.tb_Score.TextChanged += new System.EventHandler(this.tb_Score_TextChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 312);
            this.Controls.Add(this.tb_Score);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_View);
            this.Controls.Add(this.lbl_finish);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_time);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_HP);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_HP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_time;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_finish;
        private System.Windows.Forms.Button btn_View;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_Score;
    }
}