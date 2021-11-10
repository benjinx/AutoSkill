using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Woodcutting : Skill
{
    enum TreeType
    {
        Basic = 0,
        Oak,
        Willow
    };

    bool isCutting = false;
    TreeType treeType;
    float timeRemaining = 0.0f;
    float timeAmount = 0.0f;
    float oldTimeAmount = 0.0f;
    int amt = 0;

    public Image progressBarMaskImg;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isCutting && (isActive == Skills.None) || (isActive == Skills.Woodcutting))
        {
            isActive = Skills.Woodcutting;

            if (timeAmount != oldTimeAmount)
            {
                progressBarMaskImg.fillAmount = 0;
            }

            progressBarMaskImg.fillAmount = Mathf.InverseLerp(timeAmount, 0, timeRemaining);

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = timeAmount;

                Debug.Log("Cutting next log!");
                amt++;

                text.text = amt.ToString();
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            isActive = Skills.None;
            isCutting = false;
            timeRemaining = 0.0f;
            timeAmount = 0.0f;
        }
    }

    public void CutTree()
    {
        isCutting = true;
        treeType = TreeType.Basic;
        timeAmount = 3.0f;
        timeRemaining = 3.0f;
    }

    public void CutOakTree()
    {
        isCutting = true;
        treeType = TreeType.Oak;
        timeAmount = 4.0f;
        timeRemaining = 4.0f;
    }

    public void CutWillowTree()
    {
        isCutting = true;
        treeType = TreeType.Willow;
        timeAmount = 5.0f;
        timeRemaining = 5.0f;
    }
}