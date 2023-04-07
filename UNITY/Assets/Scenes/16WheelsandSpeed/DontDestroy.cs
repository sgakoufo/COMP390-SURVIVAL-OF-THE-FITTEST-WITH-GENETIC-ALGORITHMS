// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class DontDestroy : MonoBehaviour
// {
//     // THIS CLASS IS UED TO ENSURE IT IS NEVER DETROYED AND TRANSFER VARAIBLES FROM ONE GENERATION TO ANOTHER
//     public static DontDestroy Instance;

//     private int genNum = 0;
//     private Creature cr1;
//     private Creature cr2;
//     private Color genColor;

//     private void Awake()
//     {
//         if (Instance == null)
//         {
//             Instance = this;
//             DontDestroyOnLoad(GameObject.Find("DontDestroy"));
//         }
//         else
//         {
//             Destroy(gameObject);
//         }
//     }

//     public void saveGenVars(int genNum_, Creature cr1_, Creature cr2_, Color genColor_){
//         // save the values passed from the Simualtion class to the DontDestroy class
//         genNum = genNum_;
//         cr1 = cr1_;
//         cr2 = cr2_;
//         genColor = genColor_;
//     }

//     // ========================================================================================================
//     // Getters and setters
//     // ========================================================================================================

//     public int      getGenNum(){
//         return genNum;
//     }
//     public Creature getCr1(){
//         return cr1;
//     }
//     public Creature getCr2(){
//         return cr2;
//     }
//     public Color getGenColor(){
//         return genColor;
//     }
// }
