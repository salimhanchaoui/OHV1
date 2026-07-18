using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathPanel;           // the dark panel that appears on death
    public Vector3 spawnPoint = Vector3.zero; // where the player respawns

    private PlayerStats playerStats;

    void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
        deathPanel.SetActive(false);
    }

    public void Show()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0f;    // pause the game
    }

    // Called by the Respawn button
    public void Respawn()
    {
        deathPanel.SetActive(false);
        Time.timeScale = 1f;    // unpause the game
        playerStats.Respawn(spawnPoint);
    }
}
