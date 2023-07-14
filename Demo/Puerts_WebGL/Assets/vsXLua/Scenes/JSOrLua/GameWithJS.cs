using UnityEngine;
using UnityEngine.UI;
using System;
using Puerts;
using Puerts.TSLoader;

public class GameWithJS : JSBehaviour
{
    public GameObject SubPrefab;
    public GameObject Main;
    public Joystick Joystick;
    public Text FpsText;
    public Text BoxText;

    public override string ScriptName { get { return "game.mjs"; } }

    void Start()
    {
        ScriptBehaviourManager.InvokeStarter(this, this.ScriptName);
    }
    
    void Update()
    {
        ScriptBehaviourManager.InvokeUpdate(this);
    }
}