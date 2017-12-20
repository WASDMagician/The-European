using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Trigger : MonoBehaviour {

    public enum show_options { show_on_entry, show_on_key};
    public show_options show_option;

    public enum hide_options { hide_on_exit, hide_on_key, hide_after_time};
    public hide_options hide_option;
    [Multiline]
    public string text_to_display;
    public float time_to_display;
    public KeyCode key_to_show, key_to_hide;

    UI_Text_Display ui_text_display;
    bool shown;

    private void Update()
    {
        if (show_option == show_options.show_on_key)
        {
            if (Input.GetKeyDown(key_to_show) && shown == false)
            {
                Show();
            }
        }

        if (hide_option == hide_options.hide_on_key && shown == true)
        {
            if (Input.GetKeyDown(key_to_hide))
            {
                Hide();
            }
        }
    }

    void Show()
    {
        if (ui_text_display != null)
        {
            ui_text_display.Set_Trigger_Source(this);
            if (hide_option == hide_options.hide_on_exit || hide_option == hide_options.hide_on_key)
            {
                ui_text_display.Set_Text(text_to_display);
            }
            else if (hide_option == hide_options.hide_after_time)
            {
                ui_text_display.Set_Text(text_to_display, time_to_display);
            }
        }
    }

    void Hide()
    {
        if(ui_text_display != null)
        {
            ui_text_display.Hide_Text();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(ui_text_display == null)
        {
            ui_text_display = FindObjectOfType<UI_Text_Display>();
        }
        if (ui_text_display != null)
        {
            ui_text_display.Set_Trigger_Source(this);
            if (show_option == show_options.show_on_entry)
            {
                Show();
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (ui_text_display != null)
        {
            if (hide_option == hide_options.hide_on_exit)
            {
                ui_text_display.Hide_Text();
            }
        }
    }

    public void Text_Box_Shown()
    {
        shown = true;
    }

    public void Text_Box_Hidden()
    {
        shown = false;
    }
}
