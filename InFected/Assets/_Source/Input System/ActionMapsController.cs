using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ActionMapsController
    {
        public readonly PlayerControls PlayerControls;

        public ActionMapsController()
        {
            PlayerControls = new();
        }

        public void EnableMainActionMap()
        {
            PlayerControls.MainActionMap.Enable();
        }

        public void DisableMainActionMap()
        {
            PlayerControls.MainActionMap.Disable();
        }
        public void EnableJournalActionMap()
        {
            PlayerControls.JournalActionMap.Enable();
        }

        public void DisableJournalActionMap()
        {
            PlayerControls.JournalActionMap.Disable();
        }

        public void EnablePauseActionMap()
        {
            PlayerControls.PauseActionMap.Enable();
        }

        public void DisablePauseActionMap()
        {
            PlayerControls.PauseActionMap.Disable();
        }
    }
}