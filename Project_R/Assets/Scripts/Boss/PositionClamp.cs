using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PositionClamp : MonoBehaviour
{
    [SerializeField] private GameObject music = null;
    public GameObject player = null;
    public float temp = -19.4f;
    public PlayableDirector cutscene;
    void Update()
    {
        if (!GameManager.Instance.bBattle && player.transform.position.x > -2.6f)
        {
            cutscene.gameObject.SetActive(true);
            cutscene.Play();
            temp = -2.6f;
        }
        ClampPlayerXPos(temp);
    }

    void ClampPlayerXPos(float clamppos = -19.4f)
    {
        if(player.transform.position.x <= clamppos)
        {
            player.transform.position = new Vector2(clamppos, player.transform.position.y);
        }
        if(player.transform.position.x >= 2.6f)
        {
            player.transform.position = new Vector2(2.6f, player.transform.position.y);
        }
    }

    public void BattleStart()
    {
        GameManager.Instance.bBattle = true;
        cutscene.gameObject.SetActive(false);
    }
    public void PlayMusic()
    {
        music.SetActive(true);
    }
}
