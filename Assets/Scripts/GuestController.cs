﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script is used for controlling a single guest
// Multiple guests are managed by the park controller using this script
public class GuestController : MonoBehaviour
{
    // Send and receive information from the park controller
    private ParkController park;

    private enum Emotion { angry, cry, frown, happy, heart, laugh, ok, smile, wink, wow};
    private int happiness; // 1 - 100

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Display an emote above guest's head
    // Might need a canvas object
    void ShowEmotion(Emotion e)
    {

    }


}
