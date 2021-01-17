using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TextRPG
{
    public class Encounter : MonoBehaviour
    {
        public Enemy Enemy { get; set; }
        [SerializeField] //Converts the object into bytes so that Unity can store and use them later
        Player player;

        [SerializeField]
        Button[] dynamicControls;

        public delegate void OnEnemyDieHandler(); //Delegate is a reference pointer to a method. It allows us to treat method as a variable and pass method as a variable for a callback
        public static OnEnemyDieHandler OnEnemyDie;

        private void Start()
        {
            OnEnemyDie += Loot;
        }
        public void ResetDynamicControls()
        {
            foreach (Button button in dynamicControls)
            {
                button.interactable = false;
            }
        }
        public void StartCombat()
        {
            this.Enemy = player.Room.Enemy;
            dynamicControls[0].interactable = true; // Attack
            dynamicControls[1].interactable = true; // Flee
            UIController.OnEnemyUpdate(this.Enemy);
        }
        public void StartChest()
        {
            dynamicControls[3].interactable = true;
        }
        public void StartExit()
        {
            dynamicControls[2].interactable = true;
        }
        public  void OpenChest()
        {
            Chest chest = player.Room.Chest; // Different outcomes from a chest
            if (chest.Trap)
            {
                player.TakeDamage(5);
                Journal.Instance.Log("The chest was a trap. You took 5 damage.");
            }
            else if (chest.Heal)
            {
                player.TakeDamage(-7);
                Journal.Instance.Log("The chest contained a health potion. You gained 7 health.");
            }
            else if (chest.Enemy)
            {
                player.Room.Enemy = chest.Enemy;
                player.Room.Chest = null;
                Journal.Instance.Log("The chest is a Mimic!");
                player.Investigate();
            }
            else
            {
                player.Gold += chest.Gold;
                player.AddItem(chest.Item);
                UIController.OnPlayerStatChange();
                UIController.OnPlayerInventoryChange();
                Journal.Instance.Log("You found: " + chest.Item + " and <color=#FFE556FF>" + chest.Gold + "g.</color>");
            }
            player.Room.Chest = null;
            dynamicControls[3].interactable = false;
        }
        public void Attack()
        {
            int playerDamageAmount = (int)(Random.value * (player.Attack - Enemy.Defence)); // Determins Player damage
            int enemyDamageAmount = (int)(Random.value * (Enemy.Attack - player.Defence));
            Journal.Instance.Log("<color=#34bf70>You attacked, dealing <b>" + playerDamageAmount + "</b> damage!</color>");
            Journal.Instance.Log("<color=#34bf70>The enemy retaliated, dealing <b>" + enemyDamageAmount + "</b> damage!</color>");
            player.TakeDamage(enemyDamageAmount);
            Enemy.TakeDamage(playerDamageAmount);

        }
        public void Flee()
        {
            int enemyDamageAmount = (int)(Random.value * (Enemy.Attack - (player.Defence * .3f)));
            player.Room.Enemy = null; //Removes enemy from room
            UIController.OnEnemyUpdate(null);
            player.TakeDamage(enemyDamageAmount);
            Journal.Instance.Log("<color=#34bf70>You fled the fight, taking <b>" + enemyDamageAmount + "</b> damage!</color>");
            player.Investigate();

        }
        public void ExitFloor()
        {
            StartCoroutine(player.world.GenerateFloor());
            player.Floor += 1;
            Journal.Instance.Log("You have found the exit to another floor. Floor: " + player.Floor);
            UIController.OnPlayerFloorChange();
        }
        public void Loot() //Adds loot from killing an enemy
        {
            player.AddItem(this.Enemy.Inventory[0]);
            player.Gold += this.Enemy.Gold;
            Journal.Instance.Log(string.Format("<color=#34bf70>You've slain {0}. Searching the body, you find a {1} and {2} gold!</color>", this.Enemy.Description, this.Enemy.Inventory[0], this.Enemy.Gold));
            this.Enemy = null;
            player.Room.Enemy = null;
            UIController.OnPlayerStatChange();
            player.Investigate();
            UIController.OnEnemyUpdate(this.Enemy);
        }
    }
}
