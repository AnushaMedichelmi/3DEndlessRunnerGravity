using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class File : MonoBehaviour
{
    // Start is called before the first frame update
  public  string filePath;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.W))
        {
            SaveTheData();
        }

        if (Input.GetKeyUp(KeyCode.N))
        {
            LoadTheData();
        }
    }

    private void LoadTheData()
    {
        filePath = Application.persistentDataPath + "/MyFile.Anusha";
        FileStream fileStream=new FileStream(filePath, FileMode.Open);
        BinaryReader br = new BinaryReader(fileStream);
        Debug.Log(br.Read());
        Debug.Log(br.Read());
        Debug.Log(br.ReadInt32());
        Debug.Log(br.Read());
        br.Close();
        fileStream.Close();
    }

    private void SaveTheData()
    {
        filePath = Application.persistentDataPath + "/MyFile.Anusha";
        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        BinaryWriter bw=new BinaryWriter(fs);
        bw.Write("Hello my name is Anusha and I'm working in Purple talk");
        bw.Write("I'm from Siddipet");
        bw.Close();
        fs.Close();
        
    }
}
