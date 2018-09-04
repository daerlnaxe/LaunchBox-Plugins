namespace SappPasRoot.Graph
{
    partial class List_Platform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(List_Platform));
            this.label1 = new System.Windows.Forms.Label();
            this.lvPlatforms = new System.Windows.Forms.ListView();
            this.colPlatformName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.cxMenuListP = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cPlatPaths = new System.Windows.Forms.ToolStripMenuItem();
            this.cGamesPaths = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cxMenuListP.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lvPlatforms
            // 
            resources.ApplyResources(this.lvPlatforms, "lvPlatforms");
            this.lvPlatforms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPlatformName,
            this.colPath});
            this.lvPlatforms.FullRowSelect = true;
            this.lvPlatforms.MultiSelect = false;
            this.lvPlatforms.Name = "lvPlatforms";
            this.toolTip1.SetToolTip(this.lvPlatforms, resources.GetString("lvPlatforms.ToolTip"));
            this.lvPlatforms.UseCompatibleStateImageBehavior = false;
            this.lvPlatforms.View = System.Windows.Forms.View.Details;
            this.lvPlatforms.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvPlatforms_MouseClick);
            this.lvPlatforms.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvPlatforms_MouseDoubleClick);
            // 
            // colPlatformName
            // 
            resources.ApplyResources(this.colPlatformName, "colPlatformName");
            // 
            // colPath
            // 
            resources.ApplyResources(this.colPath, "colPath");
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cxMenuListP
            // 
            this.cxMenuListP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cPlatPaths,
            this.cGamesPaths});
            this.cxMenuListP.Name = "cxMenuListP";
            resources.ApplyResources(this.cxMenuListP, "cxMenuListP");
            // 
            // cPlatPaths
            // 
            this.cPlatPaths.Name = "cPlatPaths";
            resources.ApplyResources(this.cPlatPaths, "cPlatPaths");
            this.cPlatPaths.Click += new System.EventHandler(this.cPlatPaths_Click);
            // 
            // cGamesPaths
            // 
            this.cGamesPaths.Name = "cGamesPaths";
            resources.ApplyResources(this.cGamesPaths, "cGamesPaths");
            this.cGamesPaths.Click += new System.EventHandler(this.cGamesPaths_Click);
            // 
            // List_Platform
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lvPlatforms);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "List_Platform";
            this.cxMenuListP.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvPlatforms;
        private System.Windows.Forms.ColumnHeader colPlatformName;
        private System.Windows.Forms.ColumnHeader colPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip cxMenuListP;
        private System.Windows.Forms.ToolStripMenuItem cPlatPaths;
        private System.Windows.Forms.ToolStripMenuItem cGamesPaths;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}