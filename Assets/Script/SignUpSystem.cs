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

    public GameObject SignUpPanel;
    public GameObject SignUpSucPanel;
    public GameObject ErrorPanel;

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
            SignUpSucPanel.SetActive(true);
        }
        else
        {
            ErrorPanel.SetActive(true);
        }
    }

    public void OnCancelButtonClicked()
    {
        CancelPanel();
    }

    private void CancelPanel()
    {
        SignUpPanel.SetActive(false);
        ErrorPanel.SetActive(false);
        SignUpSucPanel.SetActive(false);
    }      
}