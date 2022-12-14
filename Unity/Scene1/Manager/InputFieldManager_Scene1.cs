using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputFieldManager_Scene1 : MonoBehaviour
{

    [SerializeField]
    private TMP_InputField playerNameInputField;
    [SerializeField]
    public Text formCheckMsg;

    public CheckPopupManager_Scene1 checkPopupManager;
    string playerName;
    void Start()
    {
        playerNameInputField.characterLimit = 5; // InputField 글자 수 제한
        //playerNameInputField.onValueChanged.AddListener( // InputField 입력 시 영어, 한글, 숫자만 가능
        //    (word) => playerNameInputField.text = Regex.Replace(word, @"[^0-9a-zA-Z가-힣]", "")
        //);

    }
    public void Submit()
    {
        playerName = playerNameInputField.text.Trim();
        if (playerName.Length != 0)
        {
            bool flag = Regex.IsMatch(playerName, @"^[가-힣]*$");
            
            if (!flag)
            {
                Debug.Log("잘못된 입력 형식입니다.");
                formCheckMsg.color = Color.red;

            }
            else
            {
                checkPopupManager.Appear(playerName);
                formCheckMsg.color = Color.blue;
            }
        }
    }
}
