﻿using System;

namespace _17605096_GADE6112_POE
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
            this.components = new System.ComponentModel.Container();
            this.BtnStartSim = new System.Windows.Forms.Button();
            this.BtnPauseSim = new System.Windows.Forms.Button();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblRoundSim = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.GBMap = new System.Windows.Forms.GroupBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnRead = new System.Windows.Forms.Button();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.xsize = new System.Windows.Forms.Label();
            this.ysize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnStartSim
            // 
            this.BtnStartSim.Location = new System.Drawing.Point(804, 12);
            this.BtnStartSim.Name = "BtnStartSim";
            this.BtnStartSim.Size = new System.Drawing.Size(75, 23);
            this.BtnStartSim.TabIndex = 0;
            this.BtnStartSim.Text = "Start";
            this.BtnStartSim.UseVisualStyleBackColor = true;
            this.BtnStartSim.Click += new System.EventHandler(this.BtnStartSim_Click);
            // 
            // BtnPauseSim
            // 
            this.BtnPauseSim.Location = new System.Drawing.Point(804, 42);
            this.BtnPauseSim.Name = "BtnPauseSim";
            this.BtnPauseSim.Size = new System.Drawing.Size(75, 23);
            this.BtnPauseSim.TabIndex = 1;
            this.BtnPauseSim.Text = "Pause";
            this.BtnPauseSim.UseVisualStyleBackColor = true;
            this.BtnPauseSim.Click += new System.EventHandler(this.BtnPauseSim_Click);
            // 
            // Timer1
            // 
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick_1);
            // 
            // lblRoundSim
            // 
            this.lblRoundSim.AutoSize = true;
            this.lblRoundSim.Location = new System.Drawing.Point(704, 17);
            this.lblRoundSim.Name = "lblRoundSim";
            this.lblRoundSim.Size = new System.Drawing.Size(0, 13);
            this.lblRoundSim.TabIndex = 2;
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(651, 121);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(228, 365);
            this.txtInfo.TabIndex = 3;
            // 
            // GBMap
            // 
            this.GBMap.Location = new System.Drawing.Point(12, 12);
            this.GBMap.Name = "GBMap";
            this.GBMap.Size = new System.Drawing.Size(552, 474);
            this.GBMap.TabIndex = 4;
            this.GBMap.TabStop = false;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(616, 11);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 5;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnRead
            // 
            this.BtnRead.Location = new System.Drawing.Point(616, 42);
            this.BtnRead.Name = "BtnRead";
            this.BtnRead.Size = new System.Drawing.Size(75, 23);
            this.BtnRead.TabIndex = 6;
            this.BtnRead.Text = "Load";
            this.BtnRead.UseVisualStyleBackColor = true;
            this.BtnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(571, 160);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(74, 20);
            this.txtX.TabIndex = 7;
            this.txtX.Text = "552";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(571, 199);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(74, 20);
            this.txtY.TabIndex = 8;
            this.txtY.Text = "474";
            // 
            // xsize
            // 
            this.xsize.AutoSize = true;
            this.xsize.Location = new System.Drawing.Point(570, 144);
            this.xsize.Name = "xsize";
            this.xsize.Size = new System.Drawing.Size(37, 13);
            this.xsize.TabIndex = 9;
            this.xsize.Text = "X Size";
            this.xsize.Click += new System.EventHandler(this.Label1_Click);
            // 
            // ysize
            // 
            this.ysize.AutoSize = true;
            this.ysize.Location = new System.Drawing.Point(572, 183);
            this.ysize.Name = "ysize";
            this.ysize.Size = new System.Drawing.Size(37, 13);
            this.ysize.TabIndex = 10;
            this.ysize.Text = "Y Size";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(888, 499);
            this.Controls.Add(this.ysize);
            this.Controls.Add(this.xsize);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.BtnRead);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.GBMap);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.lblRoundSim);
            this.Controls.Add(this.BtnPauseSim);
            this.Controls.Add(this.BtnStartSim);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Button BtnStartSim;
        private System.Windows.Forms.Button BtnPauseSim;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Label lblRoundSim;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.GroupBox GBMap;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnRead;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label xsize;
        private System.Windows.Forms.Label ysize;
    }
}

