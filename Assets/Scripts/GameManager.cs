using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singelton;

public class GameManager : Singelton<GameManager>
{
    [Header("Player")]
    public GameObject PlayerPrefab;

    [Header("Enemy")]
    public List<GameObject> EnemysPrefab;

    [Header("Prefences")]
    public Transform SpawPoint;
    private GameObject _currentPlayer;

    public void Start()
    {
        Init();
    }
    public void Init()
    {
        SpawPlayer();
    }


    private void SpawPlayer()
    {
        _currentPlayer = Instantiate(PlayerPrefab);
        _currentPlayer.transform.position = SpawPoint.transform.position;

    }
}
