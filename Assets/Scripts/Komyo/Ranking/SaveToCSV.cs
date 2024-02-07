using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveToCSV : MonoBehaviour
{
    public string filePath = "Assets/Resources/CSV/RankingText.csv";

    public void PunctuateDate(string fast, string second, string third, string fourth, string fifth)
    {
        /*fast = ConvertString(fast);
        second = ConvertString(second);
        third = ConvertString(third);
        fourth = ConvertString(fourth);
        fifth = ConvertString(fifth);*/
        Save(fast, second, third, fourth ,fifth);
    }
    string ConvertString(string input)
    {
        // 数字が始まる位置を見つける
        int index = 0;
        while (index < input.Length && !char.IsDigit(input[index]))
        {
            index++;
        }

        // 数字が始まる位置が文字列の末尾よりも前にある場合
        if (index < input.Length)
        {
            // 数字の直前にカンマを挿入する
            return input.Substring(0, index) + "," + input.Substring(index);
        }
        else
        {
            // 数字が見つからなかった場合はそのまま返す
            return input;
        }
    }

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
