using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thing
{
    public string Name;
    public string Price;
    public float posFrame;
    public bool isBuy;
}
    
public class Shop : MonoBehaviour
{
    public Text textName;
    public Text textPrice;

    public GameObject frame;

    private AudioSource soundClick;

    Thing boots = new Thing();
    Thing bike = new Thing();
    Thing car = new Thing();
    Thing plane = new Thing();

    private Thing selectedObj;

    void Start()
    {
        soundClick = GameObject.Find("Sound_Click").GetComponent<AudioSource>();
        
        boots.Name = "Boots";
        boots.Price = "0";
        boots.posFrame = -835f;
        boots.isBuy = true;

        bike.Name = "Bike";
        bike.Price = "1000";
        bike.posFrame = -365f;
        bike.isBuy = Convert.ToBoolean(PlayerPrefs.GetInt("Bike"));

        car.Name = "Car";
        car.Price = "5000";
        car.posFrame = 220f;
        car.isBuy = Convert.ToBoolean(PlayerPrefs.GetInt("Car"));

        plane.Name = "Plane";
        plane.Price = "10000";
        plane.posFrame = 870f;
        plane.isBuy = Convert.ToBoolean(PlayerPrefs.GetInt("Plane"));
    }

    public void Drawing(Thing obj)
    {
        textName.text = "Name: " + obj.Name;

        frame.GetComponent<RectTransform>().anchoredPosition = new Vector2(obj.posFrame, -15f);
        selectedObj = obj;

        if (obj.isBuy)
        {
            textPrice.text = "Куплено";
            frame.GetComponent<Image>().color = new Color32(62, 195, 51, 255);
            return;
        }
        frame.GetComponent<Image>().color = new Color32(25, 55, 22, 255);
        textPrice.text = "Price: " + obj.Price;
    }

    public void Buy()
    {
        soundClick.Play();

        if (PlayerPrefs.GetInt("Money") >= int.Parse(selectedObj.Price))
        {
            PlayerPrefs.SetInt(selectedObj.Name, 1);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - int.Parse(selectedObj.Price));
        }
    }

    //Buttons
    public void ButtonBoots()
    {
        soundClick.Play();
        Drawing(boots);
    }

    public void ButtonBike()
    {
        soundClick.Play();
        Drawing(bike);
    }

    public void ButtonCar()
    {
        soundClick.Play();
        Drawing(car);
    }

    public void ButtonPlane()
    {
        soundClick.Play();
        Drawing(plane);
    }
}