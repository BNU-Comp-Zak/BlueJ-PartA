using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TextRPG
{// Creates journal to output text to the screen
    public class Journal : MonoBehaviour
    {
        [SerializeField] Text logText; //Attribute tp serialize the field
        public static Journal Instance { get; set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this.gameObject);
            else
                Instance = this;

            Journal.Instance.Log("Welcome to the Dungeon.");
        }


        public void Log(string text)
        {
            logText.text += "\n" + text;
        }
    }

}