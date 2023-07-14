using UnityEngine;
using UnityEngine.UI;

public class GameWithLua : LuaBehaviour
{
    public GameObject SubPrefab;
    public GameObject Main;
    public Joystick Joystick;
    public Text FpsText;
    public Text BoxText;

    public override string ScriptName { get { return "game.lua"; } }
    void Start()
    {
        ScriptBehaviourManager.InvokeStarter(this, this.ScriptName);
    }
    
    void Update()
    {
        ScriptBehaviourManager.InvokeUpdate(this);
    }
}