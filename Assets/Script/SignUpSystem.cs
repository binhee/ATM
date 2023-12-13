using System;
using UnityEngine;
using UnityEngine.UI;

public class RegistrationSystem : MonoBehaviour
{
    //회원가입 정보 입력
    public InputField useridInput;
    public InputField nameInput;
    public InputField passwordInput;
    public InputField confirmPasswordInput;
    public Text registrationResultText;

    public GameObject SignUpPanel;

    public void OnSignUpButtonClicked()
    {
        ToggleSignUpPanel();
    }

    public void ToggleSignUpPanel()
    {
        SignUpPanel.SetActive(true);
    }

    // 회원가입 버튼 클릭 시 실행되는 함수
    public void OnRegisterButtonClick()
    {
        // 입력된 아이디
        string userid = useridInput.text;
        // 입력된 닉네임
        string name = nameInput.text;
        // 입력된 비밀번호
        string password = passwordInput.text;
        // 입력된 비밀번호 확인
        string confirmPassword = confirmPasswordInput.text;

        // 비밀번호와 비밀번호 확인이 일치하는지 확인
        if (password == confirmPassword)
        {            
            Debug.Log("회원가입 성공 - 아이디: " + userid + ", 비밀번호: " + password);
            registrationResultText.text = "회원가입 성공!";
        }
        else
        {
            registrationResultText.text = "비밀번호가 일치하지 않습니다.";
        }
    }

    public void OnCancelButtonClicked()
    {
        CancelPanel();
    }

    private void CancelPanel()
    {
        SignUpPanel.SetActive(false);
    }    
}