using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadingScript : MonoBehaviour
{
    // Start is called before the first frame update
     public string namee = "File";
    public int age = 21;
    public float speed = 100.0f;
    public string str = "Good Evening";
    public string fileName = "C:/Users/Anusha.Medichelmi/Documents/Mydata/Sampledata.txt";
    void Start()
    {
       /* if(File.Exists("Sampledata"))
        {
            using FileStream sampledata = File.Open(fileName, FileMode.Open);
            using BinaryWriter binaryWriter = new BinaryWriter(sampledata);
            age= binaryWriter.Write();  
        }*/

       /* StreamWriter streamWriter = new StreamWriter(fileName);
        //BinaryWriter bw = new BinaryWriter(fileName);
        streamWriter.WriteLine(age);
        streamWriter.WriteLine(namee);
        streamWriter.Close();
       
       
        
        StreamReader streamReader = new StreamReader(fileName);
        //Debug.Log(streamReader.ReadLine());
        Debug.Log(streamReader.ReadToEnd());
        streamReader.Close();*/

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            CreateText();
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            ReadText();
        }
    }

   private void CreateText()
    {
        FileStream fileStream = new FileStream(fileName, FileMode.Open);
        BinaryWriter bw = new BinaryWriter(fileStream);
        bw.Write(age);
        bw.Write(namee);
        bw.Write(speed);
        bw.Write(str);
        bw.Close();
        fileStream.Close();
    }

    private void ReadText()
    {
        FileStream fileStream = new FileStream(fileName, FileMode.Open);
        BinaryReader bw = new BinaryReader(fileStream);
        Debug.Log(bw.Read());
        Debug.Log(bw.ReadString());
      
        bw.Close();
        fileStream.Close();
    }
}
