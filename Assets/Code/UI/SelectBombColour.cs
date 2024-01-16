using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectBombColour : MonoBehaviour
{
    public Image ImageLightYellow, ImageLightRed, ImageLightGreen, ImageLightBlue, ImageYellow, ImageRed, ImageGreen, ImageBlue;

    private Dictionary<string, Image> colorToImageMap;
    public void OnChangeBombColour(string selectedColorHex)
    {
        PlayerPrefs.SetString("bombColour", "#"+selectedColorHex);
        SetImageActiveByColor("#" + selectedColorHex);
    }


    void Start()
    {
        colorToImageMap = new Dictionary<string, Image>
        {
            {"#FFE1B9", ImageLightYellow},
            {"#FFE5D7", ImageLightRed},
            {"#C6FFB8", ImageLightGreen},
            {"#C2D0FF", ImageLightBlue},
            {"#E9FF00", ImageYellow},
            {"#FF000A", ImageRed},
            {"#29FF00", ImageGreen},
            {"#0021FF", ImageBlue}
        };

        string color = PlayerPrefs.GetString("bombColour", "#FFE1B9");
        SetImageActiveByColor(color);
    }

    private void SetImageActiveByColor(string colorCode)
    {
        DisableAllImages();

        if (colorToImageMap.TryGetValue(colorCode.ToUpper(), out Image activeImage))
        {
            activeImage.enabled = true;
        }
        else
        {
            Debug.Log("Colour not recognized");
        }
    }

    private void DisableAllImages()
    {
        ImageLightYellow.enabled = false;
        ImageLightRed.enabled = false;
        ImageLightGreen.enabled = false;
        ImageLightBlue.enabled = false;
        ImageYellow.enabled = false;
        ImageBlue.enabled = false;
        ImageRed.enabled = false;
        ImageGreen.enabled = false;
    }
}
