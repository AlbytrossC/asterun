using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public void SaveData(string fileName, string data)
    {
        fileName = Path.Combine("/Users/ACyrus/Desktop/climbgame/Assets/SAVE", fileName);
        string path = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllText(path, data);
        Debug.Log("Data saved to: " + path);
    }

    public string LoadData(string fileName)
    {
        fileName = Path.Combine("/Users/ACyrus/Desktop/climbgame/Assets/SAVE", fileName);
        string path = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(path))
        {
            string data = File.ReadAllText(path);
            Debug.Log("Data loaded from: "+path);
            return data;
        }
        else
        {
            Debug.LogWarning("File Not Found: " + path);
            return null;
        }
    }

    public void TempSave() => SaveData("sv.txt", "test");
    public void TempLoad() => Debug.Log("'"+LoadData("sv.txt")+"'");
}
