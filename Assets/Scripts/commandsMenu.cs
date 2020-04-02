using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class commandsMenu : MonoBehaviour
{
    public Canvas commandsCanvas;
    public Canvas menuCanvas;
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    public Text text6;
    public Text text7;
    public Text text8;
    public Text text9;
    public Text text10;
    public Text text11;
    public Text text12;
    public Text text13;
    public Button prevPage;
    public Button nextPage;
    public Image prevImage;
    public Image nextImage;
    public Text prevText;
    public Text nextText;

    public void onClickBack()
    {
        commandsCanvas.enabled = false;
        menuCanvas.enabled = true;
    }

    public void onClickNextPage()
    {
        nextText.enabled = false;
        prevText.enabled = true;
        nextImage.enabled = false;
        prevImage.enabled = true;
        nextPage.enabled = false;
        prevPage.enabled = true;
        text1.enabled = false;
        text2.enabled = false;
        text3.enabled = false;
        text4.enabled = false;
        text5.enabled = false;
        text6.enabled = false;
        text7.enabled = false;
        text8.enabled = false;
        text9.enabled = false;
        text10.enabled = false;
        text11.enabled = false;
        text12.enabled = true;
        text13.enabled = true;
    }

    public void onClickPrevPage()
    {
        nextText.enabled = true;
        prevText.enabled = false;
        nextImage.enabled = true;
        prevImage.enabled = false;
        nextPage.enabled = true;
        prevPage.enabled = false;
        text1.enabled = true;
        text2.enabled = true;
        text3.enabled = true;
        text4.enabled = true;
        text5.enabled = true;
        text6.enabled = true;
        text7.enabled = true;
        text8.enabled = true;
        text9.enabled = true;
        text10.enabled = true;
        text11.enabled = true;
        text12.enabled = false;
        text13.enabled = false;
    }
}
