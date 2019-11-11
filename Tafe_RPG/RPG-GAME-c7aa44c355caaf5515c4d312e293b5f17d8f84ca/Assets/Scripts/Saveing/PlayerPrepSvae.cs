using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//normally general game settings like sound and sens
public class PlayerPrepSvae : MonoBehaviour
{
    public PlayerHandler player;
    public void Start()
    {
        if(!PlayerPrefs.HasKey("Loaded"))
        {
            PlayerPrefs.DeleteAll();
            FirstLoad();
            PlayerPrefs.SetInt("loaded", 0);
            save();
        }
        else
        {
            //load binary
            Load();
        }
    }
    public void FirstLoad()
    {

        player.curHealth = player.maxHealth;
        player.curStamina = player.maxStamina;
        player.curMana = player.maxMana;
       // player.curCheckPoint = GameObject.Find("First Checkpoint").GetComponent<Transform>();
        //position
        PlayerPrefs.SetFloat("CurPosZ", player.transform.position.z);
        PlayerPrefs.SetFloat("CurPosX", player.transform.position.x);
        PlayerPrefs.SetFloat("CurPosY", player.transform.position.y);
        //roation
        PlayerPrefs.SetFloat("CurRotZ", player.transform.rotation.z);
        PlayerPrefs.SetFloat("CurRotX", player.transform.rotation.x);
        PlayerPrefs.SetFloat("CurRotY", player.transform.rotation.y);
        PlayerPrefs.SetFloat("CurRotW", player.transform.rotation.w);
    }

    public void save()
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

        player.transform.position = new Vector3(data.pX, data.pY, data.pZ);
        player.transform.rotation = new Quaternion(data.rX, data.rY, data.rZ, data.rW);
    }
}
