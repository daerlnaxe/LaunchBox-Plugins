namespace CCLaunchBox
{
    partial class UCPaths
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbRelatPath = new System.Windows.Forms.Label();
            this.tbHardPath = new System.Windows.Forms.TextBox();
            this.tableLP = new System.Windows.Forms.TableLayoutPanel();
            this.tableLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbRelatPath
            // 
            this.lbRelatPath.AutoSize = true;
            this.lbRelatPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRelatPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lbRelatPath.Location = new System.Drawing.Point(6, 20);
            this.lbRelatPath.Name = "lbRelatPath";
            this.lbRelatPath.Size = new System.Drawing.Size(222, 25);
            this.lbRelatPath.TabIndex = 1;
            this.lbRelatPath.Text = "RelatPath";
            this.lbRelatPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbRelatPath.Click += new System.EventHandler(this.lbRelatPath_Click);
            // 
            // tbHardPath
            // 
            this.tbHardPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHardPath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbHardPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbHardPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHardPath.Location = new System.Drawing.Point(6, 3);
            this.tbHardPath.Name = "tbHardPath";
            this.tbHardPath.ReadOnly = true;
            this.tbHardPath.Size = new System.Drawing.Size(222, 11);
            this.tbHardPath.TabIndex = 2;
            this.tbHardPath.Text = "hardPath";
            this.tbHardPath.WordWrap = false;
            this.tbHardPath.TextChanged += new System.EventHandler(this.tbHardPath_TextChanged);
            // 
            // tableLP
            // 
            this.tableLP.ColumnCount = 1;
            this.tableLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLP.Controls.Add(this.lbRelatPath, 0, 1);
            this.tableLP.Controls.Add(this.tbHardPath, 0, 0);
            this.tableLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP.Location = new System.Drawing.Point(0, 0);
            this.tableLP.Name = "tableLP";
            this.tableLP.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.tableLP.RowCount = 3;
            this.tableLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLP.Size = new System.Drawing.Size(85, 65);
            this.tableLP.TabIndex = 3;
            // 
            // UCPaths
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.Controls.Add(this.tableLP);
            this.MinimumSize = new System.Drawing.Size(0, 60);
            this.Name = "UCPaths";
            this.Size = new System.Drawing.Size(85, 65);
            this.Load += new System.EventHandler(this.UCPaths_Load);
            this.tableLP.ResumeLayout(false);
            this.tableLP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbRelatPath;
        private System.Windows.Forms.TextBox tbHardPath;
        private System.Windows.Forms.TableLayoutPanel tableLP;
    }
}
