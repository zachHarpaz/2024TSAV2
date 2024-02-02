using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class CutSceneScript : MonoBehaviour
{
    public string[] textArr;
    public TMP_Text storyText;
    public int[] delays;
    private bool enter = true;
    int time;
    //The delays are divided by this number to determine how often the player can skip. Larger would be better, but I am reluctant.
    public float timeBreaker = 360;
    //Used to separate images even when mouse is pressed.
    public float timeBetween = .5f;
    public string nextScene;
    public bool changeScenes;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    private void OnEnable()
    {
        StartCoroutine(startCutScene());
    }

    IEnumerator startCutScene()
    {
        for (var i = 0; i < textArr.Length; i++)
        {
            ChangeImage(i);
            yield return new WaitForSeconds(timeBetween);
            for (int breaker = 0; breaker < timeBreaker; breaker++)
            {
                if (Input.anyKey)
                {
                    break;
                }
                yield return new WaitForSeconds(delays[i] / timeBreaker);
            }

        }
        if (changeScenes)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            SceneManager.LoadScene("Intro Scene");
        }
    }
    private void ChangeImage(int i)
    {
        
        storyText.text = textArr[i];
    }

}
