using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Skeleton : Enemy
    {

        // Use this for initialization
        void Start()
        {
            Health = 11;
            MaxHealth = 11;
            Attack = 10;
            Defence = 5;
            Gold = 23;
            Description = "Skeleton";
            Inventory.Add("Bones");
        }
    }
}