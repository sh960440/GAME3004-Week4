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
}
