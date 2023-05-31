using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Button
{
    public class ObjectController : MonoBehaviour    
    {
        public SerialHandler serialHandler;
        public float delta = 0.01f;
        private float deltaPos;
        private Vector3 pos;

        void Start()
        {
            serialHandler.OnDataReceived += OnDataReceived;
        }

        void OnDataReceived(string message)
        {
            Vector3 pos = transform.localPosition;
            var data = message.Split(
                new string[] { "\n" }, System.StringSplitOptions.None);
            Debug.Log(message);

            switch (data[0])
            {
                case "Up":
                    deltaPos = delta * 10;
                    pos.y += deltaPos;
                    break;
                case "Down":
                    deltaPos = delta * -10;
                    pos.y += deltaPos;
                    break;
                case "Left":
                    deltaPos = delta * -10;
                    pos.x += deltaPos;
                    break;
                case "Right":
                    deltaPos = delta * 10;
                    pos.x += deltaPos;
                    break;
                default:
                    break;
            }
            transform.localPosition = pos;
        }
    } 
}
