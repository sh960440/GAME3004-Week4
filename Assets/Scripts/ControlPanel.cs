using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class ControlPanel : MonoBehaviour
{
    public List<NavMeshAgent> agents;
    public List<MonoBehaviour> scripts;

    public PlayerBehavior player;
    public bool isGamePasused = false;

    public GameObject pauseLabelPanel;

    public PlayerDataSO playerData;

    // Start is called before the first frame update
    void Start()
    {
        agents = FindObjectsOfType<NavMeshAgent>().ToList();
        player = FindObjectOfType<PlayerBehavior>();

        foreach (var enemy in FindObjectsOfType<EnemyBehavior>())
        {
            scripts.Add(enemy);
        }

        scripts.Add(player);
        scripts.Add(FindObjectOfType<CameraController>());

        LoadFromPlayerPreferences();
    }

    // Update is called once per frame
        void Update()
    {
        
    }

    public void onLoadButtonPressed()
    {
        player.controller.enabled = false;
        player.transform.position = playerData.playerPosition;
        player.transform.rotation = playerData.playerRatation;
        player.health = playerData.playerHealth;
        player.controller.enabled = true;
    }

    public void onSaveButtonPressed()
    {
        playerData.playerPosition = player.transform.position;
        playerData.playerRatation = player.transform.rotation;
        playerData.playerHealth = player.health;

        SaveToPlayerPreferences();
    }

    public void onPauseButtonToggled()
    {
        isGamePasused = !isGamePasused;
        pauseLabelPanel.SetActive(isGamePasused);

        foreach (var agent in agents)
        {
            agent.enabled = !isGamePasused;
        }

        foreach (var script in scripts)
        {
            script.enabled = !isGamePasused;
        }
    }

    public void OnApplicationQuit()
    {
        SaveToPlayerPreferences();
    }

    public void LoadFromPlayerPreferences()
    {
        playerData.playerPosition.x = PlayerPrefs.GetFloat("playerPositionX");
        playerData.playerPosition.y = PlayerPrefs.GetFloat("playerPositionY");
        playerData.playerPosition.z = PlayerPrefs.GetFloat("playerPositionZ");

        playerData.playerRatation.x = PlayerPrefs.GetFloat("playerRotationX");
        playerData.playerRatation.y = PlayerPrefs.GetFloat("playerRotationY");
        playerData.playerRatation.z = PlayerPrefs.GetFloat("playerRotationZ");
        playerData.playerRatation.w = PlayerPrefs.GetFloat("playerRotationW");

        playerData.playerHealth = PlayerPrefs.GetInt("playerHealth");
    }

    public void SaveToPlayerPreferences()
    {
        PlayerPrefs.SetFloat("playerPositionX", playerData.playerPosition.x);
        PlayerPrefs.SetFloat("playerPositionY", playerData.playerPosition.y);
        PlayerPrefs.SetFloat("playerPositionZ", playerData.playerPosition.z);

        PlayerPrefs.SetFloat("playerRotationX", playerData.playerRatation.x);
        PlayerPrefs.SetFloat("playerRotationY", playerData.playerRatation.y);
        PlayerPrefs.SetFloat("playerRotationZ", playerData.playerRatation.z);
        PlayerPrefs.SetFloat("playerRotationW", playerData.playerRatation.w);

        PlayerPrefs.SetInt("playerHealth", playerData.playerHealth);

        PlayerPrefs.Save();
    }
}
