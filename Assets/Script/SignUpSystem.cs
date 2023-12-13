using System;
using UnityEngine;
using UnityEngine.UI;

public class RegistrationSystem : MonoBehaviour
{
    //ȸ������ ���� �Է�
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

    // ȸ������ ��ư Ŭ�� �� ����Ǵ� �Լ�
    public void OnRegisterButtonClick()
    {
        // �Էµ� ���̵�
        string userid = useridInput.text;
        // �Էµ� �г���
        string name = nameInput.text;
        // �Էµ� ��й�ȣ
        string password = passwordInput.text;
        // �Էµ� ��й�ȣ Ȯ��
        string confirmPassword = confirmPasswordInput.text;

        // ��й�ȣ�� ��й�ȣ Ȯ���� ��ġ�ϴ��� Ȯ��
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