using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{ // Randomly generates the rooms in the dungeon using a 2D array
    public class World : MonoBehaviour
    {
        public Room[,] Dungeon { get; set; } // Creates the 2D array
        public Vector2 Grid;
        private void Awake()
        {
            Dungeon = new Room[(int)Grid.x, (int)Grid.y];
            StartCoroutine(GenerateFloor());
        }

        public IEnumerator GenerateFloor()
        {
            Debug.Log("Generating floor!");
            for (int x = 0; x < Grid.x; x++)
            { //Creates the grid
                for (int y = 0; y < Grid.y; y++)
                {
                    Dungeon[x, y] = new Room // Puts a room in every square of the dungeon grid
                    {
                        RoomIndex = new Vector2(x, y) //Sets the roomIndex
                    };
                }
            }
            Debug.Log("Finding possible exit location. " + Time.time);
            yield return new WaitForSeconds(2);

            Vector2 exitLocation = new Vector2((int)Random.Range(0, Grid.x), (int)Random.Range(0, Grid.y)); //Sets a random grid location as the exit
            Dungeon[(int)exitLocation.x, (int)exitLocation.y].Exit = true;
            Dungeon[(int)exitLocation.x, (int)exitLocation.y].Empty = false;
            Debug.Log("Exit is at: " + exitLocation + " " + Time.time);
        }
    }
}