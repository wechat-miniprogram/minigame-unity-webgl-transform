using ParticleSimulationBudget;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowParticleUpdateCount : MonoBehaviour
{
    private Text _text;
    public ParticleSimulationBudgetManager budgetManager;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _text.text = $"Update Count: {budgetManager.UpdatedNormalParticles}"; 
    }
}
