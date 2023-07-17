using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    public InputEvents inputEvents;
    public PlayerEvents playerEvents;
    public RewardEvents rewardEvents;
    public MiscEvents miscEvents;
    public QuestEvents questEvents;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
        }
        instance = this;

        // initialize all events
        inputEvents = new InputEvents();
        playerEvents = new PlayerEvents();
        rewardEvents = new RewardEvents();
        miscEvents = new MiscEvents();
        questEvents = new QuestEvents();
    }
}