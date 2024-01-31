using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PadTextInput : MonoBehaviour
{
    public InputField inputField;   // 숫자 값이 입력되는 InputField
    public Text stackText;          // 스택을 표시하는 Text

    private Stack<int> valueStack = new Stack<int>();  // 입력된 숫자 값들을 저장할 스택

    void Start()
    {
        // InputField에 값이 입력될 때마다 이벤트를 등록
        inputField.onValueChanged.AddListener(OnInputValueChanged);
    }

    void OnInputValueChanged(string newValue)
    {
        // InputField에서 값이 변경될 때 호출되는 함수

        // 값이 숫자로 변환 가능한지 확인하고 스택에 추가
        if (int.TryParse(newValue, out int numericValue))
        {
            valueStack.Push(numericValue);

            // 스택의 내용을 텍스트로 업데이트
            UpdateStackText();
        }

        // 입력 필드 초기화
        inputField.text = "";
    }

    void UpdateStackText()
    {
        // 스택의 내용을 텍스트로 업데이트
        stackText.text = "Stack:\n";

        foreach (int value in valueStack)
        {
            stackText.text += value + "\n";
        }
    }
}
