using UnityEngine;
using TMPro;
using Fusion;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpItens;

    void Update()
    {
        UpdateScoreboard();
    }

    void UpdateScoreboard()
    {
        string placar = "=== PLACAR ===\n";

        NetworkObject[] players = FindObjectsOfType<NetworkObject>();

        int i = 1;

        foreach (var obj in players)
        {
            PlayerController player = obj.GetComponent<PlayerController>();

            if (player != null)
            {
                string you = obj.HasInputAuthority ? " (VOCÊ)" : "";
                placar += $"Player {i}{you}: {player.Score}\n";
                i++;
            }
        }

        tmpItens.text = placar;
    }
}