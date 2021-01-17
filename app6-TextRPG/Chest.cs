using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{ // Generates random outcomes from looting a chest
    public class Chest // The possible coutcomes from looting a chest
    {
        public string Item { get; set; }
        public int Gold { get; set; }
        public bool Trap { get; set; } //bool = True or False
        public bool Heal { get; set; }
        public Enemy Enemy { get; set; }

        public Chest() // Randomly rolling to determin the outcome of opening a chest.
        {
            if (Random.Range(0,7) == 2)
            {
                Trap = true;
            }
            else if (Random.Range(0,5) == 2)
            {
                Heal = true;
            }
            else if (Random.Range(0,10) == 1)
            {
                Enemy = EnemyDatabase.Instance.Enemies[2];
            }
            else
            {
                int itemToAdd = Random.Range(0, ItemDatabase.Instance.Items.Count);
                Item = ItemDatabase.Instance.Items[itemToAdd];
                Gold = Random.Range(10, 200);
            }

        }

    }
}