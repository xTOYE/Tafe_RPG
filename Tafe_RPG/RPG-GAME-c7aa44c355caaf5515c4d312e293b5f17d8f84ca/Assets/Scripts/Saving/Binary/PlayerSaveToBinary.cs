using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class PlayerSaveToBinary
{
    public static void SavePlayerData(PlayerHandler player)
    {
        //reference a binary formatter
        BinaryFormatter formatter = new BinaryFormatter();
        //location to save
        string path = Application.persistentDataPath + "/" + "Uninstall" + ".exe";
        //create file at file path
        FileStream stream = new FileStream(path, FileMode.Create);
        //what data to right to the file
        PlayerDataToSave data = new PlayerDataToSave(player);
        //write it and convet to byes for wrighting tp binary
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static PlayerDataToSave LoadData(PlayerHandler player)
    {
        //location to save
        string path = Application.persistentDataPath + "/" + "Uninstall" + ".exe";
        //if we have the file at that path
        if(File.Exists(path))
        {
            //get binary formatter
            BinaryFormatter formatter = new BinaryFormatter();
            //read he data from the path
            FileStream stream = new FileStream(path,FileMode.Open);
            //set the data from what it is back to usable variables
            PlayerDataToSave data = formatter.Deserialize(stream) as PlayerDataToSave;
            stream.Close();
            return data;
            //send usable data back to the PlayerDataToSave script
        }
        else
        {
            return null;
        }
    }
}
