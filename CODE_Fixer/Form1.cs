using System;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices; // [수정코드] 추가

namespace CODE_Fixer // 프로젝트 이름과 동일해야 합니다.
{
    // partial 키워드는 이 클래스가 Form1.Designer.cs 파일과 합쳐진다는 것을 의미합니다.
    public partial class Form1 : Form
    {
        // Windows API 함수들 추가 [수정코드]
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

        // 설정 파일 이름을 상수로 정의합니다.
        private const string SETTINGS_FILE = "settings.json";

        // prompts 사전 추가
        private Dictionary<string, string> prompts = new Dictionary<string, string>();

        public Form1()
        {
            // 이 메서드는 Form1.Designer.cs에 정의되어 있으며, UI 컨트롤들을 초기화합니다.
            InitializeComponent();
        }

        // 설정(JSON)을 저장하기 위한 데이터 구조(클래스)
        public class AppSettings
        {
            public Dictionary<string, string> Prompts { get; set; } = new Dictionary<string, string>();
            public bool AlwaysOnTop { get; set; }
        }

        /// <summary>
        /// 설정 파일에서 프롬프트를 불러옵니다.
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
                        this.TopMost = settings.AlwaysOnTop; // 폼 로드 시 '항상 위에' 상태 적용
                    }
                }
                else
                {
                    // 기본 프롬프트 설정 (MQH, MQ5 추가)
                    prompts = new Dictionary<string, string>
                    {
                        ["C#"] = "[기존코드]에 [수정코드]를 적용시켜서 생략없이 전체코드 출력해줘. 너가 코드를 해석해서 추가하거나 그러지 말고 문법적으로 잘 맞게 수정코드를 기존코드에 잘 적용시켜주면 된다. 이것은 C#이다. 그리고 출력 후 어디를 수정했는지도 알려줘, 코드블록으로 제공해줘",
                        ["XML"] = "[기존코드]에 [수정코드]를 적용시켜서 생략없이 전체코드 출력해줘. 너가 코드를 해석해서 추가하거나 그러지 말고 문법적으로 잘 맞게 수정코드를 기존코드에 잘 적용시켜주면 된다. 이것은 XML이다. 그리고 출력 후 어디를 수정했는지도 알려줘, 코드블록으로 제공해줘",
                        ["Python"] = "[기존코드]에 [수정코드]를 적용시켜서 생략없이 전체코드 출력해줘. 너가 코드를 해석해서 추가하거나 그러지 말고 문법적으로 잘 맞게 수정코드를 기존코드에 잘 적용시켜주면 된다. 이것은 Python이다. 그리고 출력 후 어디를 수정했는지도 알려줘, 코드블록으로 제공해줘",
                        ["CSS"] = "[기존코드]에 [수정코드]를 적용시켜서 생략없이 전체코드 출력해줘. 너가 코드를 해석해서 추가하거나 그러지 말고 문법적으로 잘 맞게 수정코드를 기존코드에 잘 적용시켜주면 된다. 이것은 CSS이다. 그리고 출력 후 어디를 수정했는지도 알려줘, 코드블록으로 제공해줘",
                        ["HTML5"] = "[기존코드]에 [수정코드]를 적용시켜서 생략없이 전체코드 출력해줘. 너가 코드를 해석해서 추가하거나 그러지 말고 문법적으로 잘 맞게 수정코드를 기존코드에 잘 적용시켜주면 된다. 이것은 HTML5이다. 그리고 출력 후 어디를 수정했는지도 알려줘, 코드블록으로 제공해줘",
                        ["JavaScript"] = "[기존코드]에 [수정코드]를 적용시켜서 생략없이 전체코드 출력해줘. 너가 코드를 해석해서 추가하거나 그러지 말고 문법적으로 잘 맞게 수정코드를 기존코드에 잘 적용시켜주면 된다. 이것은 JavaScript이다. 그리고 출력 후 어디를 수정했는지도 알려줘, 코드블록으로 제공해줘",
                        ["MQL4"] = "[기존코드]에 [수정코드]를 적용시켜서 생략없이 전체코드 출력해줘. 너가 코드를 해석해서 추가하거나 그러지 말고 문법적으로 잘 맞게 수정코드를 기존코드에 잘 적용시켜주면 된다. 이것은 MQL4이다. 그리고 출력 후 어디를 수정했는지도 알려줘, 코드블록으로 제공해줘",
                        ["MQH"] = "[기존코드]에 [수정코드]를 적용시켜서 생략없이 전체코드 출력해줘. 너가 코드를 해석해서 추가하거나 그러지 말고 문법적으로 잘 맞게 수정코드를 기존코드에 잘 적용시켜주면 된다. 이것은 MQH이다. 그리고 출력 후 어디를 수정했는지도 알려줘, 코드블록으로 제공해줘",
                        ["MQ5"] = "[기존코드]에 [수정코드]를 적용시켜서 생략없이 전체코드 출력해줘. 너가 코드를 해석해서 추가하거나 그러지 말고 문법적으로 잘 맞게 수정코드를 기존코드에 잘 적용시켜주면 된다. 이것은 MQ5이다. 그리고 출력 후 어디를 수정했는지도 알려줘, 코드블록으로 제공해줘"
                    };
                    SaveSettings();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"설정을 불러오는 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 현재 프롬프트를 설정 파일에 저장합니다.
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
                MessageBox.Show($"설정 파일 저장 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 강제로 클립보드를 해제하고 텍스트를 복사하는 메서드 [수정코드]
        /// </summary>
        /// <param name="text">복사할 텍스트</param>
        /// <returns>복사 성공 여부</returns>
        private bool ForceSetClipboard(string text)
        {
            IntPtr hGlobal = IntPtr.Zero;

            try
            {
                // 1단계: 클립보드 강제 해제 및 열기
                for (int attempt = 0; attempt < 5; attempt++)
                {
                    try
                    {
                        // 기존 클립보드 연결 강제 해제
                        CloseClipboard();
                        Thread.Sleep(50);

                        // 클립보드 열기 시도
                        if (OpenClipboard(this.Handle))
                        {
                            break;
                        }

                        if (attempt == 4)
                        {
                            return false; // 마지막 시도도 실패
                        }

                        Thread.Sleep(100 * (attempt + 1)); // 점진적 대기
                    }
                    catch
                    {
                        Thread.Sleep(100);
                    }
                }

                // 2단계: 클립보드 비우기
                if (!EmptyClipboard())
                {
                    CloseClipboard();
                    return false;
                }

                // 3단계: 메모리 할당 및 텍스트 복사
                byte[] bytes = Encoding.Unicode.GetBytes(text + "\0"); // null 종료 문자 추가
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

                // 4단계: 클립보드에 데이터 설정
                IntPtr result = SetClipboardData(CF_UNICODETEXT, hGlobal);
                if (result == IntPtr.Zero)
                {
                    CloseClipboard();
                    return false;
                }

                // 성공 시 hGlobal은 시스템이 관리하므로 해제하지 않음
                hGlobal = IntPtr.Zero;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                // 클립보드 닫기
                CloseClipboard();

                // 실패 시에만 메모리 해제
                if (hGlobal != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(hGlobal);
                }
            }
        }

        // '클립보드에 복사' 버튼을 클릭했을 때 실행되는 메서드입니다. [수정코드]
        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            string originalCode = originalCodeText.Text;
            string modifiedCode = modifiedCodeText.Text;
            string prompt = promptText.Text;

            if (string.IsNullOrWhiteSpace(prompt))
            {
                MessageBox.Show("프롬프트를 입력해주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(originalCode))
            {
                MessageBox.Show("기존 코드를 입력해주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnCopyToClipboard.Enabled = false;
            btnCopyToClipboard.Text = "강제 복사 중...";

            try
            {
                string outputText = $@"{prompt}

[기존코드]
{originalCode}
[수정코드]
{modifiedCode}";

                // 강제 클립보드 복사 시도
                bool success = ForceSetClipboard(outputText);

                if (success)
                {
                    MessageBox.Show("클립보드 강제 복사가 완료되었습니다!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SaveSettings();
                }
                else
                {
                    // 최후의 수단: .NET 방식으로 재시도
                    try
                    {
                        Clipboard.Clear();
                        Thread.Sleep(200);
                        Clipboard.SetText(outputText);
                        MessageBox.Show("클립보드 복사가 완료되었습니다.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SaveSettings();
                    }
                    catch
                    {
                        MessageBox.Show("클립보드 복사에 실패했습니다.\n시스템을 재시작하거나 다른 프로그램을 종료 후 다시 시도해주세요.", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnCopyToClipboard.Enabled = true;
                btnCopyToClipboard.Text = "클립보드에 복사";
            }
        }

        /// <summary>
        /// '지우기' 버튼 클릭 시 기존 및 수정 코드 내용을 삭제합니다.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            originalCodeText.Clear();
            modifiedCodeText.Clear();
        }

        // 창이 닫히기 직전에 실행되는 메서드입니다.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings(); // 창이 닫히기 전에 설정 저장
        }

        // 폼이 처음 화면에 나타날 때 실행되는 메서드입니다.
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings(); // 폼이 처음 열릴 때 설정 불러오기
        }

        /// <summary>
        /// 언어 선택 버튼 클릭 시 프롬프트를 설정하는 공통 이벤트 핸들러입니다.
        /// </summary>
        private void languageButton_Click(object sender, EventArgs e)
        {
            // 클릭된 버튼을 가져옵니다.
            Button? clickedButton = sender as Button;
            if (clickedButton != null)
            {
                string language = clickedButton.Tag?.ToString() ?? "";

                if (!string.IsNullOrEmpty(language))
                {
                    // 버튼의 Tag 속성에 저장된 언어 이름을 사용하여 프롬프트 텍스트를 생성합니다.
                    promptText.Text = $"[기존코드]에 [수정코드]를 적용시켜서 생략없이 전체코드 출력해줘. 너가 코드를 해석해서 추가하거나 그러지 말고 문법적으로 잘 맞게 수정코드를 기존코드에 잘 적용시켜주면 된다. 이것은 {language}이다. 그리고 출력 후 어디를 수정했는지도 알려줘, 코드블록으로 제공해줘";
                }
            }
        }

        // [수정코드] : XML 버튼 이벤트 핸들러 추가
        private void btnXML_Click(object sender, EventArgs e)
        {
            string xmlPrompt = "[기존코드]에 [수정코드]를 적용시켜서 생략없이 전체코드 출력해줘. " +
                                 "너가 코드를 해석해서 추가하거나 그러지 말고 문법적으로 잘 맞게 수정코드를 " +
                                 "기존코드에 잘 적용시켜주면 된다. 이것은 XML이다. " +
                                 "그리고 출력 후 어디를 수정했는지도 알려줘, 코드블록으로 제공해줘";

            UpdatePromptText(xmlPrompt);
        }

        // [수정코드] : UpdatePromptText 메서드가 필요하다면 아래와 같이 정의
        private void UpdatePromptText(string text)
        {
            promptText.Text = text;
        }

        /// <summary>
        /// '항상 위에' 체크박스 상태 변경 시 폼의 TopMost 속성을 설정합니다.
        /// </summary>
        private void alwaysOnTopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = alwaysOnTopCheckBox.Checked;
        }
    }
}
