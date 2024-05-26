using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataSaveModel
{
    public string saveFilePath;
    
    public List<DataModel> dataModels = new List<DataModel>();

    public void SaveGame()
    {
        string savePlayerData = JsonConvert.SerializeObject(dataModels, Formatting.Indented, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
        File.WriteAllText(saveFilePath, savePlayerData);

    }

    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string loadPlayerData = File.ReadAllText(saveFilePath);
            dataModels = JsonConvert.DeserializeObject<List<DataModel>>(loadPlayerData);
        }
    }

    public void DeleteSaveFile()
    {
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
        }
    }
}
public class ControllerModels : MonoBehaviour
{
    public List<GameObject> dinoModels = new List<GameObject>();
    public DataSaveModel dataSaveModel = new DataSaveModel();
    public List<DinoModel> listModelCurrent = new List<DinoModel>();
    void Start()
    {
        dataSaveModel.saveFilePath = Application.persistentDataPath + "/ModelData.json";
        SetOnStart();
        //dataSaveModel.LoadGame();
        //LoadModel();
        //LoadAModel(10);
        //SaveGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadModel()
    {
        listModelCurrent.Clear();
        foreach(var data in dataSaveModel.dataModels)
        {
            DinoModel model = Instantiate(dinoModels[data.idModel], data.position, data.rotatiion).GetComponent<DinoModel>();
            listModelCurrent.Add(model);
            model.SetAnimationModel(data.indexIdle, data.turn, data.attack);
        }
    }

    public void LoadAModel(int index)
    {
        DinoModel model = Instantiate(dinoModels[index]).GetComponent<DinoModel>();
        listModelCurrent.Add(model);
    }

    public void SaveGame()
    {
        dataSaveModel.dataModels.Clear();
        foreach(DinoModel dinoModel in listModelCurrent)
        {
            dataSaveModel.dataModels.Add(dinoModel.dataModel);
        }

        dataSaveModel.SaveGame();
    }

    void SetOnStart()
    {
        for (int i= 0; i< dinoModels.Count; i++)
        {
            DinoModel dinoModelScript = dinoModels[i].GetComponent<DinoModel>();
            //if(dinoModelScript == null)
            //{
            //    dinoModels[i].AddComponent<DinoModel>();
            //}
            dinoModelScript.dataModel.idModel = i;

        }
    }

}
