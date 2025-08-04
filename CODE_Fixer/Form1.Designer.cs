namespace CODE_Fixer // 프로젝트 이름과 동일해야 합니다.
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.originalCodeLabel = new Label();
            this.originalCodeText = new TextBox();
            this.modifiedCodeLabel = new Label();
            this.modifiedCodeText = new TextBox();
            this.promptLabel = new Label();
            this.promptText = new TextBox();
            this.languageButtonsPanel = new FlowLayoutPanel();
            this.csharpButton = new Button();
            this.pythonButton = new Button();
            this.cssButton = new Button();
            this.html5Button = new Button();
            this.jsButton = new Button();
            this.mql5Button = new Button();
            this.xmlButton = new Button();
            this.btnCopyToClipboard = new Button();
            this.btnClear = new Button();

            this.languageButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            //
            // originalCodeLabel
            //
            this.originalCodeLabel.AutoSize = true;
            this.originalCodeLabel.Dock = DockStyle.Top;
            this.originalCodeLabel.Location = new System.Drawing.Point(10, 12);
            this.originalCodeLabel.Name = "originalCodeLabel";
            this.originalCodeLabel.Padding = new Padding(0, 0, 0, 4);
            this.originalCodeLabel.Size = new System.Drawing.Size(62, 19);
            this.originalCodeLabel.TabIndex = 0;
            this.originalCodeLabel.Text = "기존 코드:";
            //
            // originalCodeText
            //
            this.originalCodeText.Dock = DockStyle.Top;
            this.originalCodeText.Location = new System.Drawing.Point(10, 31);
            this.originalCodeText.Margin = new Padding(3, 4, 3, 4);
            this.originalCodeText.MaxLength = 0;
            this.originalCodeText.Multiline = true;
            this.originalCodeText.Name = "originalCodeText";
            this.originalCodeText.ScrollBars = ScrollBars.Vertical;
            this.originalCodeText.Size = new System.Drawing.Size(564, 200);
            this.originalCodeText.TabIndex = 1;
            //
            // modifiedCodeLabel
            //
            this.modifiedCodeLabel.AutoSize = true;
            this.modifiedCodeLabel.Dock = DockStyle.Top;
            this.modifiedCodeLabel.Location = new System.Drawing.Point(10, 231);
            this.modifiedCodeLabel.Name = "modifiedCodeLabel";
            this.modifiedCodeLabel.Padding = new Padding(0, 12, 0, 4);
            this.modifiedCodeLabel.Size = new System.Drawing.Size(62, 31);
            this.modifiedCodeLabel.TabIndex = 2;
            this.modifiedCodeLabel.Text = "수정 코드:";
            //
            // modifiedCodeText
            //
            this.modifiedCodeText.Dock = DockStyle.Top;
            this.modifiedCodeText.Location = new System.Drawing.Point(10, 262);
            this.modifiedCodeText.Margin = new Padding(3, 4, 3, 4);
            this.modifiedCodeText.MaxLength = 0;
            this.modifiedCodeText.Multiline = true;
            this.modifiedCodeText.Name = "modifiedCodeText";
            this.modifiedCodeText.ScrollBars = ScrollBars.Vertical;
            this.modifiedCodeText.Size = new System.Drawing.Size(564, 200);
            this.modifiedCodeText.TabIndex = 3;
            //
            // promptLabel
            //
            this.promptLabel.AutoSize = true;
            this.promptLabel.Dock = DockStyle.Top;
            this.promptLabel.Location = new System.Drawing.Point(10, 462);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Padding = new Padding(0, 12, 0, 4);
            this.promptLabel.Size = new System.Drawing.Size(238, 31);
            this.promptLabel.TabIndex = 4;
            this.promptLabel.Text = "프롬프트 (클립보드 최상단에 포함될 내용):";
            //
            // languageButtonsPanel
            //
            this.languageButtonsPanel.AutoSize = true;
            this.languageButtonsPanel.Controls.Add(this.csharpButton);
            this.languageButtonsPanel.Controls.Add(this.xmlButton);
            this.languageButtonsPanel.Controls.Add(this.pythonButton);
            this.languageButtonsPanel.Controls.Add(this.cssButton);
            this.languageButtonsPanel.Controls.Add(this.html5Button);
            this.languageButtonsPanel.Controls.Add(this.jsButton);
            this.languageButtonsPanel.Controls.Add(this.mql5Button);
            this.languageButtonsPanel.Dock = DockStyle.Top;
            this.languageButtonsPanel.Location = new System.Drawing.Point(10, 493);
            this.languageButtonsPanel.Name = "languageButtonsPanel";
            this.languageButtonsPanel.Padding = new Padding(0, 0, 0, 5);
            this.languageButtonsPanel.Size = new System.Drawing.Size(564, 41);
            this.languageButtonsPanel.TabIndex = 8;
            //
            // csharpButton
            //
            this.csharpButton.Location = new System.Drawing.Point(3, 3);
            this.csharpButton.Name = "csharpButton";
            this.csharpButton.Size = new System.Drawing.Size(75, 30);
            this.csharpButton.TabIndex = 0;
            this.csharpButton.Tag = "C#";
            this.csharpButton.Text = "C#";
            this.csharpButton.UseVisualStyleBackColor = true;
            this.csharpButton.Click += this.languageButton_Click;
            //
            // xmlButton
            //
            this.xmlButton.Location = new System.Drawing.Point(84, 3);
            this.xmlButton.Name = "xmlButton";
            this.xmlButton.Size = new System.Drawing.Size(75, 30);
            this.xmlButton.TabIndex = 6;
            this.xmlButton.Tag = "XML";
            this.xmlButton.Text = "XML";
            this.xmlButton.UseVisualStyleBackColor = true;
            this.xmlButton.Click += this.languageButton_Click;
            //
            // pythonButton
            //
            this.pythonButton.Location = new System.Drawing.Point(165, 3);
            this.pythonButton.Name = "pythonButton";
            this.pythonButton.Size = new System.Drawing.Size(75, 30);
            this.pythonButton.TabIndex = 1;
            this.pythonButton.Tag = "Python";
            this.pythonButton.Text = "Python";
            this.pythonButton.UseVisualStyleBackColor = true;
            this.pythonButton.Click += this.languageButton_Click;
            //
            // cssButton
            //
            this.cssButton.Location = new System.Drawing.Point(246, 3);
            this.cssButton.Name = "cssButton";
            this.cssButton.Size = new System.Drawing.Size(75, 30);
            this.cssButton.TabIndex = 2;
            this.cssButton.Tag = "CSS";
            this.cssButton.Text = "CSS";
            this.cssButton.UseVisualStyleBackColor = true;
            this.cssButton.Click += this.languageButton_Click;
            //
            // html5Button
            //
            this.html5Button.Location = new System.Drawing.Point(327, 3);
            this.html5Button.Name = "html5Button";
            this.html5Button.Size = new System.Drawing.Size(75, 30);
            this.html5Button.TabIndex = 3;
            this.html5Button.Tag = "HTML5";
            this.html5Button.Text = "HTML5";
            this.html5Button.UseVisualStyleBackColor = true;
            this.html5Button.Click += this.languageButton_Click;
            //
            // jsButton
            //
            this.jsButton.Location = new System.Drawing.Point(408, 3);
            this.jsButton.Name = "jsButton";
            this.jsButton.Size = new System.Drawing.Size(75, 30);
            this.jsButton.TabIndex = 4;
            this.jsButton.Tag = "JavaScript";
            this.jsButton.Text = "JS";
            this.jsButton.UseVisualStyleBackColor = true;
            this.jsButton.Click += this.languageButton_Click;
            //
            // mql5Button
            //
            this.mql5Button.Location = new System.Drawing.Point(489, 3);
            this.mql5Button.Name = "mql5Button";
            this.mql5Button.Size = new System.Drawing.Size(75, 30);
            this.mql5Button.TabIndex = 5;
            this.mql5Button.Tag = "MQL5";
            this.mql5Button.Text = "MQL5";
            this.mql5Button.UseVisualStyleBackColor = true;
            this.mql5Button.Click += this.languageButton_Click;
            //
            // promptText
            //
            this.promptText.Location = new System.Drawing.Point(10, 534);
            this.promptText.Margin = new Padding(3, 4, 3, 4);
            this.promptText.Multiline = true;
            this.promptText.Name = "promptText";
            this.promptText.ScrollBars = ScrollBars.Vertical;
            this.promptText.Size = new System.Drawing.Size(564, 120);
            this.promptText.TabIndex = 5;
            //
            // btnCopyToClipboard
            //
            this.btnCopyToClipboard.Location = new System.Drawing.Point(12, 670);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(280, 40);
            this.btnCopyToClipboard.TabIndex = 9;
            this.btnCopyToClipboard.Text = "클립보드에 복사";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(298, 670);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(280, 40);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "지우기";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 730);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCopyToClipboard);
            this.Controls.Add(this.promptText);
            this.Controls.Add(this.languageButtonsPanel);
            this.Controls.Add(this.promptLabel);
            this.Controls.Add(this.modifiedCodeText);
            this.Controls.Add(this.modifiedCodeLabel);
            this.Controls.Add(this.originalCodeText);
            this.Controls.Add(this.originalCodeLabel);
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.Margin = new Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(400, 615);
            this.Name = "Form1";
            this.Padding = new Padding(10, 12, 10, 12);
            this.Text = "코드 형식 생성 및 복사 도구";
            this.FormClosing += this.Form1_FormClosing;
            this.Load += this.Form1_Load;
            this.languageButtonsPanel.ResumeLayout(false);
            this.languageButtonsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label originalCodeLabel;
        private System.Windows.Forms.TextBox originalCodeText;
        private System.Windows.Forms.Label modifiedCodeLabel;
        private System.Windows.Forms.TextBox modifiedCodeText;
        private System.Windows.Forms.Label promptLabel;
        private System.Windows.Forms.TextBox promptText;
        private FlowLayoutPanel languageButtonsPanel;
        private Button csharpButton;
        private Button pythonButton;
        private Button cssButton;
        private Button html5Button;
        private Button jsButton;
        private Button mql5Button;
        private Button xmlButton;
        private Button btnCopyToClipboard;
        private Button btnClear;
    }
}
