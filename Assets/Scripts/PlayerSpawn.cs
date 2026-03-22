using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PlayerSpawn : SimulationBehaviour, IPlayerJoined
{
    public GameObject playerPrefab;
    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            Runner.Spawn(playerPrefab, Vector2.zero, Quaternion.identity, player);
        }
    }
}
