using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject playerPrefab;
    public GameObject item;
    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            	NetworkObject objetoDaRede = Runner.Spawn(playerPrefab, Vector3.zero, Quaternion.identity, player);
	            Runner.SetPlayerObject(player, objetoDaRede);
        }
    }
}

