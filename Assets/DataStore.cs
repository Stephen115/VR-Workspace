using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStore : MonoBehaviour
{
    public string username;
    public string roomNumber;
    public int characterID;

    public static DataStore DS;
 
     void Awake()
    {
        MakeThisTheOnlyDataStore();
    }


    void MakeThisTheOnlyDataStore()
    {
        if (DS == null)
        {
            DontDestroyOnLoad(gameObject);
            DS = this;
        }
        else
        {
            if (DS != this)
            {
                Destroy(gameObject);
            }
        }
    }
    public void StoreData() 
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
