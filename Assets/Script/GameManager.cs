using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // UI �г� �� ���� ������Ʈ
    public GameObject DepositPanel;
    public GameObject WithdrawalPanel;
    public GameObject InsufficientBanlancePanel;
    public GameObject ErrorPanel;
    public GameObject Money;
    public GameObject Banlance;
    
    //����ڰ� �Է��ϴ� �ݾ��� �Ա� �� ��� �ޱ� ���� InputField
    public InputField depositAmountInput;
    public InputField withdrawalAmountInput;       

    private int moneyAmount;
    private int banlanceAmount;

    public void Start()
    {        
        // ���ݰ� �ܾ��� �� ������ ����
        moneyAmount = 100000;
        banlanceAmount = 50000;

        UpdateMoneyText();
        UpdateBanlanceText();        
    }

    // �Ա� ��ư�� Ŭ���Ǿ��� �� ȣ��Ǵ� �޼ҵ�
    public void OnDepositButtonClicked()
    {
        ToggleDepositPanel();
    }

    // DepositPanel�� ����ϴ� �޼ҵ�
    public void ToggleDepositPanel()
    {
        DepositPanel.SetActive(true);
    }

    // �Ա� Ȯ�� ��ư�� Ŭ���Ǿ��� �� ȣ��Ǵ� �޼ҵ�
    public void OnDepositConfirmButtonClicked()
    {
        // �Էµ� �Ա� �ݾ��� ������
        int depositAmount;

        if (int.TryParse(depositAmountInput.text, out depositAmount))
        {
            // ����ڰ� �Ա��� ������ �ִ��� Ȯ��
            if (depositAmount <= moneyAmount)
            {
                // ���ݰ� �ܾ� ������Ʈ
                moneyAmount -= depositAmount;
                banlanceAmount += depositAmount;

                // UI �ؽ�Ʈ ������Ʈ
                UpdateMoneyText();
                UpdateBanlanceText();

                // �Ա� �г� ����
                DepositPanel.SetActive(false);

                // �Ա� �ݾ� �Է� �ʵ� �ʱ�ȭ
                depositAmountInput.text = "";
            }
            else
            {
                // ���� �ܾ��� ������ ��� ó�� (���� �޽��� ǥ�� ��)
                InsufficientBanlancePanel.SetActive(true);

                // �Ա� �ݾ� �Է� �ʵ� �ʱ�ȭ
                depositAmountInput.text = "";
            }
        }
        else
        {
            // �Ա� �ݾ� �Է� �ʵ� �ʱ�ȭ
            depositAmountInput.text = "";

            // �߸��� �Է�(���ڰ� �ƴ� �Է�) ó��
            ErrorPanel.SetActive(true);
        }
    }

    // ��� ��ư�� Ŭ���Ǿ��� �� ȣ��Ǵ� �޼ҵ�
    public void OnWithdrawalButtonClicked()
    {
        ToggleWithdrawalPanel();
    }

    // WithdrawalPanel�� ����ϴ� �޼ҵ�
    public void ToggleWithdrawalPanel()
    {
        WithdrawalPanel.SetActive(true);
    }

    public void OnWithdrawalConfirmButtonClicked()
    {
        // �Էµ� ��� �ݾ��� ������ ����
        int withdrawalAmount;

        if (int.TryParse(withdrawalAmountInput.text, out withdrawalAmount))
        {
            // ��� ���� ����
            ProcessWithdrawal(withdrawalAmount);
        }        
        else
        {
            // �Է� �ʵ� �ʱ�ȭ
            withdrawalAmountInput.text = "";

            // �߸��� �Է�(���ڰ� �ƴ� �Է�) ó��
            ErrorPanel.SetActive(true);
        }
    }

    // ��� ������ ����ϴ� �޼���
    private void ProcessWithdrawal(int amount)
    {
        // ��� ������ �ܾ����� Ȯ��
        if (amount <= banlanceAmount)
        {
            // ���� �� �ܾ� ������Ʈ
            moneyAmount += amount;
            banlanceAmount -= amount;

            // UI �ؽ�Ʈ ������Ʈ
            UpdateMoneyText();
            UpdateBanlanceText();

            // ��� �г� ����
            WithdrawalPanel.SetActive(false);

            // ��� �ݾ� �Է� �ʵ� �ʱ�ȭ
            withdrawalAmountInput.text = "";
        }
        else
        {
            // �Է� �ʵ� �ʱ�ȭ
            withdrawalAmountInput.text = "";

            // �ܾ� ���� �� ó��
            InsufficientBanlancePanel.SetActive(true);
        }
    }      

    // �ڷ� ���� ��ư�� Ŭ���Ǿ��� �� ȣ��Ǵ� �޼ҵ�
    public void OnBackButtonClicked()
    {
        ResumePanel();
    }

    // �Ա� �� ��� �ǳ��� �ٽ� ����� �޼ҵ�
    public void ResumePanel()
    {
        DepositPanel.SetActive(false);
        WithdrawalPanel.SetActive(false);
        InsufficientBanlancePanel.SetActive(false);
        ErrorPanel.SetActive(false);
    }

    // ���� �ؽ�Ʈ ������Ʈ �޼ҵ�
    public void UpdateMoneyText()
    {
        Money.GetComponent<Text>().text = moneyAmount.ToString("N0");
    }

    // �ܾ� �ؽ�Ʈ ������Ʈ �޼ҵ�
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