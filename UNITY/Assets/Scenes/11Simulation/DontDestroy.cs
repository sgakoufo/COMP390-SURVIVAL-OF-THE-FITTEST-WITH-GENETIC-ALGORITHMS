using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // THIS CLASS IS UED TO ENSURE IT IS NEVER DETROYED AND TRANSFER VARAIBLES FROM ONE GENERATION TO ANOTHER
    public static DontDestroy Instance;

    public int genNum = 0;
    public Creature cr1;
    public Creature cr2;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(GameObject.Find("DontDestroy"));
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void saveGenVars(int genNum_, Creature cr1_, Creature cr2_){
        genNum = genNum_;
        cr1 = cr1_;
        cr2 = cr2_;
    }
}
