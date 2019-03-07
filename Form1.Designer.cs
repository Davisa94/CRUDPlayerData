namespace WindowsFormsApp1
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
            this.label2 = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.jerseyNumTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.currentTeamTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.middleNameTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pastTeamTextBox1 = new System.Windows.Forms.TextBox();
            this.pastTeamTextBox3 = new System.Windows.Forms.TextBox();
            this.pastTeamTextBox5 = new System.Windows.Forms.TextBox();
            this.pastTeamTextBox7 = new System.Windows.Forms.TextBox();
            this.pastTeamTextBox9 = new System.Windows.Forms.TextBox();
            this.pastTeamTextBox2 = new System.Windows.Forms.TextBox();
            this.pastTeamTextBox4 = new System.Windows.Forms.TextBox();
            this.pastTeamTextBox6 = new System.Windows.Forms.TextBox();
            this.pastTeamTextBox8 = new System.Windows.Forms.TextBox();
            this.pastTeamTextBox10 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "First Name:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(124, 64);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(251, 22);
            this.firstNameTextBox.TabIndex = 1;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(124, 120);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(251, 22);
            this.lastNameTextBox.TabIndex = 3;
            this.lastNameTextBox.TextChanged += new System.EventHandler(this.lastNameTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Last Name:";
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player Information";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(303, 444);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 18;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Past Teams";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // jerseyNumTextBox
            // 
            this.jerseyNumTextBox.Location = new System.Drawing.Point(124, 148);
            this.jerseyNumTextBox.Name = "jerseyNumTextBox";
            this.jerseyNumTextBox.Size = new System.Drawing.Size(251, 22);
            this.jerseyNumTextBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Jersey #:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(124, 176);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(251, 22);
            this.heightTextBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Height:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Date of Birth:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(124, 232);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(251, 22);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.Value = new System.DateTime(1994, 6, 15, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Current Team:";
            // 
            // currentTeamTextBox
            // 
            this.currentTeamTextBox.Location = new System.Drawing.Point(124, 204);
            this.currentTeamTextBox.Name = "currentTeamTextBox";
            this.currentTeamTextBox.Size = new System.Drawing.Size(251, 22);
            this.currentTeamTextBox.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(404, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(258, 32);
            this.label9.TabIndex = 19;
            this.label9.Text = "Display Information";
            // 
            // middleNameTextBox
            // 
            this.middleNameTextBox.Location = new System.Drawing.Point(124, 92);
            this.middleNameTextBox.Name = "middleNameTextBox";
            this.middleNameTextBox.Size = new System.Drawing.Size(251, 22);
            this.middleNameTextBox.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "Middle Name:";
            // 
            // pastTeamTextBox1
            // 
            this.pastTeamTextBox1.Location = new System.Drawing.Point(0, 6);
            this.pastTeamTextBox1.Name = "pastTeamTextBox1";
            this.pastTeamTextBox1.Size = new System.Drawing.Size(156, 22);
            this.pastTeamTextBox1.TabIndex = 8;
            // 
            // pastTeamTextBox3
            // 
            this.pastTeamTextBox3.Location = new System.Drawing.Point(0, 34);
            this.pastTeamTextBox3.Name = "pastTeamTextBox3";
            this.pastTeamTextBox3.Size = new System.Drawing.Size(156, 22);
            this.pastTeamTextBox3.TabIndex = 10;
            // 
            // pastTeamTextBox5
            // 
            this.pastTeamTextBox5.Location = new System.Drawing.Point(0, 62);
            this.pastTeamTextBox5.Name = "pastTeamTextBox5";
            this.pastTeamTextBox5.Size = new System.Drawing.Size(156, 22);
            this.pastTeamTextBox5.TabIndex = 12;
            // 
            // pastTeamTextBox7
            // 
            this.pastTeamTextBox7.Location = new System.Drawing.Point(0, 90);
            this.pastTeamTextBox7.Name = "pastTeamTextBox7";
            this.pastTeamTextBox7.Size = new System.Drawing.Size(156, 22);
            this.pastTeamTextBox7.TabIndex = 14;
            this.pastTeamTextBox7.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // pastTeamTextBox9
            // 
            this.pastTeamTextBox9.Location = new System.Drawing.Point(0, 118);
            this.pastTeamTextBox9.Name = "pastTeamTextBox9";
            this.pastTeamTextBox9.Size = new System.Drawing.Size(156, 22);
            this.pastTeamTextBox9.TabIndex = 16;
            this.pastTeamTextBox9.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // pastTeamTextBox2
            // 
            this.pastTeamTextBox2.Location = new System.Drawing.Point(197, 6);
            this.pastTeamTextBox2.Name = "pastTeamTextBox2";
            this.pastTeamTextBox2.Size = new System.Drawing.Size(156, 22);
            this.pastTeamTextBox2.TabIndex = 9;
            // 
            // pastTeamTextBox4
            // 
            this.pastTeamTextBox4.Location = new System.Drawing.Point(197, 34);
            this.pastTeamTextBox4.Name = "pastTeamTextBox4";
            this.pastTeamTextBox4.Size = new System.Drawing.Size(156, 22);
            this.pastTeamTextBox4.TabIndex = 11;
            this.pastTeamTextBox4.TextChanged += new System.EventHandler(this.pastTeamTextBox4_TextChanged);
            // 
            // pastTeamTextBox6
            // 
            this.pastTeamTextBox6.Location = new System.Drawing.Point(197, 62);
            this.pastTeamTextBox6.Name = "pastTeamTextBox6";
            this.pastTeamTextBox6.Size = new System.Drawing.Size(156, 22);
            this.pastTeamTextBox6.TabIndex = 13;
            // 
            // pastTeamTextBox8
            // 
            this.pastTeamTextBox8.Location = new System.Drawing.Point(197, 90);
            this.pastTeamTextBox8.Name = "pastTeamTextBox8";
            this.pastTeamTextBox8.Size = new System.Drawing.Size(156, 22);
            this.pastTeamTextBox8.TabIndex = 15;
            // 
            // pastTeamTextBox10
            // 
            this.pastTeamTextBox10.Location = new System.Drawing.Point(197, 118);
            this.pastTeamTextBox10.Name = "pastTeamTextBox10";
            this.pastTeamTextBox10.Size = new System.Drawing.Size(156, 22);
            this.pastTeamTextBox10.TabIndex = 17;
            this.pastTeamTextBox10.TextChanged += new System.EventHandler(this.pastTeamTextBox10_TextChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pastTeamTextBox10);
            this.panel1.Controls.Add(this.pastTeamTextBox8);
            this.panel1.Controls.Add(this.pastTeamTextBox6);
            this.panel1.Controls.Add(this.pastTeamTextBox4);
            this.panel1.Controls.Add(this.pastTeamTextBox2);
            this.panel1.Controls.Add(this.pastTeamTextBox9);
            this.panel1.Controls.Add(this.pastTeamTextBox7);
            this.panel1.Controls.Add(this.pastTeamTextBox5);
            this.panel1.Controls.Add(this.pastTeamTextBox3);
            this.panel1.Controls.Add(this.pastTeamTextBox1);
            this.panel1.Location = new System.Drawing.Point(22, 298);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 140);
            this.panel1.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 767);
            this.Controls.Add(this.middleNameTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.currentTeamTextBox);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.jerseyNumTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "PlayerData";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox jerseyNumTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox currentTeamTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox middleNameTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox pastTeamTextBox1;
        private System.Windows.Forms.TextBox pastTeamTextBox3;
        private System.Windows.Forms.TextBox pastTeamTextBox5;
        private System.Windows.Forms.TextBox pastTeamTextBox7;
        private System.Windows.Forms.TextBox pastTeamTextBox9;
        private System.Windows.Forms.TextBox pastTeamTextBox2;
        private System.Windows.Forms.TextBox pastTeamTextBox4;
        private System.Windows.Forms.TextBox pastTeamTextBox6;
        private System.Windows.Forms.TextBox pastTeamTextBox8;
        private System.Windows.Forms.TextBox pastTeamTextBox10;
        private System.Windows.Forms.Panel panel1;
    }
}

