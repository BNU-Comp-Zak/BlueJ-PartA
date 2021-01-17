using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TextRPG
{// Controls the UI to update the player and enemy stats
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        Player player;

        [SerializeField]
        Text playerStatsText, enemyStatsText, playerInventoryText, playerFloorText;

        public delegate void OnPlayerUpdateHandler();
        public static OnPlayerUpdateHandler OnPlayerStatChange;
        public static OnPlayerUpdateHandler OnPlayerInventoryChange;
        public static OnPlayerUpdateHandler OnPlayerFloorChange;

        public delegate void OnEnemyUpdateHandler(Enemy enemy);
        public static OnEnemyUpdateHandler OnEnemyUpdate;

        void Start()
        {
            OnPlayerStatChange += UpdatePlayerStats;
            OnPlayerInventoryChange += UpdatePlayerInventory;
            OnPlayerFloorChange += UpdatePlayerFloor;
            OnEnemyUpdate += UpdateEnemyStats;
            UIController.OnPlayerFloorChange();
        }

        public void UpdatePlayerStats()
        {
            playerStatsText.text = string.Format("Player: {0} Health, {1} Attack, {2} Defence, {3}g ", player.Health, player.Attack, player.Defence, player.Gold);  
        }
        public void UpdatePlayerInventory()
        {
            playerInventoryText.text = "Items: ";
            foreach(string item in player.Inventory)
            {
                playerInventoryText.text += item + " / ";
            }
        }
        public void UpdatePlayerFloor()
        {
            playerFloorText.text = string.Format("Floor: {0}",player.Floor);
        }
        public void UpdateEnemyStats(Enemy enemy)
        {
            if (enemy)
                enemyStatsText.text = string.Format("{0}: {1} Health, {2} Attack, {3} Defence", enemy.Description, enemy.Health, enemy.Attack, enemy.Defence);
            else
                enemyStatsText.text = "";

        }
    }

}