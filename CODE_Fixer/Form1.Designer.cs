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
            this.xmlButton = new Button();
            this.pythonButton = new Button();
            this.cssButton = new Button();
            this.html5Button = new Button();
            this.jsButton = new Button();
            this.razorButton = new Button();
            this.mql4Button = new Button();
            this.mqhButton = new Button();
            this.mq5Button = new Button();
            this.btnCopyToClipboard = new Button();
            this.btnClear = new Button();
            this.alwaysOnTopCheckBox = new CheckBox();
            this.languageButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // originalCodeLabel
            // 
            this.originalCodeLabel.AutoSize = true;
            this.originalCodeLabel.Dock = DockStyle.Top;
            this.originalCodeLabel.Location = new Point(10, 12);
            this.originalCodeLabel.Name = "originalCodeLabel";
            this.originalCodeLabel.Padding = new Padding(0, 0, 0, 4);
            this.originalCodeLabel.Size = new Size(62, 19);
            this.originalCodeLabel.TabIndex = 0;
            this.originalCodeLabel.Text = "기존 코드:";
            // 
            // originalCodeText
            // 
            this.originalCodeText.Dock = DockStyle.Top;
            this.originalCodeText.Location = new Point(10, 31);
            this.originalCodeText.Margin = new Padding(3, 4, 3, 4);
            this.originalCodeText.MaxLength = 0;
            this.originalCodeText.Multiline = true;
            this.originalCodeText.Name = "originalCodeText";
            this.originalCodeText.ScrollBars = ScrollBars.Vertical;
            this.originalCodeText.Size = new Size(564, 200);
            this.originalCodeText.TabIndex = 1;
            // 
            // modifiedCodeLabel
            // 
            this.modifiedCodeLabel.AutoSize = true;
            this.modifiedCodeLabel.Dock = DockStyle.Top;
            this.modifiedCodeLabel.Location = new Point(10, 231);
            this.modifiedCodeLabel.Name = "modifiedCodeLabel";
            this.modifiedCodeLabel.Padding = new Padding(0, 12, 0, 4);
            this.modifiedCodeLabel.Size = new Size(62, 31);
            this.modifiedCodeLabel.TabIndex = 2;
            this.modifiedCodeLabel.Text = "수정 코드:";
            // 
            // modifiedCodeText
            // 
            this.modifiedCodeText.Dock = DockStyle.Top;
            this.modifiedCodeText.Location = new Point(10, 262);
            this.modifiedCodeText.Margin = new Padding(3, 4, 3, 4);
            this.modifiedCodeText.MaxLength = 0;
            this.modifiedCodeText.Multiline = true;
            this.modifiedCodeText.Name = "modifiedCodeText";
            this.modifiedCodeText.ScrollBars = ScrollBars.Vertical;
            this.modifiedCodeText.Size = new Size(564, 200);
            this.modifiedCodeText.TabIndex = 3;
            // 
            // promptLabel
            // 
            this.promptLabel.AutoSize = true;
            this.promptLabel.Dock = DockStyle.Top;
            this.promptLabel.Location = new Point(10, 462);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Padding = new Padding(0, 12, 0, 4);
            this.promptLabel.Size = new Size(238, 31);
            this.promptLabel.TabIndex = 4;
            this.promptLabel.Text = "프롬프트 (클립보드 최상단에 포함될 내용):";
            // 
            // promptText
            // 
            this.promptText.Location = new Point(10, 570);
            this.promptText.Margin = new Padding(3, 4, 3, 4);
            this.promptText.Multiline = true;
            this.promptText.Name = "promptText";
            this.promptText.ScrollBars = ScrollBars.Vertical;
            this.promptText.Size = new Size(564, 120);
            this.promptText.TabIndex = 5;
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
            this.languageButtonsPanel.Controls.Add(this.razorButton);
            this.languageButtonsPanel.Controls.Add(this.mql4Button);
            this.languageButtonsPanel.Controls.Add(this.mqhButton);
            this.languageButtonsPanel.Controls.Add(this.mq5Button);
            this.languageButtonsPanel.Dock = DockStyle.Top;
            this.languageButtonsPanel.Location = new Point(10, 493);
            this.languageButtonsPanel.Name = "languageButtonsPanel";
            this.languageButtonsPanel.Padding = new Padding(0, 0, 0, 5);
            this.languageButtonsPanel.Size = new Size(564, 77);
            this.languageButtonsPanel.TabIndex = 8;
            // 
            // csharpButton
            // 
            this.csharpButton.Location = new Point(3, 3);
            this.csharpButton.Name = "csharpButton";
            this.csharpButton.Size = new Size(75, 30);
            this.csharpButton.TabIndex = 0;
            this.csharpButton.Tag = "C#";
            this.csharpButton.Text = "C#";
            this.csharpButton.UseVisualStyleBackColor = true;
            this.csharpButton.Click += this.languageButton_Click;
            // 
            // xmlButton
            // 
            this.xmlButton.Location = new Point(84, 3);
            this.xmlButton.Name = "xmlButton";
            this.xmlButton.Size = new Size(75, 30);
            this.xmlButton.TabIndex = 6;
            this.xmlButton.Tag = "XML";
            this.xmlButton.Text = "XML";
            this.xmlButton.UseVisualStyleBackColor = true;
            this.xmlButton.Click += this.languageButton_Click;
            // 
            // pythonButton
            // 
            this.pythonButton.Location = new Point(165, 3);
            this.pythonButton.Name = "pythonButton";
            this.pythonButton.Size = new Size(75, 30);
            this.pythonButton.TabIndex = 1;
            this.pythonButton.Tag = "Python";
            this.pythonButton.Text = "Python";
            this.pythonButton.UseVisualStyleBackColor = true;
            this.pythonButton.Click += this.languageButton_Click;
            // 
            // cssButton
            // 
            this.cssButton.Location = new Point(246, 3);
            this.cssButton.Name = "cssButton";
            this.cssButton.Size = new Size(75, 30);
            this.cssButton.TabIndex = 2;
            this.cssButton.Tag = "CSS";
            this.cssButton.Text = "CSS";
            this.cssButton.UseVisualStyleBackColor = true;
            this.cssButton.Click += this.languageButton_Click;
            // 
            // html5Button
            // 
            this.html5Button.Location = new Point(327, 3);
            this.html5Button.Name = "html5Button";
            this.html5Button.Size = new Size(75, 30);
            this.html5Button.TabIndex = 3;
            this.html5Button.Tag = "HTML5";
            this.html5Button.Text = "HTML5";
            this.html5Button.UseVisualStyleBackColor = true;
            this.html5Button.Click += this.languageButton_Click;
            // 
            // jsButton
            // 
            this.jsButton.Location = new Point(408, 3);
            this.jsButton.Name = "jsButton";
            this.jsButton.Size = new Size(75, 30);
            this.jsButton.TabIndex = 4;
            this.jsButton.Tag = "JavaScript";
            this.jsButton.Text = "JS";
            this.jsButton.UseVisualStyleBackColor = true;
            this.jsButton.Click += this.languageButton_Click;
            // 
            // razorButton
            // 
            this.razorButton.Location = new Point(3, 39);
            this.razorButton.Name = "razorButton";
            this.razorButton.Size = new Size(75, 30);
            this.razorButton.TabIndex = 9;
            this.razorButton.Tag = "Razor";
            this.razorButton.Text = "Razor";
            this.razorButton.UseVisualStyleBackColor = true;
            this.razorButton.Click += this.languageButton_Click;
            // 
            // mql4Button
            // 
            this.mql4Button.Location = new Point(84, 39);
            this.mql4Button.Name = "mql4Button";
            this.mql4Button.Size = new Size(75, 30);
            this.mql4Button.TabIndex = 5;
            this.mql4Button.Tag = "MQL4";
            this.mql4Button.Text = "MQL4";
            this.mql4Button.UseVisualStyleBackColor = true;
            this.mql4Button.Click += this.languageButton_Click;
            // 
            // mqhButton
            // 
            this.mqhButton.Location = new Point(165, 39);
            this.mqhButton.Name = "mqhButton";
            this.mqhButton.Size = new Size(75, 30);
            this.mqhButton.TabIndex = 7;
            this.mqhButton.Tag = "MQH";
            this.mqhButton.Text = "MQH";
            this.mqhButton.UseVisualStyleBackColor = true;
            this.mqhButton.Click += this.languageButton_Click;
            // 
            // mq5Button
            // 
            this.mq5Button.Location = new Point(246, 39);
            this.mq5Button.Name = "mq5Button";
            this.mq5Button.Size = new Size(75, 30);
            this.mq5Button.TabIndex = 8;
            this.mq5Button.Tag = "MQ5";
            this.mq5Button.Text = "MQ5";
            this.mq5Button.UseVisualStyleBackColor = true;
            this.mq5Button.Click += this.languageButton_Click;
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Location = new Point(12, 706);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new Size(245, 40);
            this.btnCopyToClipboard.TabIndex = 9;
            this.btnCopyToClipboard.Text = "클립보드에 복사";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += this.btnCopyToClipboard_Click;
            // 
            // btnClear
            // 
            this.btnClear.Location = new Point(263, 706);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(160, 40);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "지우기";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += this.btnClear_Click;
            // 
            // alwaysOnTopCheckBox
            // 
            this.alwaysOnTopCheckBox.AutoSize = true;
            this.alwaysOnTopCheckBox.Location = new Point(438, 716);
            this.alwaysOnTopCheckBox.Name = "alwaysOnTopCheckBox";
            this.alwaysOnTopCheckBox.Size = new Size(78, 19);
            this.alwaysOnTopCheckBox.TabIndex = 11;
            this.alwaysOnTopCheckBox.Text = "항상 위에";
            this.alwaysOnTopCheckBox.UseVisualStyleBackColor = true;
            this.alwaysOnTopCheckBox.CheckedChanged += this.alwaysOnTopCheckBox_CheckedChanged;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(584, 766);
            this.Controls.Add(this.alwaysOnTopCheckBox);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCopyToClipboard);
            this.Controls.Add(this.promptText);
            this.Controls.Add(this.languageButtonsPanel);
            this.Controls.Add(this.promptLabel);
            this.Controls.Add(this.modifiedCodeText);
            this.Controls.Add(this.modifiedCodeLabel);
            this.Controls.Add(this.originalCodeText);
            this.Controls.Add(this.originalCodeLabel);
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.Margin = new Padding(3, 4, 3, 4);
            this.MinimumSize = new Size(600, 805);
            this.Name = "Form1";
            this.Padding = new Padding(10, 12, 10, 12);
            this.Text = "코드 형식 생성 및 복사 도구";
            this.FormClosing += this.Form1_FormClosing;
            this.Load += this.Form1_Load;
            this.languageButtonsPanel.ResumeLayout(false);
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
        private Button mql4Button;
        private Button mqhButton;
        private Button mq5Button;
        private Button xmlButton;
        private Button razorButton; // [수정코드] Razor 버튼 변수 선언
        private Button btnCopyToClipboard;
        private Button btnClear;
        private CheckBox alwaysOnTopCheckBox;
    }
}