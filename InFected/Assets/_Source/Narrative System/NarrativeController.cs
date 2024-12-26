using Core;
using TriggerZoneSystem;

namespace NarrativeSystem
{
    public class NarrativeController
    {
        private NarrativeTab _narrativeTab;
        private TriggerZone2D _triggerZone;
        private ActionMapsController _actionMapsController;

        public NarrativeController(NarrativeTab narrativeTab, TriggerZone2D triggerZone, ActionMapsController actionMapsController)
        {
            _narrativeTab = narrativeTab;
            _triggerZone = triggerZone;
            _actionMapsController = actionMapsController;

            _narrativeTab.Hide();
            _triggerZone.IsActive = true;

            _triggerZone.OnTriggerEntered += StartNarrate;
            _narrativeTab.OnCloseInputRecieved += FinishNarrate;
        }

        private void StartNarrate()
        {
            _narrativeTab.Show();
            _actionMapsController.DisableMainActionMap();
            _triggerZone.IsActive = false;
        }

        private void FinishNarrate()
        {
            _narrativeTab.Hide();
            _actionMapsController.EnableMainActionMap();
        }
    }
}