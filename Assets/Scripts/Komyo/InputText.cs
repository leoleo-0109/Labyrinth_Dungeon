using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Save
{
    public class InputText : MonoBehaviour
    {
        //オブジェクトと結びつける
        [SerializeField]
        private InputField inputField;
        [SerializeField]
        public Text playerName;
        public void InputGetText()
        {
            //テキストにinputFieldの内容を反映
            playerName.text = inputField.text;
        }
        private void Update()
        {
            if (Input.GetKey(KeyCode.Return)) {
                SetKey();
            }
        }
        private void SetKey()
        {
            PlayerPrefs.SetString("PlayerName", playerName.text);
        }
    }
}
