using System;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices; // [�����ڵ�] �߰�

namespace CODE_Fixer // ������Ʈ �̸��� �����ؾ� �մϴ�.
{
    // partial Ű����� �� Ŭ������ Form1.Designer.cs ���ϰ� �������ٴ� ���� �ǹ��մϴ�.
    public partial class Form1 : Form
    {
        // Windows API �Լ��� �߰� [�����ڵ�]
        [DllImport("user32.dll")]
        static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("user32.dll")]
        static extern bool CloseClipboard();

        [DllImport("user32.dll")]
        static extern bool EmptyClipboard();

        [DllImport("user32.dll")]
        static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

        [DllImport("kernel32.dll")]
        static extern IntPtr GlobalAlloc(uint uFlags, UIntPtr dwBytes);

        [DllImport("kernel32.dll")]
        static extern IntPtr GlobalLock(IntPtr hMem);

        [DllImport("kernel32.dll")]
        static extern bool GlobalUnlock(IntPtr hMem);

        [DllImport("kernel32.dll")]
        static extern UIntPtr GlobalSize(IntPtr hMem);

        private const uint CF_UNICODETEXT = 13;
        private const uint GMEM_MOVEABLE = 0x0002;

        // ���� ���� �̸��� ����� �����մϴ�.
        private const string SETTINGS_FILE = "settings.json";

        // prompts ���� �߰�
        private Dictionary<string, string> prompts = new Dictionary<string, string>();

        public Form1()
        {
            // �� �޼���� Form1.Designer.cs�� ���ǵǾ� ������, UI ��Ʈ�ѵ��� �ʱ�ȭ�մϴ�.
            InitializeComponent();
        }

        // ����(JSON)�� �����ϱ� ���� ������ ����(Ŭ����)
        public class AppSettings
        {
            public Dictionary<string, string> Prompts { get; set; } = new Dictionary<string, string>();
            public bool AlwaysOnTop { get; set; }
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
                    string json = File.ReadAllText(SETTINGS_FILE);
                    var settings = JsonSerializer.Deserialize<AppSettings>(json);

                    if (settings != null)
                    {
                        prompts = settings.Prompts ?? new Dictionary<string, string>();
                        alwaysOnTopCheckBox.Checked = settings.AlwaysOnTop;
                        this.TopMost = settings.AlwaysOnTop; // �� �ε� �� '�׻� ����' ���� ����
                    }
                }
                else
                {
                    // �⺻ ������Ʈ ���� (MQH, MQ5 �߰�)
                    prompts = new Dictionary<string, string>
                    {
                        ["C#"] = "[�����ڵ�]�� [�����ڵ�]�� ������Ѽ� �������� ��ü�ڵ� �������. �ʰ� �ڵ带 �ؼ��ؼ� �߰��ϰų� �׷��� ���� ���������� �� �°� �����ڵ带 �����ڵ忡 �� ��������ָ� �ȴ�. �̰��� C#�̴�. �׸��� ��� �� ��� �����ߴ����� �˷���, �ڵ������� ��������",
                        ["XML"] = "[�����ڵ�]�� [�����ڵ�]�� ������Ѽ� �������� ��ü�ڵ� �������. �ʰ� �ڵ带 �ؼ��ؼ� �߰��ϰų� �׷��� ���� ���������� �� �°� �����ڵ带 �����ڵ忡 �� ��������ָ� �ȴ�. �̰��� XML�̴�. �׸��� ��� �� ��� �����ߴ����� �˷���, �ڵ������� ��������",
                        ["Python"] = "[�����ڵ�]�� [�����ڵ�]�� ������Ѽ� �������� ��ü�ڵ� �������. �ʰ� �ڵ带 �ؼ��ؼ� �߰��ϰų� �׷��� ���� ���������� �� �°� �����ڵ带 �����ڵ忡 �� ��������ָ� �ȴ�. �̰��� Python�̴�. �׸��� ��� �� ��� �����ߴ����� �˷���, �ڵ������� ��������",
                        ["CSS"] = "[�����ڵ�]�� [�����ڵ�]�� ������Ѽ� �������� ��ü�ڵ� �������. �ʰ� �ڵ带 �ؼ��ؼ� �߰��ϰų� �׷��� ���� ���������� �� �°� �����ڵ带 �����ڵ忡 �� ��������ָ� �ȴ�. �̰��� CSS�̴�. �׸��� ��� �� ��� �����ߴ����� �˷���, �ڵ������� ��������",
                        ["HTML5"] = "[�����ڵ�]�� [�����ڵ�]�� ������Ѽ� �������� ��ü�ڵ� �������. �ʰ� �ڵ带 �ؼ��ؼ� �߰��ϰų� �׷��� ���� ���������� �� �°� �����ڵ带 �����ڵ忡 �� ��������ָ� �ȴ�. �̰��� HTML5�̴�. �׸��� ��� �� ��� �����ߴ����� �˷���, �ڵ������� ��������",
                        ["JavaScript"] = "[�����ڵ�]�� [�����ڵ�]�� ������Ѽ� �������� ��ü�ڵ� �������. �ʰ� �ڵ带 �ؼ��ؼ� �߰��ϰų� �׷��� ���� ���������� �� �°� �����ڵ带 �����ڵ忡 �� ��������ָ� �ȴ�. �̰��� JavaScript�̴�. �׸��� ��� �� ��� �����ߴ����� �˷���, �ڵ������� ��������",
                        ["MQL4"] = "[�����ڵ�]�� [�����ڵ�]�� ������Ѽ� �������� ��ü�ڵ� �������. �ʰ� �ڵ带 �ؼ��ؼ� �߰��ϰų� �׷��� ���� ���������� �� �°� �����ڵ带 �����ڵ忡 �� ��������ָ� �ȴ�. �̰��� MQL4�̴�. �׸��� ��� �� ��� �����ߴ����� �˷���, �ڵ������� ��������",
                        ["MQH"] = "[�����ڵ�]�� [�����ڵ�]�� ������Ѽ� �������� ��ü�ڵ� �������. �ʰ� �ڵ带 �ؼ��ؼ� �߰��ϰų� �׷��� ���� ���������� �� �°� �����ڵ带 �����ڵ忡 �� ��������ָ� �ȴ�. �̰��� MQH�̴�. �׸��� ��� �� ��� �����ߴ����� �˷���, �ڵ������� ��������",
                        ["MQ5"] = "[�����ڵ�]�� [�����ڵ�]�� ������Ѽ� �������� ��ü�ڵ� �������. �ʰ� �ڵ带 �ؼ��ؼ� �߰��ϰų� �׷��� ���� ���������� �� �°� �����ڵ带 �����ڵ忡 �� ��������ָ� �ȴ�. �̰��� MQ5�̴�. �׸��� ��� �� ��� �����ߴ����� �˷���, �ڵ������� ��������"
                    };
                    SaveSettings();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ �ҷ����� �� ������ �߻��߽��ϴ�: {ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ���� ������Ʈ�� ���� ���Ͽ� �����մϴ�.
        /// </summary>
        private void SaveSettings()
        {
            try
            {
                var settings = new AppSettings
                {
                    Prompts = this.prompts,
                    AlwaysOnTop = this.alwaysOnTopCheckBox.Checked
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

        /// <summary>
        /// ������ Ŭ�����带 �����ϰ� �ؽ�Ʈ�� �����ϴ� �޼��� [�����ڵ�]
        /// </summary>
        /// <param name="text">������ �ؽ�Ʈ</param>
        /// <returns>���� ���� ����</returns>
        private bool ForceSetClipboard(string text)
        {
            IntPtr hGlobal = IntPtr.Zero;

            try
            {
                // 1�ܰ�: Ŭ������ ���� ���� �� ����
                for (int attempt = 0; attempt < 5; attempt++)
                {
                    try
                    {
                        // ���� Ŭ������ ���� ���� ����
                        CloseClipboard();
                        Thread.Sleep(50);

                        // Ŭ������ ���� �õ�
                        if (OpenClipboard(this.Handle))
                        {
                            break;
                        }

                        if (attempt == 4)
                        {
                            return false; // ������ �õ��� ����
                        }

                        Thread.Sleep(100 * (attempt + 1)); // ������ ���
                    }
                    catch
                    {
                        Thread.Sleep(100);
                    }
                }

                // 2�ܰ�: Ŭ������ ����
                if (!EmptyClipboard())
                {
                    CloseClipboard();
                    return false;
                }

                // 3�ܰ�: �޸� �Ҵ� �� �ؽ�Ʈ ����
                byte[] bytes = Encoding.Unicode.GetBytes(text + "\0"); // null ���� ���� �߰�
                hGlobal = GlobalAlloc(GMEM_MOVEABLE, (UIntPtr)bytes.Length);

                if (hGlobal == IntPtr.Zero)
                {
                    CloseClipboard();
                    return false;
                }

                IntPtr pGlobal = GlobalLock(hGlobal);
                if (pGlobal == IntPtr.Zero)
                {
                    CloseClipboard();
                    return false;
                }

                Marshal.Copy(bytes, 0, pGlobal, bytes.Length);
                GlobalUnlock(hGlobal);

                // 4�ܰ�: Ŭ�����忡 ������ ����
                IntPtr result = SetClipboardData(CF_UNICODETEXT, hGlobal);
                if (result == IntPtr.Zero)
                {
                    CloseClipboard();
                    return false;
                }

                // ���� �� hGlobal�� �ý����� �����ϹǷ� �������� ����
                hGlobal = IntPtr.Zero;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                // Ŭ������ �ݱ�
                CloseClipboard();

                // ���� �ÿ��� �޸� ����
                if (hGlobal != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(hGlobal);
                }
            }
        }

        // 'Ŭ�����忡 ����' ��ư�� Ŭ������ �� ����Ǵ� �޼����Դϴ�. [�����ڵ�]
        private void btnCopyToClipboard_Click(object sender, EventArgs e)
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

            btnCopyToClipboard.Enabled = false;
            btnCopyToClipboard.Text = "���� ���� ��...";

            try
            {
                string outputText = $@"{prompt}

[�����ڵ�]
{originalCode}
[�����ڵ�]
{modifiedCode}";

                // ���� Ŭ������ ���� �õ�
                bool success = ForceSetClipboard(outputText);

                if (success)
                {
                    MessageBox.Show("Ŭ������ ���� ���簡 �Ϸ�Ǿ����ϴ�!", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SaveSettings();
                }
                else
                {
                    // ������ ����: .NET ������� ��õ�
                    try
                    {
                        Clipboard.Clear();
                        Thread.Sleep(200);
                        Clipboard.SetText(outputText);
                        MessageBox.Show("Ŭ������ ���簡 �Ϸ�Ǿ����ϴ�.", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SaveSettings();
                    }
                    catch
                    {
                        MessageBox.Show("Ŭ������ ���翡 �����߽��ϴ�.\n�ý����� ������ϰų� �ٸ� ���α׷��� ���� �� �ٽ� �õ����ּ���.", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"���� �߻�: {ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnCopyToClipboard.Enabled = true;
                btnCopyToClipboard.Text = "Ŭ�����忡 ����";
            }
        }

        /// <summary>
        /// '�����' ��ư Ŭ�� �� ���� �� ���� �ڵ� ������ �����մϴ�.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
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

        // [�����ڵ�] : XML ��ư �̺�Ʈ �ڵ鷯 �߰�
        private void btnXML_Click(object sender, EventArgs e)
        {
            string xmlPrompt = "[�����ڵ�]�� [�����ڵ�]�� ������Ѽ� �������� ��ü�ڵ� �������. " +
                                 "�ʰ� �ڵ带 �ؼ��ؼ� �߰��ϰų� �׷��� ���� ���������� �� �°� �����ڵ带 " +
                                 "�����ڵ忡 �� ��������ָ� �ȴ�. �̰��� XML�̴�. " +
                                 "�׸��� ��� �� ��� �����ߴ����� �˷���, �ڵ������� ��������";

            UpdatePromptText(xmlPrompt);
        }

        // [�����ڵ�] : UpdatePromptText �޼��尡 �ʿ��ϴٸ� �Ʒ��� ���� ����
        private void UpdatePromptText(string text)
        {
            promptText.Text = text;
        }

        /// <summary>
        /// '�׻� ����' üũ�ڽ� ���� ���� �� ���� TopMost �Ӽ��� �����մϴ�.
        /// </summary>
        private void alwaysOnTopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = alwaysOnTopCheckBox.Checked;
        }
    }
}
