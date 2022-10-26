using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeChatWASM;
using UnityEngine.SceneManagement;

public class Common : MonoBehaviour
{
    public void ChangeScene(int index) {
        SceneManager.LoadScene(index);
    }
}
