using System;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CODE_Fixer // 프로젝트 이름과 동일해야 합니다.
{
    // partial 키워드는 이 클래스가 Form1.Designer.cs 파일과 합쳐진다는 것을 의미합니다.
    public partial class Form1 : Form
    {
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
        public class Settings
        {
            public string Prompt { get; set; } = string.Empty;
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
                    var settings = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

                    if (settings != null)
                    {
                        prompts = settings;
                    }
                }
                else
                {
                    // 기본 프롬프트 설정 (XML 추가)
                    prompts = new Dictionary<string, string>
                    {
                        ["C#"] = "[기존코드]에 [수정코드]를 적용시켜서 생략없이 전체코드 출력해줘. 너가 코드를 해석해서 추가하거나 그러지 말고 문법적으로 잘 맞게 수정코드를 기존코드에 잘 적용시켜주면 된다. 이것은 C#이다. 그리고 출력 후 어디를 수정했는지도 알려줘, 코드블록으로 제공해줘",
                        ["XML"] = "[기존코드]에 [수정코드]를 적용시켜서 생략없이 전체코드 출력해줘. 너가 코드를 해석해서 추가하거나 그러지 말고 문법적으로 잘 맞게 수정코드를 기존코드에 잘 적용시켜주면 된다. 이것은 XML이다. 그리고 출력 후 어디를 수정했는지도 알려줘, 코드블록으로 제공해줘",
                        ["Python"] = "[기존코드]에 [수정코드]를 적용시켜서 생략없이 전체코드 출력해줘. 너가 코드를 해석해서 추가하거나 그러지 말고 문법적으로 잘 맞게 수정코드를 기존코드에 잘 적용시켜주면 된다. 이것은 Python이다. 그리고 출력 후 어디를 수정했는지도 알려줘, 코드블록으로 제공해줘",
                        ["CSS"] = "[기존코드]에 [수정코드]를 적용시켜서 생략없이 전체코드 출력해줘. 너가 코드를 해석해서 추가하거나 그러지 말고 문법적으로 잘 맞게 수정코드를 기존코드에 잘 적용시켜주면 된다. 이것은 CSS이다. 그리고 출력 후 어디를 수정했는지도 알려줘, 코드블록으로 제공해줘",
                        ["HTML5"] = "[기존코드]에 [수정코드]를 적용시켜서 생략없이 전체코드 출력해줘. 너가 코드를 해석해서 추가하거나 그러지 말고 문법적으로 잘 맞게 수정코드를 기존코드에 잘 적용시켜주면 된다. 이것은 HTML5이다. 그리고 출력 후 어디를 수정했는지도 알려줘, 코드블록으로 제공해줘",
                        ["JavaScript"] = "[기존코드]에 [수정코드]를 적용시켜서 생략없이 전체코드 출력해줘. 너가 코드를 해석해서 추가하거나 그러지 말고 문법적으로 잘 맞게 수정코드를 기존코드에 잘 적용시켜주면 된다. 이것은 JavaScript이다. 그리고 출력 후 어디를 수정했는지도 알려줘, 코드블록으로 제공해줘",
                        ["MQL5"] = "[기존코드]에 [수정코드]를 적용시켜서 생략없이 전체코드 출력해줘. 너가 코드를 해석해서 추가하거나 그러지 말고 문법적으로 잘 맞게 수정코드를 기존코드에 잘 적용시켜주면 된다. 이것은 MQL5이다. 그리고 출력 후 어디를 수정했는지도 알려줘, 코드블록으로 제공해줘"
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
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                string jsonString = JsonSerializer.Serialize(prompts, options);
                File.WriteAllText(SETTINGS_FILE, jsonString, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"설정 파일 저장 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // '클립보드에 복사' 버튼을 클릭했을 때 실행되는 메서드입니다.
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

            try
            {
                string outputText = $@"{prompt}

[기존코드]
{originalCode}
[수정코드]
{modifiedCode}";

                Clipboard.SetText(outputText);
                MessageBox.Show("요청하신 내용이 클립보드에 복사되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SaveSettings(); // 성공 시 프롬프트 저장
            }
            catch (Exception ex)
            {
                MessageBox.Show($"처리 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
