using System.IO;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    public SaveData saveData;
    public SaveData blankSaveFile;
    string saveFilePath;

    private void OnEnable()
    {
        saveFilePath = Application.persistentDataPath + "/SAVE/save.asterun";
        LoadGame();
    }
    public void TempSave() => SaveGame(saveData);

    public void SaveGame(SaveData data)
    {
        string dataToSave = JsonUtility.ToJson(data);
        if (!File.Exists(saveFilePath))
            File.Create(saveFilePath).Dispose();
        File.WriteAllText(saveFilePath, dataToSave);
    }

    public void LoadGame()
    {
        Debug.Log("Checking for save file in [" + saveFilePath + "]");
        if (File.Exists(saveFilePath))
        {
            string dataToLoad = File.ReadAllText(saveFilePath);
            JsonUtility.FromJsonOverwrite(dataToLoad, saveData);
            Debug.Log("[Loaded!] Max Height: " + saveData.bestClimbHeight + ", Total Height: " + saveData.totalHeightClimbed +", Last Climb: "+saveData.lastClimbHeight);
        }
        else
        {
            Debug.Log("[ERROR] No Save File! Creating empty save...");
            FileInfo file = new FileInfo(saveFilePath);
            file.Directory.Create();
            SaveGame(blankSaveFile);
            LoadGame();
        }
        
    }

    public SaveData GetSaveData() => saveData;

    public void DeleteSaveFile()
    {
        if (!File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
        }
    }
}
