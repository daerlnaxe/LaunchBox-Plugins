namespace CCLaunchBox
{
    partial class PlatformBandeau
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
            this.components = new System.ComponentModel.Container();
            this.lbCateg = new System.Windows.Forms.Label();
            this.lbArrow = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ucPaths1 = new CCLaunchBox.UCPaths();
            this.ucPaths2 = new CCLaunchBox.UCPaths();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCateg
            // 
            this.lbCateg.AutoSize = true;
            this.lbCateg.BackColor = System.Drawing.Color.White;
            this.lbCateg.Location = new System.Drawing.Point(0, 0);
            this.lbCateg.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.lbCateg.Name = "lbCateg";
            this.lbCateg.Size = new System.Drawing.Size(35, 13);
            this.lbCateg.TabIndex = 0;
            this.lbCateg.Text = "Categ";
            this.lbCateg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.lbCateg, "Mediatype");
            // 
            // lbArrow
            // 
            this.lbArrow.AutoSize = true;
            this.lbArrow.BackColor = System.Drawing.Color.White;
            this.lbArrow.Location = new System.Drawing.Point(124, 0);
            this.lbArrow.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lbArrow.Name = "lbArrow";
            this.lbArrow.Size = new System.Drawing.Size(19, 13);
            this.lbArrow.TabIndex = 2;
            this.lbArrow.Text = "=>";
            this.lbArrow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.lbCateg);
            this.flowLayoutPanel1.Controls.Add(this.ucPaths1);
            this.flowLayoutPanel1.Controls.Add(this.lbArrow);
            this.flowLayoutPanel1.Controls.Add(this.ucPaths2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(322, 75);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // ucPaths1
            // 
            this.ucPaths1.BackColor = System.Drawing.Color.White;
            this.ucPaths1.FullPath = "hardPath";
            this.ucPaths1.Location = new System.Drawing.Point(37, 0);
            this.ucPaths1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.ucPaths1.MinimumSize = new System.Drawing.Size(0, 60);
            this.ucPaths1.Name = "ucPaths1";
            this.ucPaths1.RelatPath = "RelatPath";
            this.ucPaths1.Size = new System.Drawing.Size(85, 75);
            this.ucPaths1.TabIndex = 1;
            this.ucPaths1.TableWidth = 85;
            // 
            // ucPaths2
            // 
            this.ucPaths2.BackColor = System.Drawing.Color.White;
            this.ucPaths2.FullPath = "hardPath";
            this.ucPaths2.Location = new System.Drawing.Point(145, 0);
            this.ucPaths2.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.ucPaths2.MinimumSize = new System.Drawing.Size(0, 60);
            this.ucPaths2.Name = "ucPaths2";
            this.ucPaths2.RelatPath = "RelatPath";
            this.ucPaths2.Size = new System.Drawing.Size(83, 75);
            this.ucPaths2.TabIndex = 3;
            this.ucPaths2.TableWidth = 83;
            this.ucPaths2.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            // 
            // PlatformBandeau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GreenYellow;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "PlatformBandeau";
            this.Size = new System.Drawing.Size(671, 88);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbArrow;
        private System.Windows.Forms.ToolTip toolTip1;
        private UCPaths ucPaths1;
        private UCPaths ucPaths2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.Label lbCateg;
    }
}
