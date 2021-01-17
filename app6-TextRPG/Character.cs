using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{//Constructor for all Players and Enemies
    public class Character : MonoBehaviour
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Gold { get; set; }
        public Vector2 RoomIndex { get; set; }
        public List<string> Inventory { get; set; } = new List<string>();

        public virtual void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health <= 0)
            {
                Die();
            }
        }

        public virtual void Die()
        {
            Debug.Log("Character has died.");
        }
    }
}