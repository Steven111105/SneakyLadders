using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuleBookManager : MonoBehaviour
{
    public struct Page
    {
        public Sprite ruleBookCover;
        public bool isUnlocked;
    }
    public Page[] ruleBookData;
    public Image leftPage;
    public Image rightPage;
    public Button nextButton;
    public Button prevButton;
    int pageIndex;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        pageIndex = 0;
        // Initialize rule book pages
        SetPages(pageIndex);
    }

    public void NextPage()
    {
        pageIndex++;
        LeftFlipAnimation();
        // SetPages(pageIndex);
    }
    public void PrevPage()
    {
        pageIndex--;
        RightFlipAnimation();
        // SetPages(pageIndex);
    }
    public void SetPages(int index)
    {
        leftPage.sprite = ruleBookData[2 * index].ruleBookCover;
        rightPage.sprite = ruleBookData[2 * index + 1].ruleBookCover;

        // Remove next or prev button if at start or end of book
        if (index == 0)
        {
            prevButton.gameObject.SetActive(false);
        }
        else
        {
            prevButton.gameObject.SetActive(true);
        }

        if (index >= ruleBookData.Length / 2 - 1)
        {
            nextButton.gameObject.SetActive(false);
        }
        else
        {
            nextButton.gameObject.SetActive(true);
        }
    }
    IEnumerator LeftFlipAnimation()
    {
        animator.SetTrigger("LeftFlip");
        yield return null;
    }
    IEnumerator RightFlipAnimation()
    {
        animator.SetTrigger("RightFlip");
        yield return null;
    }
}
