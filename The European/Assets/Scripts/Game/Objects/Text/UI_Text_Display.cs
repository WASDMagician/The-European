using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_Text_Display : MonoBehaviour {

    public GameObject text_object_parent;
    public Text text_object;
    string text;
    public float scale_speed, fade_speed;

    Text_Trigger trigger_source;

    public void Set_Trigger_Source(Text_Trigger _trigger_source)
    {
        trigger_source = _trigger_source;
    }

    public void Set_Text(string _text)
    {
        text = _text;
        text_object.text = _text;
        Show_Text();
    }

    public void Set_Text(string _text, float _time)
    {
        text = _text;
        text_object.text = _text;
        StartCoroutine(Show_Text_Time(_time));
    }

    void Show_Text()
    {
        text_object_parent.SetActive(true);
        text_object_parent.transform.DOScale(1, scale_speed);
        text_object_parent.GetComponent<Image>().DOFade(1, fade_speed);
        text_object.DOFade(1, fade_speed).OnComplete(Show_Complete);
    }

    public void Hide_Text()
    {
        text_object_parent.transform.DOScale(0, scale_speed);
        text_object_parent.GetComponent<Image>().DOFade(0, fade_speed);
        text_object.DOFade(0, fade_speed).OnComplete(Hide_Complete);
    }

    IEnumerator Show_Text_Time(float _time)
    {
        Show_Text();
        yield return new WaitForSeconds(_time);
        Hide_Text();
    }

    void Show_Complete()
    {
        if(trigger_source != null)
        {
            trigger_source.Text_Box_Shown();
        }
    }

    void Hide_Complete()
    {
        if(trigger_source != null)
        {
            trigger_source.Text_Box_Hidden();
        }
    }
}
