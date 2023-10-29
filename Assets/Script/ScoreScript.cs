using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public int score = 0;
    public TMP_Text text;
    public GameObject button,button0;
    public GameObject player;
    PlayerScript playerScript;

    public void ScoreDisplay()
    {
        text.text = score.ToString("000");
    }

    private void Start()
    {

        button.SetActive(false);
        playerScript = player.GetComponent<PlayerScript>();
    }

    private void Update()
    {
        if (playerScript.isAlive)
        {
            button.SetActive(false);
            button0.SetActive(false);
        }
        else
        {
            button.SetActive(true);
            button0.SetActive(true);
        }
    }
}
