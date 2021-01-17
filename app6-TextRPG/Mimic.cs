using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Mimic : Enemy
    {

        // Use this for initialization
        void Start()
        {
            Health = 15;
            MaxHealth = 15;
            Attack = 12;
            Defence = 6;
            Gold = 25;
            Description = "Mimic";
            Inventory.Add("Jewels");
        }
    }
}