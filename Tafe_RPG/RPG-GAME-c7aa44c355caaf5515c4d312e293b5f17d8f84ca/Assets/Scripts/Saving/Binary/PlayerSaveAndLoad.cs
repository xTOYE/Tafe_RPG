﻿using UnityEngine;

public class PlayerSaveAndLoad : MonoBehaviour
{
    public PlayerHandler player;
    public bool custom;
    private void Start()
    {
      if(!custom)
        {
            //Debug.Log("Load Binary shiz");
            Load();
        }
    }    
    public void Save()
    {
        PlayerSaveToBinary.SavePlayerData(player);
    }
    public void Load()
    {
        PlayerDataToSave data = PlayerSaveToBinary.LoadData(player);
        player.name = data.playerName;
        player.curCheckPoint = GameObject.Find(data.checkPoint).GetComponent<Transform>();
        player.maxHealth = data.maxHealth;
        player.maxMana = data.maxMana;
        player.maxStamina = data.maxStamina;

        player.curHealth = data.curHealth;
        player.curMana = data.curMana;
        player.curStamina = data.curStamina;

        if (!(data.pX == 0 && data.pY == 0 && data.pZ == 0))
        {
            player.transform.position = new Vector3(data.pX, data.pY, data.pZ);
            player.transform.rotation = new Quaternion(data.rX, data.rY, data.rZ, data.rW);
        }
        else
        {
            player.transform.position = player.curCheckPoint.position;
            player.transform.rotation = player.curCheckPoint.rotation;
        }
        player.skinIndex = data.skinIndex;
        player.hairIndex = data.hairIndex;
        player.mouthIndex = data.mouthIndex;
        player.eyesIndex = data.eyesIndex;
        player.clothesIndex = data.clothesIndex;
        player.armourIndex = data.armourIndex;

        player.characterClass = (CharacterClass)data.classIndex;
        player.characterName = data.playerName;

        for (int i = 0; i < player.stats.Length; i++)
        {
            player.stats[i].value = data.stats[i];
        }
        LoadCustomisation.SetTexture("Skin", data.skinIndex);
        LoadCustomisation.SetTexture("Hair", data.hairIndex);
        LoadCustomisation.SetTexture("Mouth", data.mouthIndex);
        LoadCustomisation.SetTexture("Eyes", data.eyesIndex);
        LoadCustomisation.SetTexture("Clothes", data.clothesIndex);
        LoadCustomisation.SetTexture("Armour", data.armourIndex);
    }
}
