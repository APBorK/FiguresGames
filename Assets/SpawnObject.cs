using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class SpawnObject : MonoBehaviour
{

    [SerializeField] private List<GameObject> _spawn,_gameObj;
    [SerializeField] private PlayerInfo _playerInfo;
    private List<GameObject> _game = new List<GameObject>();
    private int _number, _pair;


    private void Update()
    {
        if (_game != null)
        {
            if (_number == 4)
            {
                _pair = 0;
                Test();
                if (_pair == 2)
                {
                    SpawnObj(6);
                    _playerInfo.EnergyInfo = 2;
                    _playerInfo.StartEnergy();
                }
            }
            if (_number == 6)
            {
                _pair = 0;
                Test();
                if (_pair == 2)
                {
                    SpawnObj(11);
                    _playerInfo.EnergyInfo = 3;
                    _playerInfo.StartEnergy();
                }
            }

            if (_number == 11)
            {
                _pair = 0;
                Test();
                if (_pair == 4)
                {
                    SpawnObj(11);
                    _playerInfo.EnergyInfo = 3;
                    _playerInfo.StartEnergy();
                }
            }
        }
    }

    private void Test()
    {
        for (int i = 0; i < _game.Count; i++)
        {
            for (int j = 0; j < _game.Count; j++)
            {
                if (_game[i].tag == "Circle")
                {
                    if (_game[i].transform.position == _game[j].transform.position && _game[j].tag == "Square")
                    {
                        _pair++;
                    }
                }     
            }
        }
    }

    public void SpawnObj(int number)
    {
        _number = number;
        if (_game != null)
        {
            for (int i = 0; i < _game.Count; i++)
            {
                Destroy(_game[i]);
            }

            _game.Clear();
        }
        for (int i = 0; i < number; i++)
        {
            if (number == 6 && i >= 4 || number == 11 && i >= 8)
            {
               var obj = Instantiate(_gameObj[2]);
               obj.transform.position = _spawn[i].transform.position;
               _game.Add(obj);
            }
            else
            {
                if (i % 2 ==0)
                {
                    var obj = Instantiate(_gameObj[0]);
                    obj.transform.position = _spawn[i].transform.position;
                    var scale = Random.Range(1, 6) * 0.1f;
                    obj.transform.localScale = new Vector3(scale,scale);
                    _game.Add(obj);
                }
                else
                {
                    var obj = Instantiate(_gameObj[1]);
                    obj.transform.position = _spawn[i].transform.position;
                    var scale = Random.Range(1, 6) * 0.1f;
                    obj.transform.localScale = new Vector3(scale,scale);
                    _game.Add(obj);
                }
               
            }
        }
    }
}
