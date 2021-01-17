using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{//Database for storing all enemies
    public class EnemyDatabase : MonoBehaviour
    {
        public List<Enemy> Enemies { get; set; } = new List<Enemy>();
        public static EnemyDatabase Instance { get; set; }

        private void Awake()
        {
            if (Instance != null && Instance != this) // if true, Instance is assined an item database.
                Destroy(this.gameObject); // Gets rid of any copys of the item database
            else
                Instance = this;

            foreach (Enemy enemy in GetComponents<Enemy>()) // Looks though the game to find all entites associated with the Enemy script
            {
                Debug.Log("Found Enemy!");
                Enemies.Add(enemy);
            }
        }

        public Enemy GetRandomEnemy()
        {
            return Enemies[Random.Range(0, 2)];
        }
    }
    

}