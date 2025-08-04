using System;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Windows.Forms;

namespace CODE_Fixer // ������Ʈ �̸��� �����ؾ� �մϴ�.
{
    // partial Ű����� �� Ŭ������ Form1.Designer.cs ���ϰ� �������ٴ� ���� �ǹ��մϴ�.
    public partial class Form1 : Form
    {
        // ���� ���� �̸��� ����� �����մϴ�.
        private const string SETTINGS_FILE = "settings.json";

        public Form1()
        {
            // �� �޼���� Form1.Designer.cs�� ���ǵǾ� ������, UI ��Ʈ�ѵ��� �ʱ�ȭ�մϴ�.
            InitializeComponent();
        }

        // ����(JSON)�� �����ϱ� ���� ������ ����(Ŭ����)
        public class Settings
        {
            public string Prompt { get; set; } = string.Empty;
        }

        /// <summary>
        /// ���� ���Ͽ��� ������Ʈ�� �ҷ��ɴϴ�.
        /// </summary>
        private void LoadSettings()
        {
            try
            {
                if (File.Exists(SETTINGS_FILE))
                {
                    string jsonString = File.ReadAllText(SETTINGS_FILE, Encoding.UTF8);
                    if (string.IsNullOrWhiteSpace(jsonString)) return;

                    var settings = JsonSerializer.Deserialize<Settings>(jsonString);
                    promptText.Text = settings?.Prompt ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"���� ���� �ε� ����: {ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ���� ������Ʈ�� ���� ���Ͽ� �����մϴ�.
        /// </summary>
        private void SaveSettings()
        {
            try
            {
                var settings = new Settings
                {
                    Prompt = promptText.Text
                };
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                string jsonString = JsonSerializer.Serialize(settings, options);
                File.WriteAllText(SETTINGS_FILE, jsonString, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"���� ���� ���� ����: {ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 'Ŭ�����忡 ����' ��ư�� Ŭ������ �� ����Ǵ� �޼����Դϴ�.
        private void copyButton_Click(object sender, EventArgs e)
        {
            string originalCode = originalCodeText.Text;
            string modifiedCode = modifiedCodeText.Text;
            string prompt = promptText.Text;

            if (string.IsNullOrWhiteSpace(prompt))
            {
                MessageBox.Show("������Ʈ�� �Է����ּ���.", "���", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(originalCode))
            {
                MessageBox.Show("���� �ڵ带 �Է����ּ���.", "���", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string outputText = $@"{prompt}

[�����ڵ�]
{originalCode}
[�����ڵ�]
{modifiedCode}";

                Clipboard.SetText(outputText);
                MessageBox.Show("��û�Ͻ� ������ Ŭ�����忡 ����Ǿ����ϴ�.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SaveSettings(); // ���� �� ������Ʈ ����
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ó�� �� ���� �߻�: {ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// '�����' ��ư Ŭ�� �� ���� �� ���� �ڵ� ������ �����մϴ�.
        /// </summary>
        private void clearButton_Click(object sender, EventArgs e)
        {
            originalCodeText.Clear();
            modifiedCodeText.Clear();
        }

        // â�� ������ ������ ����Ǵ� �޼����Դϴ�.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings(); // â�� ������ ���� ���� ����
        }

        // ���� ó�� ȭ�鿡 ��Ÿ�� �� ����Ǵ� �޼����Դϴ�.
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings(); // ���� ó�� ���� �� ���� �ҷ�����
        }

        /// <summary>
        /// ��� ���� ��ư Ŭ�� �� ������Ʈ�� �����ϴ� ���� �̺�Ʈ �ڵ鷯�Դϴ�.
        /// </summary>
        private void languageButton_Click(object sender, EventArgs e)
        {
            // Ŭ���� ��ư�� �����ɴϴ�.
            Button? clickedButton = sender as Button;
            if (clickedButton != null)
            {
                string language = clickedButton.Tag?.ToString() ?? "";

                if (!string.IsNullOrEmpty(language))
                {
                    // ��ư�� Tag �Ӽ��� ����� ��� �̸��� ����Ͽ� ������Ʈ �ؽ�Ʈ�� �����մϴ�.
                    promptText.Text = $"[�����ڵ�]�� [�����ڵ�]�� ������Ѽ� �������� ��ü�ڵ� �������. �ʰ� �ڵ带 �ؼ��ؼ� �߰��ϰų� �׷��� ���� ���������� �� �°� �����ڵ带 �����ڵ忡 �� ��������ָ� �ȴ�. �̰��� {language}�̴�. �׸��� ��� �� ��� �����ߴ����� �˷���, �ڵ������� ��������";
                }
            }
        }
    }
}