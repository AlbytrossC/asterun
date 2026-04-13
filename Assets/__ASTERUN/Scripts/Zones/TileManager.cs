using System.Collections.Generic;
using UnityEngine;

namespace ASTERUN
{
    public class TileManager : MonoBehaviour //rename to TileManager.cs
    {
        [Tooltip("Tile Prefabs for Zone A")]
        [SerializeField] private List<GameObject> zoneATiles = new List<GameObject>();

        [Tooltip("World Y Position of the most recently spawned tile")]
        [SerializeField] private float highestTileY;

        [Tooltip("Height (size) of a tile")]
        [SerializeField] private float tileHeight;

        [Tooltip("Nearest Wall to Player")]
        [SerializeField] private GameObject nearestWallToPlayer;

        [SerializeField] private List<GameObject> nearbyWalls = new List<GameObject>(); //walls close to player

        private void OnEnable()
        {
            //Setup();
            SpawnRandomTile(highestTileY + tileHeight);
        }

        /// <summary>
        /// Spawns a random tile (working) from the specified zone (todo)
        /// </summary>
        /// <param name="ypos"> World height to spawn the new tile at</param>
        private GameObject SpawnRandomTile(float ypos)
        {
            var rnd = zoneATiles[Random.Range(0, zoneATiles.Count)];
            var pos = new Vector3(0, ypos, 0);

            var newTile = SpawnTile( rnd , pos , rnd.transform.rotation);
            return newTile;

            // ready for accessing individual walls later:

            /*GameObject leftWall  = newTile.transform.GetChild(0).gameObject;
            GameObject rightWall = newTile.transform.GetChild(1).gameObject;*/
        }

        /// <summary>
        /// Spawns a tile at a position. A Base for other spawn functions to use.
        /// </summary>
        /// <param name="tile">prefab</param>
        /// <param name="pos">where to spawn</param>
        /// <param name="rot">prefab rotation</param>
        /// <returns></returns>
        private GameObject SpawnTile(GameObject tile, Vector3 pos, Quaternion rot)
        {
            GameObject newTile = Instantiate(tile, pos, rot);
            return newTile;
        }

        #region Public Functions

        /// <summary>World Y position of the most recently spawned tile</summary>
        /// <returns>Y pos (float)</returns>
        public float GetHighestTile() => highestTileY;
        public GameObject GetNearestWallToPlayer() => nearestWallToPlayer == null ? null : nearestWallToPlayer;

        #endregion
    }
}

