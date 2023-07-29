using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Save
{
    public class InputText : MonoBehaviour
    {
        //�I�u�W�F�N�g�ƌ��т���
        [SerializeField]
        private InputField inputField;
        [SerializeField]
        public Text playerName;
        public void InputGetText()
        {
            //�e�L�X�g��inputField�̓��e�𔽉f
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
