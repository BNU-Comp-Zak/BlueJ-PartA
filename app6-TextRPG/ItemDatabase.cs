using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{ //Creates a database of items that can be found within chests
    public class ItemDatabase : MonoBehaviour
    {
        public List<string> Items { get; set; } = new List<string>();
        public static ItemDatabase Instance { get; set; }


        private void Awake() // Executes before Start methods.
        {
            if (Instance != null && Instance != this) // if true, Instance is assined an item database.
                Destroy(this.gameObject); // Gets rid of any copys of the item database
            else
                Instance = this;


            Items.Add("Gold Crown");
            Items.Add("Empty Chalice");
            Items.Add("Silk Robes");
            Items.Add("Jasper");
            Items.Add("Moonstone");
            Items.Add("Iron Boots");
            Items.Add("Arrows");
            Items.Add("A small bone knife");
            Items.Add("A key");

        }

    }
}
