using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
[CreateAssetMenu(fileName = "New Brick", menuName = "Arkanoid/Brick", order = 1)]
public class Brick : ScriptableObject
{
    [Tooltip("Name of the brick.")]
    public string Prefabname = "New Brick";
    [Tooltip("The sprite to be drawn for the brick.")]
    public Sprite PrefabSprite;
    [Tooltip("How many hits to break the tile.")]
    public int Health = 1;
    [Tooltip("The amount of points this brick gives")]
    public int Points = 1;
    [Tooltip("If the player can destroy this brick or not")]
    public bool Destructable = true;
    [Tooltip("If not null, this brick will be changed into 'NextBrick' when hit.")]
    public GameObject NextBrick;
    [Tooltip("A list of the powerups this brick can spawn. Requires a capsule prefab.")]
    public List<GameObject> PossiblePowerUps = new List<GameObject>();
    [Tooltip("The possibility for this brick to spawn a powerup.")]
    [Range(0,1)]
    public float PowerUpSpawnPossibility;
    


    private void Awake()
    {
        if (PrefabSprite == null)
        {
            Debug.LogWarning("Missing sprite in " + Prefabname, this);
        }

        
    }

    private void OnEnable()
    {
        foreach (GameObject g in PossiblePowerUps)
        {
            if (!g.CompareTag("Capsule"))
            {
                PossiblePowerUps.Remove(g);
                Debug.LogWarning(g + "Is not a powerUp caspsule, removing.");
            }
        }
    }
}
