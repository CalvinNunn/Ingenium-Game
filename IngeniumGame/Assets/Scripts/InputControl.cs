using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class InputControl : MonoBehaviour
    {
        private Command mouseButton, buttonR, buttonA, buttonD;
        private bool isReplaying;
        public GameObject player;
        public static List<Command> oldCommands = new List<Command>();
        public static bool shouldStartReplay;
        private Coroutine replayCoroutine;
        public bool changeControl = false;

        public int timer = 200;
        void Start()
        {
            
        }

        void Update()
        {
            if (changeControl == true)
            {
                changeControls();
            }
            else if (changeControl == false)
            {
                normalControls();
            }

            if (!isReplaying)
            {
                HandleInput();
            }
            StartReplay();
            timer++;
        }

        public void HandleInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                mouseButton.Execute(player, mouseButton);
            }
            if (Input.GetKey("r"))
            {
                buttonR.Execute(player, buttonR);
            }
            if (Input.GetKey("c"))
            {
                changeControl = true;
            }
            if (Input.GetKey("v"))
            {
                changeControl = false;
            }

        }

        public Command returnButtonR()
        {
            return buttonR;
        }

        public Command returnMouseButton()
        {
            return mouseButton;
        }

        void StartReplay()
        {
            if (shouldStartReplay && oldCommands.Count > 0)
            {
                shouldStartReplay = false;

                //Stop the coroutine so it starts from the beginning
                if (replayCoroutine != null)
                {
                    StopCoroutine(replayCoroutine);
                }

                //Start the replay
                replayCoroutine = StartCoroutine(replayCommands(player));
            }
        }

        IEnumerator replayCommands(GameObject t)
        {
            isReplaying = true;

            t.transform.position = player.transform.position;

            for (int i = 0; i < oldCommands.Count; i++)
            {
                oldCommands[i].mP(t);
                yield return new WaitForSeconds(0.1f);
            }

            isReplaying = false;
        }

        void changeControls()
        {
            buttonR = new mouseClick();
        }

        void normalControls()
        {
            mouseButton = new mouseClick();
        }
    }
}