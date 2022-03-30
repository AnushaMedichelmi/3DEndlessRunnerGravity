using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class NestedData : MonoBehaviour
{
    // Start is called before the first frame update
    /*Four Rules to Nested Class
     * 1.Define variables
     * 2.Create class to serialize
     * 3.To create instance of a class
     * 4.Save the data
     */
    public string filePath;
    private string playerName="Anusha";
    private int score=10;
    private int maxScore=20;
    private int playerHealth=10;
    

    [System.Serializable]
    public class ToSerializeData
    {
        public string playerName;
        public int score;
        public int playerHealth;
       
    }
    void Start()
    {
        ToSaveData();
    }

    public void ToSaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        filePath = Application.persistentDataPath + "/MyFile.Haha";
        FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
        //BinaryWriter br = new BinaryWriter(fileStream);
        ToSerializeData tr=new ToSerializeData();
        tr.playerName = playerName;
        tr.score = score; 
        tr.playerHealth = playerHealth;
        formatter.Serialize(fileStream, tr);
        fileStream.Close();

    }

    public void ToLoadData()
    {

        filePath = Application.persistentDataPath + "/MyFile.Haha";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(filePath, FileMode.Open);
        ToSerializeData tr=formatter.Deserialize(fileStream) as ToSerializeData; 
       Debug.Log( tr.playerName = playerName);
       Debug.Log( tr.score=score);
        Debug.Log(tr.playerHealth = playerHealth);
        fileStream.Close ();
       // string myData = data.ToString();


    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.L))
        {
            ToLoadData();
        }
    }
}
