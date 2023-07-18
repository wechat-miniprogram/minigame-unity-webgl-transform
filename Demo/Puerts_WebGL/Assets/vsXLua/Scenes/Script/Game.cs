using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Application.runInBackground = true;
    }

    public GameObject SubPrefab;
    public GameObject Main;
    public Joystick Joystick;

    public Text FpsText;

    public Text BoxText;
    
    // Update is called once per frame
    private float timeCount = 0;
    private float tenFrameDeltaTime = 0;
    void Update()
    {
        timeCount += Time.deltaTime;
        tenFrameDeltaTime += Time.deltaTime;

        while (timeCount > generateInterval && Box.TotalBoxCount < 4000)
        {
            timeCount -= generateInterval;
            var SubObject = Object.Instantiate(SubPrefab, transform);

            SubObject.GetComponent<Box>().target = Main.transform;
        }
        if (Box.TotalBoxCount >= 4000) {
            timeCount = 0;
        }

        if (Time.frameCount % 10 == 0) 
        {
            FpsText.text = "FPS:" + (10 / tenFrameDeltaTime).ToString("0.00");
            tenFrameDeltaTime = 0;
        }
        BoxText.text = "Box:" + Box.TotalBoxCount;

        if (Joystick.Direction.magnitude != 0)
        {
            var direction = new Vector3(Joystick.Direction.x, 0, Joystick.Direction.y);
            Main.transform.position += direction * 0.04f;
            Main.transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    private float generateInterval = 0.01f;
    // public void interval0_05()
    // {
    //     generateInterval = 0.05f;
    // }
    // public void interval0_1()
    // {
    //     generateInterval = 0.1f;
    // }
    // public void interval0_5()
    // {
    //     generateInterval = 0.5f;
    // }
}
