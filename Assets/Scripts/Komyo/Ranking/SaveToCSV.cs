using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveToCSV : MonoBehaviour
{
    public string filePath = "Assets/Resources/CSV/RankingText.csv";
    public void Save(string fast, string second, string third, string fourth ,string fifth)
    {
        StreamWriter sw = new StreamWriter(filePath, false);
        sw.WriteLine(fast);
        sw.WriteLine(second);
        sw.WriteLine(third);
        sw.WriteLine(fourth);
        sw.WriteLine(fifth);
        sw.Flush();
        sw.Close();
    }
}
