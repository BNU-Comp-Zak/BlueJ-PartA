using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Zombie : Enemy
    {

        // Use this for initialization
        void Start()
        {
            Health = 10;
            MaxHealth = 10;
            Attack = 9;
            Defence = 4;
            Gold = 20;
            Description = "Zombie";
            Inventory.Add("Rotting Flesh");
        }
    }
}