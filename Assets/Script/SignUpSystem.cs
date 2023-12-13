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
            Debug.Log("ȸ������ ���� - ���̵�: " + userid + ", ��й�ȣ: " + password);
            registrationResultText.text = "ȸ������ ����!";
        }
        else
        {
            registrationResultText.text = "��й�ȣ�� ��ġ���� �ʽ��ϴ�.";
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