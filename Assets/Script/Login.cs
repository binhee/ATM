using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public GameObject ErrorPanel;

    // 아이디 비밀번호 입력란
    public InputField useridInput;
    public InputField passwordInput;
    
    public void OnLoginButtonClick()
    {
        // 입력된 아이디 비밀번호
        string userid = useridInput.text;
        string password = passwordInput.text;

        //아이디와 비밀번호가 일치하는지 확인
        if (CheckCredentials(userid, password))
        {
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            ErrorPanel.SetActive(true);
        }
    }

    // 아이디와 비밀번호를 확인하는 함수
    private bool CheckCredentials(string userid, string password)
    {
        return userid == "1" && password == "1";
    }
}
