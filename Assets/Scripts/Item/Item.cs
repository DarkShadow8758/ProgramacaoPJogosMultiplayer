using UnityEngine;
using Fusion;

public class Item : NetworkBehaviour
{
    [Networked] public NetworkBool IsCollected { get; set; }
    public float rotationSpeed = 100f;
    public override void FixedUpdateNetwork()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<NetworkObject>().HasInputAuthority)
        {
            if (IsCollected) return;

            PlayerRef player = other.GetComponent<NetworkObject>().InputAuthority;
            RPC_Collect(player);
        }
    }

    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void RPC_Collect(PlayerRef collector)
    {
        if (IsCollected) return;

        IsCollected = true;

        NetworkObject playerObj = Runner.GetPlayerObject(collector);

        if (playerObj != null)
        {
            PlayerController player = playerObj.GetComponent<PlayerController>();

            if (player != null)
            {
                player.RPC_AddScore(1);
            }
        }

        Runner.Despawn(Object);
    }
}