using NodeCanvas.DialogueTrees;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureDialogue : MonoBehaviour
{
    DialogueTreeController dialogueTree;    //获取对话树

    private void Start()
    {
        dialogueTree = GetComponent<DialogueTreeController>();  //初始化
    }

    void Update()
    {
        //如果获取到的按键为I
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialogueTree.StartDialogue();   //调取打开对话
        }
    }

    //触发对话
    public void Talk()
    {
        dialogueTree.StartDialogue();   //调取打开对话
    }
}
