using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectionWheel : MonoBehaviour
{
    public enum swState {Normal, Attacking, Retreating, Following};
    public swState state;

    public GameObject followSingle;
    public GameObject followAll;

    public GameObject stopSingle;
    public GameObject stopAllS;

    public GameObject goHereSingle;
    public GameObject goHereAll;

    public GameObject attackSingle;
    public GameObject attackAll;
    
    public GameObject fallBackAll;
    public GameObject lineUpAll;
    public GameObject pushForwardAll;
    public GameObject retreatAll;

    void Start()
    {
        state = swState.Normal;
    }

   
    void Update()
    {
        // normal just has either push forward, follow or line up to get the ai in positions then go from there,

        // following allows for things to do while ready to attack (so basically everything)

        // Attacking allows for falling back/ pushing forward

        // Retreating allows for going to certain point, pos, retreat, line up

        // if stop all/ stop single) go to normal

        // issues that might happen with the singles that might interfere with context, maybe different command wheel entirely for single?

        // one wheel for all commands, then when looking at an AI individually bring up a different selection wheel just for single tasks that should just have 4 (attack,
        // follow, go here and stop)
        switch (state)
        {
            case swState.Normal:
                {
                    //All
                    pushForwardAll.SetActive(true);
                    followAll.SetActive(true);
                    lineUpAll.SetActive(true);
                    goHereAll.SetActive(true);

                    //Single
                    followSingle.SetActive(true);
                    goHereSingle.SetActive(true);

                    //Inactive
                    stopAllS.SetActive(false);
                    attackAll.SetActive(false);
                    retreatAll.SetActive(false);
                    fallBackAll.SetActive(false);
                    stopSingle.SetActive(false);
                    attackSingle.SetActive(false);


                    break;
                }
            case swState.Following:
                {
                    //All
                    pushForwardAll.SetActive(true);
                    followAll.SetActive(true);
                    lineUpAll.SetActive(true);
                    goHereAll.SetActive(true);
                    stopAllS.SetActive(true);
                    attackAll.SetActive(true);

                    //Single
                    attackSingle.SetActive(true);
                    goHereSingle.SetActive(true);
                    stopSingle.SetActive(true);
                    followSingle.SetActive(true);

                    //Inactive
                    retreatAll.SetActive(false);
                    fallBackAll.SetActive(false);
                    break;
                }
            case swState.Attacking:
                {
                    //All
                    pushForwardAll.SetActive(true);
                    followAll.SetActive(true);
                    lineUpAll.SetActive(true);
                    goHereAll.SetActive(true);
                    retreatAll.SetActive(true);
                    fallBackAll.SetActive(true);

                    //Single
                    goHereSingle.SetActive(true);
                    followSingle.SetActive(true);

                    //Inactive
                    stopAllS.SetActive(false);
                    attackAll.SetActive(false);
                    stopSingle.SetActive(false);
                    attackSingle.SetActive(false);
                    break;
                }
            case swState.Retreating:
                {
                    //All
                    followAll.SetActive(true);
                    lineUpAll.SetActive(true);
                    goHereAll.SetActive(true);

                    //Single
                    
                    goHereSingle.SetActive(true);
                    
                    followSingle.SetActive(true);

                    //Inactive
                    pushForwardAll.SetActive(false);
                    retreatAll.SetActive(false);
                    fallBackAll.SetActive(false);
                    stopAllS.SetActive(false);
                    attackAll.SetActive(false);
                    stopSingle.SetActive(false);
                    attackSingle.SetActive(false);
                    break;
                }
        }
    }
}
