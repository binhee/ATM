using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public GameObject ErrorPanel;

    // ���̵� ��й�ȣ �Է¶�
    public InputField useridInput;
    public InputField passwordInput;
    
    public void OnLoginButtonClick()
    {
        // �Էµ� ���̵� ��й�ȣ
        string userid = useridInput.text;
        string password = passwordInput.text;

        //���̵�� ��й�ȣ�� ��ġ�ϴ��� Ȯ��
        if (CheckCredentials(userid, password))
        {
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            ErrorPanel.SetActive(true);
        }
    }

    // ���̵�� ��й�ȣ�� Ȯ���ϴ� �Լ�
    private bool CheckCredentials(string userid, string password)
    {
        return userid == "1" && password == "1";
    }
}
