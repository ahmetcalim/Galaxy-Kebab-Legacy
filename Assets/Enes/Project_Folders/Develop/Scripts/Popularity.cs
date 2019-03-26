using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class Popularity
{
    public int userID;
    static double globalPopularity;
    static double dailyPopularity;
    static string path = Application.persistentDataPath + "/popularity.txt";
    static int index;
    public static void CalculateDailyPopularity(double value)
    {
        index++;
        dailyPopularity += value;
    }
    public static void SetGlobalPopularity()
    {
        if (!File.Exists(path))
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(dailyPopularity/index);
            }
        }
        else
        {
            File.WriteAllText(path,(GetGlobalPopularity()+dailyPopularity/index).ToString());
        }
        dailyPopularity = 0;
        index = 0;
    }
    public static double GetGlobalPopularity()
    {
        using (StreamReader sr = File.OpenText(path))
        {
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                globalPopularity = float.Parse(s);
            }
        }
        return globalPopularity;
    }
}
