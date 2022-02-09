using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int EnergyInfo
    {
        get => energyInfo;
        set => energyInfo = value;
    }

    public int MoveInfo
    {
        get => moveInfo;
        set => moveInfo = value;
    }
    [SerializeField] private TextMeshProUGUI _move, _energy;
    [SerializeField] private JSONController _controller;
    private int moveInfo, energyInfo;

    public void UpMove()
    {
        moveInfo++;
        _move.text = "Move: " + moveInfo;
        _controller.Save();
    }

    public void DestroyEnergy()
    {
        energyInfo--;
        _energy.text = "Energy: " + energyInfo;
    }

    public void StartEnergy()
    {
        _energy.text = "Energy: " + energyInfo; 
    }

    public void StartMove()
    {
        _move.text = "Move: " + moveInfo;
    }
}
