namespace SappPasRoot.Graph

{
    partial class Change_Path
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Change_Path));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.boxLog = new System.Windows.Forms.RichTextBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.tlpFolders = new System.Windows.Forms.TableLayoutPanel();
            this.titCCodes = new System.Windows.Forms.Label();
            this.titGames = new System.Windows.Forms.Label();
            this.tbGames = new System.Windows.Forms.TextBox();
            this.titManuals = new System.Windows.Forms.Label();
            this.tbManual = new System.Windows.Forms.TextBox();
            this.titImages = new System.Windows.Forms.Label();
            this.tbImages = new System.Windows.Forms.TextBox();
            this.tbVideo = new System.Windows.Forms.TextBox();
            this.titVideos = new System.Windows.Forms.Label();
            this.titMusic = new System.Windows.Forms.Label();
            this.tbMusic = new System.Windows.Forms.TextBox();
            this.tbCCodes = new System.Windows.Forms.TextBox();
            this.btResetFactory = new System.Windows.Forms.Button();
            this.flpPaths = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.titChooseFolder = new System.Windows.Forms.Label();
            this.tbMainPath = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btBrowse = new System.Windows.Forms.Button();
            this.btSimul = new System.Windows.Forms.Button();
            this.btApply = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbMore = new System.Windows.Forms.Label();
            this.tlpInfos = new System.Windows.Forms.TableLayoutPanel();
            this.labPName = new System.Windows.Forms.Label();
            this.titPlatform = new System.Windows.Forms.Label();
            this.titCPath = new System.Windows.Forms.Label();
            this.tboxHOldPath = new System.Windows.Forms.TextBox();
            this.titCRPath = new System.Windows.Forms.Label();
            this.tboxROldPath = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tlpMain.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.tlpFolders.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tlpInfos.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            resources.ApplyResources(this.tlpMain, "tlpMain");
            this.tlpMain.Controls.Add(this.boxLog, 1, 1);
            this.tlpMain.Controls.Add(this.panelTop, 1, 0);
            this.tlpMain.Name = "tlpMain";
            this.toolTip1.SetToolTip(this.tlpMain, resources.GetString("tlpMain.ToolTip"));
            // 
            // boxLog
            // 
            resources.ApplyResources(this.boxLog, "boxLog");
            this.boxLog.BackColor = System.Drawing.SystemColors.InfoText;
            this.boxLog.ForeColor = System.Drawing.Color.Lime;
            this.boxLog.Name = "boxLog";
            this.toolTip1.SetToolTip(this.boxLog, resources.GetString("boxLog.ToolTip"));
            // 
            // panelTop
            // 
            resources.ApplyResources(this.panelTop, "panelTop");
            this.panelTop.Controls.Add(this.tlpFolders);
            this.panelTop.Controls.Add(this.btResetFactory);
            this.panelTop.Controls.Add(this.flpPaths);
            this.panelTop.Controls.Add(this.tableLayoutPanel1);
            this.panelTop.Controls.Add(this.lbMore);
            this.panelTop.Controls.Add(this.tlpInfos);
            this.panelTop.Name = "panelTop";
            this.toolTip1.SetToolTip(this.panelTop, resources.GetString("panelTop.ToolTip"));
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
            // 
            // tlpFolders
            // 
            resources.ApplyResources(this.tlpFolders, "tlpFolders");
            this.tlpFolders.Controls.Add(this.titCCodes, 0, 0);
            this.tlpFolders.Controls.Add(this.titGames, 0, 1);
            this.tlpFolders.Controls.Add(this.tbGames, 1, 1);
            this.tlpFolders.Controls.Add(this.titManuals, 0, 2);
            this.tlpFolders.Controls.Add(this.tbManual, 1, 2);
            this.tlpFolders.Controls.Add(this.titImages, 0, 3);
            this.tlpFolders.Controls.Add(this.tbImages, 1, 3);
            this.tlpFolders.Controls.Add(this.tbVideo, 1, 5);
            this.tlpFolders.Controls.Add(this.titVideos, 0, 5);
            this.tlpFolders.Controls.Add(this.titMusic, 0, 4);
            this.tlpFolders.Controls.Add(this.tbMusic, 1, 4);
            this.tlpFolders.Controls.Add(this.tbCCodes, 1, 0);
            this.tlpFolders.Name = "tlpFolders";
            this.toolTip1.SetToolTip(this.tlpFolders, resources.GetString("tlpFolders.ToolTip"));
            // 
            // titCCodes
            // 
            resources.ApplyResources(this.titCCodes, "titCCodes");
            this.titCCodes.Name = "titCCodes";
            this.toolTip1.SetToolTip(this.titCCodes, resources.GetString("titCCodes.ToolTip"));
            // 
            // titGames
            // 
            resources.ApplyResources(this.titGames, "titGames");
            this.titGames.Name = "titGames";
            this.toolTip1.SetToolTip(this.titGames, resources.GetString("titGames.ToolTip"));
            // 
            // tbGames
            // 
            resources.ApplyResources(this.tbGames, "tbGames");
            this.tbGames.Name = "tbGames";
            this.toolTip1.SetToolTip(this.tbGames, resources.GetString("tbGames.ToolTip"));
            this.tbGames.TextChanged += new System.EventHandler(this.MenuChanged);
            this.tbGames.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FolderNameVerif);
            // 
            // titManuals
            // 
            resources.ApplyResources(this.titManuals, "titManuals");
            this.titManuals.Name = "titManuals";
            this.toolTip1.SetToolTip(this.titManuals, resources.GetString("titManuals.ToolTip"));
            // 
            // tbManual
            // 
            resources.ApplyResources(this.tbManual, "tbManual");
            this.tbManual.Name = "tbManual";
            this.toolTip1.SetToolTip(this.tbManual, resources.GetString("tbManual.ToolTip"));
            this.tbManual.TextChanged += new System.EventHandler(this.MenuChanged);
            this.tbManual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FolderNameVerif);
            // 
            // titImages
            // 
            resources.ApplyResources(this.titImages, "titImages");
            this.titImages.Name = "titImages";
            this.toolTip1.SetToolTip(this.titImages, resources.GetString("titImages.ToolTip"));
            // 
            // tbImages
            // 
            resources.ApplyResources(this.tbImages, "tbImages");
            this.tbImages.Name = "tbImages";
            this.toolTip1.SetToolTip(this.tbImages, resources.GetString("tbImages.ToolTip"));
            this.tbImages.TextChanged += new System.EventHandler(this.MenuChanged);
            this.tbImages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FolderNameVerif);
            // 
            // tbVideo
            // 
            resources.ApplyResources(this.tbVideo, "tbVideo");
            this.tbVideo.Name = "tbVideo";
            this.toolTip1.SetToolTip(this.tbVideo, resources.GetString("tbVideo.ToolTip"));
            this.tbVideo.TextChanged += new System.EventHandler(this.MenuChanged);
            this.tbVideo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FolderNameVerif);
            // 
            // titVideos
            // 
            resources.ApplyResources(this.titVideos, "titVideos");
            this.titVideos.Name = "titVideos";
            this.toolTip1.SetToolTip(this.titVideos, resources.GetString("titVideos.ToolTip"));
            // 
            // titMusic
            // 
            resources.ApplyResources(this.titMusic, "titMusic");
            this.titMusic.Name = "titMusic";
            this.toolTip1.SetToolTip(this.titMusic, resources.GetString("titMusic.ToolTip"));
            // 
            // tbMusic
            // 
            resources.ApplyResources(this.tbMusic, "tbMusic");
            this.tbMusic.Name = "tbMusic";
            this.toolTip1.SetToolTip(this.tbMusic, resources.GetString("tbMusic.ToolTip"));
            this.tbMusic.TextChanged += new System.EventHandler(this.MenuChanged);
            this.tbMusic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FolderNameVerif);
            // 
            // tbCCodes
            // 
            resources.ApplyResources(this.tbCCodes, "tbCCodes");
            this.tbCCodes.Name = "tbCCodes";
            this.tbCCodes.ReadOnly = true;
            this.toolTip1.SetToolTip(this.tbCCodes, resources.GetString("tbCCodes.ToolTip"));
            // 
            // btResetFactory
            // 
            resources.ApplyResources(this.btResetFactory, "btResetFactory");
            this.btResetFactory.Name = "btResetFactory";
            this.toolTip1.SetToolTip(this.btResetFactory, resources.GetString("btResetFactory.ToolTip"));
            this.btResetFactory.UseVisualStyleBackColor = true;
            this.btResetFactory.Click += new System.EventHandler(this.btResetFactory_Click);
            // 
            // flpPaths
            // 
            resources.ApplyResources(this.flpPaths, "flpPaths");
            this.flpPaths.BackColor = System.Drawing.Color.DarkGreen;
            this.flpPaths.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpPaths.Name = "flpPaths";
            this.toolTip1.SetToolTip(this.flpPaths, resources.GetString("flpPaths.ToolTip"));
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.titChooseFolder, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbMainPath, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 2, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.toolTip1.SetToolTip(this.tableLayoutPanel1, resources.GetString("tableLayoutPanel1.ToolTip"));
            // 
            // titChooseFolder
            // 
            resources.ApplyResources(this.titChooseFolder, "titChooseFolder");
            this.titChooseFolder.Name = "titChooseFolder";
            this.toolTip1.SetToolTip(this.titChooseFolder, resources.GetString("titChooseFolder.ToolTip"));
            // 
            // tbMainPath
            // 
            resources.ApplyResources(this.tbMainPath, "tbMainPath");
            this.tbMainPath.Name = "tbMainPath";
            this.toolTip1.SetToolTip(this.tbMainPath, resources.GetString("tbMainPath.ToolTip"));
            this.tbMainPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbMainPath_KeyDown);
            this.tbMainPath.Validating += new System.ComponentModel.CancelEventHandler(this.txbMainPath_Validating);
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.btBrowse);
            this.flowLayoutPanel1.Controls.Add(this.btSimul);
            this.flowLayoutPanel1.Controls.Add(this.btApply);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.tableLayoutPanel1.SetRowSpan(this.flowLayoutPanel1, 2);
            this.toolTip1.SetToolTip(this.flowLayoutPanel1, resources.GetString("flowLayoutPanel1.ToolTip"));
            // 
            // btBrowse
            // 
            resources.ApplyResources(this.btBrowse, "btBrowse");
            this.btBrowse.Name = "btBrowse";
            this.toolTip1.SetToolTip(this.btBrowse, resources.GetString("btBrowse.ToolTip"));
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
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
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.toolTip1.SetToolTip(this.button1, resources.GetString("button1.ToolTip"));
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lbMore
            // 
            resources.ApplyResources(this.lbMore, "lbMore");
            this.lbMore.Cursor = System.Windows.Forms.Cursors.PanEast;
            this.lbMore.Name = "lbMore";
            this.toolTip1.SetToolTip(this.lbMore, resources.GetString("lbMore.ToolTip"));
            this.lbMore.Click += new System.EventHandler(this.label8_Click);
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
            this.toolTip1.SetToolTip(this.tlpInfos, resources.GetString("tlpInfos.ToolTip"));
            // 
            // labPName
            // 
            resources.ApplyResources(this.labPName, "labPName");
            this.labPName.Name = "labPName";
            this.toolTip1.SetToolTip(this.labPName, resources.GetString("labPName.ToolTip"));
            // 
            // titPlatform
            // 
            resources.ApplyResources(this.titPlatform, "titPlatform");
            this.titPlatform.Name = "titPlatform";
            this.toolTip1.SetToolTip(this.titPlatform, resources.GetString("titPlatform.ToolTip"));
            // 
            // titCPath
            // 
            resources.ApplyResources(this.titCPath, "titCPath");
            this.titCPath.Name = "titCPath";
            this.toolTip1.SetToolTip(this.titCPath, resources.GetString("titCPath.ToolTip"));
            // 
            // tboxHOldPath
            // 
            resources.ApplyResources(this.tboxHOldPath, "tboxHOldPath");
            this.tboxHOldPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxHOldPath.Name = "tboxHOldPath";
            this.tboxHOldPath.ReadOnly = true;
            this.toolTip1.SetToolTip(this.tboxHOldPath, resources.GetString("tboxHOldPath.ToolTip"));
            this.tboxHOldPath.TextChanged += new System.EventHandler(this.ResizeTextBox);
            // 
            // titCRPath
            // 
            resources.ApplyResources(this.titCRPath, "titCRPath");
            this.titCRPath.Name = "titCRPath";
            this.toolTip1.SetToolTip(this.titCRPath, resources.GetString("titCRPath.ToolTip"));
            // 
            // tboxROldPath
            // 
            resources.ApplyResources(this.tboxROldPath, "tboxROldPath");
            this.tboxROldPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxROldPath.Name = "tboxROldPath";
            this.tboxROldPath.ReadOnly = true;
            this.toolTip1.SetToolTip(this.tboxROldPath, resources.GetString("tboxROldPath.ToolTip"));
            this.tboxROldPath.TextChanged += new System.EventHandler(this.ResizeTextBox);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipTitle = "Help:";
            // 
            // Change_Path
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "Change_Path";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.Change_Path_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.tlpFolders.ResumeLayout(false);
            this.tlpFolders.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tlpInfos.ResumeLayout(false);
            this.tlpInfos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.FlowLayoutPanel flpPaths;
        private System.Windows.Forms.TableLayoutPanel tlpInfos;
        private System.Windows.Forms.Label titCPath;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.Label titChooseFolder;
        private System.Windows.Forms.Label titCRPath;
        private System.Windows.Forms.Label labPName;
        private System.Windows.Forms.Label titPlatform;
        private System.Windows.Forms.RichTextBox boxLog;
        private System.Windows.Forms.Button btSimul;
        private System.Windows.Forms.Label lbMore;
        private System.Windows.Forms.Button btResetFactory;
        private System.Windows.Forms.TableLayoutPanel tlpFolders;
        private System.Windows.Forms.Label titCCodes;
        private System.Windows.Forms.Label titGames;
        private System.Windows.Forms.Label titManuals;
        private System.Windows.Forms.Label titImages;
        private System.Windows.Forms.Label titVideos;
        private System.Windows.Forms.Label titMusic;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        protected internal System.Windows.Forms.TextBox tbVideo;
        protected internal System.Windows.Forms.TextBox tbCCodes;
        protected internal System.Windows.Forms.TextBox tbGames;
        protected internal System.Windows.Forms.TextBox tbManual;
        protected internal System.Windows.Forms.TextBox tbImages;
        protected internal System.Windows.Forms.TextBox tbMusic;
        protected internal System.Windows.Forms.TextBox tbMainPath;
        protected internal System.Windows.Forms.TextBox tboxHOldPath;
        protected internal System.Windows.Forms.TextBox tboxROldPath;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}