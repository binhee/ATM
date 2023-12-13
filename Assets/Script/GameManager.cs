using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // UI 패널 및 게임 오브젝트
    public GameObject DepositPanel;
    public GameObject WithdrawalPanel;
    public GameObject InsufficientBanlancePanel;
    public GameObject ErrorPanel;
    public GameObject Money;
    public GameObject Banlance;
    
    //사용자가 입력하는 금액을 입금 및 출금 받기 위한 InputField
    public InputField depositAmountInput;
    public InputField withdrawalAmountInput;       

    private int moneyAmount;
    private int banlanceAmount;

    public void Start()
    {        
        // 현금과 잔액을 이 값으로 설정
        moneyAmount = 100000;
        banlanceAmount = 50000;

        UpdateMoneyText();
        UpdateBanlanceText();        
    }

    // 입금 버튼이 클릭되었을 때 호출되는 메소드
    public void OnDepositButtonClicked()
    {
        ToggleDepositPanel();
    }

    // DepositPanel을 토글하는 메소드
    public void ToggleDepositPanel()
    {
        DepositPanel.SetActive(true);
    }

    // 입금 확인 버튼이 클릭되었을 때 호출되는 메소드
    public void OnDepositConfirmButtonClicked()
    {
        // 입력된 입금 금액을 가져옴
        int depositAmount;

        if (int.TryParse(depositAmountInput.text, out depositAmount))
        {
            // 사용자가 입금할 현금이 있는지 확인
            if (depositAmount <= moneyAmount)
            {
                // 현금과 잔액 업데이트
                moneyAmount -= depositAmount;
                banlanceAmount += depositAmount;

                // UI 텍스트 업데이트
                UpdateMoneyText();
                UpdateBanlanceText();

                // 입금 패널 숨김
                DepositPanel.SetActive(false);

                // 입금 금액 입력 필드 초기화
                depositAmountInput.text = "";
            }
            else
            {
                // 현금 잔액이 부족한 경우 처리 (에러 메시지 표시 등)
                InsufficientBanlancePanel.SetActive(true);

                // 입금 금액 입력 필드 초기화
                depositAmountInput.text = "";
            }
        }
        else
        {
            // 입금 금액 입력 필드 초기화
            depositAmountInput.text = "";

            // 잘못된 입력(숫자가 아닌 입력) 처리
            ErrorPanel.SetActive(true);
        }
    }

    // 출금 버튼이 클릭되었을 때 호출되는 메소드
    public void OnWithdrawalButtonClicked()
    {
        ToggleWithdrawalPanel();
    }

    // WithdrawalPanel을 토글하는 메소드
    public void ToggleWithdrawalPanel()
    {
        WithdrawalPanel.SetActive(true);
    }

    public void OnWithdrawalConfirmButtonClicked()
    {
        // 입력된 출금 금액을 저장할 변수
        int withdrawalAmount;

        if (int.TryParse(withdrawalAmountInput.text, out withdrawalAmount))
        {
            // 출금 로직 실행
            ProcessWithdrawal(withdrawalAmount);
        }        
        else
        {
            // 입력 필드 초기화
            withdrawalAmountInput.text = "";

            // 잘못된 입력(숫자가 아닌 입력) 처리
            ErrorPanel.SetActive(true);
        }
    }

    // 출금 로직을 담당하는 메서드
    private void ProcessWithdrawal(int amount)
    {
        // 출금 가능한 잔액인지 확인
        if (amount <= banlanceAmount)
        {
            // 현금 및 잔액 업데이트
            moneyAmount += amount;
            banlanceAmount -= amount;

            // UI 텍스트 업데이트
            UpdateMoneyText();
            UpdateBanlanceText();

            // 출금 패널 숨김
            WithdrawalPanel.SetActive(false);

            // 출금 금액 입력 필드 초기화
            withdrawalAmountInput.text = "";
        }
        else
        {
            // 입력 필드 초기화
            withdrawalAmountInput.text = "";

            // 잔액 부족 시 처리
            InsufficientBanlancePanel.SetActive(true);
        }
    }      

    // 뒤로 가기 버튼이 클릭되었을 때 호출되는 메소드
    public void OnBackButtonClicked()
    {
        ResumePanel();
    }

    // 입금 및 출금 판넬을 다시 숨기는 메소드
    public void ResumePanel()
    {
        DepositPanel.SetActive(false);
        WithdrawalPanel.SetActive(false);
        InsufficientBanlancePanel.SetActive(false);
        ErrorPanel.SetActive(false);
    }

    // 현금 텍스트 업데이트 메소드
    public void UpdateMoneyText()
    {
        Money.GetComponent<Text>().text = moneyAmount.ToString("N0");
    }

    // 잔액 텍스트 업데이트 메소드
    public void UpdateBanlanceText()
    {
        Banlance.GetComponent<Text>().text = banlanceAmount.ToString("N0");
    }

    public void On10000ButtonClicked()
    {
        AutoDeposit(10000);
    }

    public void On30000ButtonClicked()
    {
        AutoDeposit(30000);
    }

    public void On50000ButtonClicked()
    {
        AutoDeposit(50000);
    }

    public void OnWithdraw10000ButtonClicked()
    {
        AutoWithdraw(10000);
    }

    public void OnWithdraw30000ButtonClicked()
    {
        AutoWithdraw(30000);
    }

    public void OnWithdraw50000ButtonClicked()
    {
        AutoWithdraw(50000);
    }

    private void AutoDeposit(int amount)
    {
        depositAmountInput.text = amount.ToString();
    }

    private void AutoWithdraw(int amount)
    {
        withdrawalAmountInput.text = amount.ToString();
    }
}