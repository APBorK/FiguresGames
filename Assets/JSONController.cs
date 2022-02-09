using System;
using System.IO;
using UnityEngine;

[Serializable]
public class JSONController : MonoBehaviour
{
    [SerializeField] private PlayerInfo _playerInfo;
    public SettingInformation _settingInformation;
    
    private void Start() 
    { 
        Load();
        _playerInfo.MoveInfo = _settingInformation.move;
        _playerInfo.StartMove();
    }

    public void Save()
    {
        _settingInformation.move = _playerInfo.MoveInfo;
        File.WriteAllText(Application.dataPath + "/Save.json", JsonUtility.ToJson(_settingInformation));
    }

    public void Load()
    {
        _settingInformation =
            JsonUtility.FromJson<SettingInformation>(File.ReadAllText(Application.dataPath + "/Save.json"));
    }
    
    [Serializable]
    public class SettingInformation
    {
        public int move;
        public int energy;
    }
}
