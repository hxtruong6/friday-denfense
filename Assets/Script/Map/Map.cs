using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Map : BaseItem
{
    public List<Vector3> Stations = new List<Vector3>();
    private int NextIndex = 0;

    public Vector3 NextStation()
    {
        if (NextIndex + 1 < Stations.Count)
        {
            NextIndex++;
            return Stations[NextIndex - 1];
        }
        return new Vector3(0, 0);
    }

    public Map(string fileName)
    {
        ReadMapFromFile(fileName);
    }

    public Map(TextAsset ta)
    {
        ReadMapFromTextAsset(ta);
    }

    public void ReadMapFromFile(string fileName)
    {                
    }

    public void ReadMapFromTextAsset(TextAsset ta)
    {        
        var arrayString = ta.text.Split('\n');
        foreach (var line in arrayString)
        {
            string[] bits = line.Split(' ');

            float x = float.Parse(bits[0]);
            float y = float.Parse(bits[1]);
            float z = float.Parse(bits[2]);

            Stations.Add(new Vector3(x, y, z));
        }
    }
}
