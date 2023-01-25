using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using UnityEngine;
using Application = UnityEngine.Device.Application;

namespace Project.Scripts.Game.Areas.SaveSystem
{
    public class SaveSystemService : ISaveSystemService
    {
        private readonly string _pathToData = Application.persistentDataPath + "/gameData";

        public void SaveData<T>(T data)
        {
            string dataJson = JsonConvert.SerializeObject(data);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/gameData";
            FileStream fileStream = new FileStream(path, FileMode.Create);

            binaryFormatter.Serialize(fileStream, dataJson);
            fileStream.Close();
        }

        public T LoadData<T>()
        {
            if (File.Exists(_pathToData))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(_pathToData, FileMode.Open);
                string dataJson = binaryFormatter.Deserialize(fileStream) as string;
               T gameData = JsonConvert.DeserializeObject<T>(dataJson);
                Debug.Log(dataJson);
                fileStream.Close();
                return gameData;
            }

            return default;
        }
    }
}