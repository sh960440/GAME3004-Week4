﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    [Header("PlayerBehavior Transform Properties")]
    public Vector3 playerPosition;
    public Quaternion playerRatation;

    [Header("Player Attributes")]
    public int playerHealth;
}
