using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextGenerator : MonoBehaviour
{  
    // This class will be used to simply update the text UI for importnat informaotin regarding the simulation
    // initilaise variableS:
    public TextMeshProUGUI textComponent;
    private Simulation simulationScript;

    private Creature bestCreature;

    private int generation;
    private int bestCreatureNum;
    private float bestCreatureDistnace;
    

    void Start()
    {
        simulationScript = GameObject.Find("CreatureGenerator").GetComponent<Simulation>();
        textComponent.text = "Generation: ";
    }

    void Update(){
    if (textComponent != null) {
        bestCreature = simulationScript.getBestCreature();
        textComponent.text = "Generation: " + simulationScript.getGenNum() +
                          "\n Best Creature Number:     " + bestCreature.getCreatureNum() +
                          "\n Best Creature Distance:   " + bestCreature.getCreatureDistance().ToString("F2")+// 2 Decimal places
                          "\n Best Creature Generation: " + bestCreature.getCreatureGen()+
                          "\n Time elapsed:" + simulationScript.getTimeElapsed().ToString("F2"); // 2 Decimal places
                          ;
    }
    }
}
