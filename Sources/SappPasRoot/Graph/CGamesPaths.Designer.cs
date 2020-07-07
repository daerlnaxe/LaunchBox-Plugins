namespace SappPasRoot.Graph
{
    partial class CGamesPaths
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CGamesPaths));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tlpInfos = new System.Windows.Forms.TableLayoutPanel();
            this.labPName = new System.Windows.Forms.Label();
            this.titPlatform = new System.Windows.Forms.Label();
            this.titCPath = new System.Windows.Forms.Label();
            this.tboxHOldPath = new System.Windows.Forms.TextBox();
            this.titCRPath = new System.Windows.Forms.Label();
            this.tboxROldPath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbForced = new System.Windows.Forms.RadioButton();
            this.rbKeepSub = new System.Windows.Forms.RadioButton();
            this.groupScan = new System.Windows.Forms.GroupBox();
            this.btRescan = new System.Windows.Forms.Button();
            this.cbHidden = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.titChooseFolder = new System.Windows.Forms.Label();
            this.tbMainPath = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btBrowse = new System.Windows.Forms.Button();
            this.btSimul = new System.Windows.Forms.Button();
            this.btApply = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.flpGames = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTop = new System.Windows.Forms.TableLayoutPanel();
            this.boxLog = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbAddAppPaths = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tlpInfos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupScan.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.panelTop.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupScan, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 2, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.tlpInfos);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // tlpInfos
            // 
            resources.ApplyResources(this.tlpInfos, "tlpInfos");
            this.tlpInfos.Controls.Add(this.labPName, 1, 0);
            this.tlpInfos.Controls.Add(this.titPlatform, 0, 0);
            this.tlpInfos.Controls.Add(this.titCPath, 0, 1);
            this.tlpInfos.Controls.Add(this.tboxHOldPath, 1, 1);
            this.tlpInfos.Controls.Add(this.titCRPath, 0, 2);
            this.tlpInfos.Controls.Add(this.tboxROldPath, 1, 2);
            this.tlpInfos.Name = "tlpInfos";
            // 
            // labPName
            // 
            resources.ApplyResources(this.labPName, "labPName");
            this.labPName.Name = "labPName";
            // 
            // titPlatform
            // 
            resources.ApplyResources(this.titPlatform, "titPlatform");
            this.titPlatform.Name = "titPlatform";
            // 
            // titCPath
            // 
            resources.ApplyResources(this.titCPath, "titCPath");
            this.titCPath.Name = "titCPath";
            // 
            // tboxHOldPath
            // 
            this.tboxHOldPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tboxHOldPath, "tboxHOldPath");
            this.tboxHOldPath.Name = "tboxHOldPath";
            this.tboxHOldPath.ReadOnly = true;
            this.tboxHOldPath.TextChanged += new System.EventHandler(this.ResizeTextBox);
            // 
            // titCRPath
            // 
            resources.ApplyResources(this.titCRPath, "titCRPath");
            this.titCRPath.Name = "titCRPath";
            // 
            // tboxROldPath
            // 
            this.tboxROldPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tboxROldPath, "tboxROldPath");
            this.tboxROldPath.Name = "tboxROldPath";
            this.tboxROldPath.ReadOnly = true;
            this.tboxROldPath.TextChanged += new System.EventHandler(this.ResizeTextBox);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.rbForced);
            this.groupBox1.Controls.Add(this.rbKeepSub);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // rbForced
            // 
            resources.ApplyResources(this.rbForced, "rbForced");
            this.rbForced.Checked = true;
            this.rbForced.Name = "rbForced";
            this.rbForced.TabStop = true;
            this.toolTip1.SetToolTip(this.rbForced, resources.GetString("rbForced.ToolTip"));
            this.rbForced.UseVisualStyleBackColor = true;
            this.rbForced.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbKeepSub
            // 
            resources.ApplyResources(this.rbKeepSub, "rbKeepSub");
            this.rbKeepSub.Name = "rbKeepSub";
            this.rbKeepSub.TabStop = true;
            this.toolTip1.SetToolTip(this.rbKeepSub, resources.GetString("rbKeepSub.ToolTip"));
            this.rbKeepSub.UseVisualStyleBackColor = true;
            this.rbKeepSub.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // groupScan
            // 
            resources.ApplyResources(this.groupScan, "groupScan");
            this.groupScan.Controls.Add(this.btRescan);
            this.groupScan.Controls.Add(this.cbHidden);
            this.groupScan.Name = "groupScan";
            this.groupScan.TabStop = false;
            // 
            // btRescan
            // 
            resources.ApplyResources(this.btRescan, "btRescan");
            this.btRescan.Name = "btRescan";
            this.btRescan.UseVisualStyleBackColor = true;
            this.btRescan.Click += new System.EventHandler(this.btRescan_Click);
            // 
            // cbHidden
            // 
            resources.ApplyResources(this.cbHidden, "cbHidden");
            this.cbHidden.Name = "cbHidden";
            this.cbHidden.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.titChooseFolder, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbMainPath, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 2, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // titChooseFolder
            // 
            resources.ApplyResources(this.titChooseFolder, "titChooseFolder");
            this.titChooseFolder.Name = "titChooseFolder";
            // 
            // tbMainPath
            // 
            resources.ApplyResources(this.tbMainPath, "tbMainPath");
            this.tbMainPath.Name = "tbMainPath";
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.btBrowse);
            this.flowLayoutPanel1.Controls.Add(this.btSimul);
            this.flowLayoutPanel1.Controls.Add(this.btApply);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.tableLayoutPanel1.SetRowSpan(this.flowLayoutPanel1, 2);
            // 
            // btBrowse
            // 
            resources.ApplyResources(this.btBrowse, "btBrowse");
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.UseVisualStyleBackColor = true;
            // 
            // btSimul
            // 
            resources.ApplyResources(this.btSimul, "btSimul");
            this.btSimul.Name = "btSimul";
            this.toolTip1.SetToolTip(this.btSimul, resources.GetString("btSimul.ToolTip"));
            this.btSimul.UseVisualStyleBackColor = true;
            this.btSimul.Click += new System.EventHandler(this.btSimul_Click);
            // 
            // btApply
            // 
            resources.ApplyResources(this.btApply, "btApply");
            this.btApply.Name = "btApply";
            this.toolTip1.SetToolTip(this.btApply, resources.GetString("btApply.ToolTip"));
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // flpGames
            // 
            resources.ApplyResources(this.flpGames, "flpGames");
            this.flpGames.BackColor = System.Drawing.SystemColors.Control;
            this.flpGames.Name = "flpGames";
            // 
            // panelTop
            // 
            resources.ApplyResources(this.panelTop, "panelTop");
            this.panelTop.Controls.Add(this.boxLog, 0, 3);
            this.panelTop.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.panelTop.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.panelTop.Controls.Add(this.flpGames, 0, 2);
            this.panelTop.Name = "panelTop";
            // 
            // boxLog
            // 
            this.panelTop.SetColumnSpan(this.boxLog, 2);
            resources.ApplyResources(this.boxLog, "boxLog");
            this.boxLog.Name = "boxLog";
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.cbAddAppPaths);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // cbAddAppPaths
            // 
            resources.ApplyResources(this.cbAddAppPaths, "cbAddAppPaths");
            this.cbAddAppPaths.Name = "cbAddAppPaths";
            this.cbAddAppPaths.UseVisualStyleBackColor = true;
            // 
            // CGamesPaths
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.statusStrip1);
            this.Name = "CGamesPaths";
            this.Load += new System.EventHandler(this.CGamesPaths_Load);
            this.Shown += new System.EventHandler(this.CGamesPaths_Shown);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tlpInfos.ResumeLayout(false);
            this.tlpInfos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupScan.ResumeLayout(false);
            this.groupScan.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label titChooseFolder;
        protected internal System.Windows.Forms.TextBox tbMainPath;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.TableLayoutPanel tlpInfos;
        private System.Windows.Forms.Label labPName;
        private System.Windows.Forms.Label titPlatform;
        private System.Windows.Forms.Label titCPath;
        protected internal System.Windows.Forms.TextBox tboxHOldPath;
        private System.Windows.Forms.Label titCRPath;
        protected internal System.Windows.Forms.TextBox tboxROldPath;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btSimul;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.RadioButton rbKeepSub;
        private System.Windows.Forms.RadioButton rbForced;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupScan;
        private System.Windows.Forms.CheckBox cbHidden;
        private System.Windows.Forms.Button btRescan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flpGames;
        private System.Windows.Forms.TableLayoutPanel panelTop;
        private System.Windows.Forms.RichTextBox boxLog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbAddAppPaths;
    }
}