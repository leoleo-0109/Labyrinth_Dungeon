using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Button
{
    public class ConsoleOutput : MonoBehaviour
    {
        public ESPSerialHandler espSerialHandler;
        public NanoSerialHandler nanoSerialHandler;

        void Start()
        {
            espSerialHandler.OnDataReceived += OnDataReceived;
            nanoSerialHandler.OnDataReceived += OnDataReceived;
        }

        void OnDataReceived(string message)
        {
            var data = message.Split(
                new string[] { "\n" }, System.StringSplitOptions.None);
            if (data.Length != 1) return;
            Debug.Log(data[0]);
        }
    }   
}
