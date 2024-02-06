using System.Collections.Generic;
using UnityEngine;
using System.IO;
using RankingData;

namespace CsvOption
{
    public class CSVLoad : MonoBehaviour
    {
        [SerializeField] private SetPlayersDate playersDate;
        public struct PlayerDate
        {
            public string name;
            public int score;
        }

        public List<PlayerDate> statusList = new List<PlayerDate>();

        private void Awake()
        {
            
            LoadCsvFile("RankingText");
            ReturnCstatus(statusList);
        }

        private void LoadCsvFile(string fileName)
        {
            PlayerDate cStatus = new PlayerDate{
                name = default,
                score = default
            };
            List<string[]> csvData = new List<string[]>();

            TextAsset csvFile = Resources.Load($"CSV/{fileName}") as TextAsset;

            if (csvFile == null)
            {
                Debug.LogError($"'{fileName}' が見つかりません");
                return;
            }

            StringReader reader = new StringReader(csvFile.text);

            while (reader.Peek() > -1)
            {
                string line = reader.ReadLine();
                string[] csvElements = line.Split(',');

                if (csvElements.Length == 2)
                {
                    Debug.Log(csvElements[0] + " " + csvElements[1]);
                    cStatus.name = csvElements[0];
                    cStatus.score = int.Parse(csvElements[1]);
                    statusList.Add(cStatus);
                }
            }
        }
        public void ReturnCstatus(List<PlayerDate> cStatus){
            for(int i = 0; i <= 4; i++){
                Debug.Log(cStatus[i].name);
                playersDate.AddPlayerDate(cStatus[i].name,cStatus[i].score,i);
            }
        }
    }
}