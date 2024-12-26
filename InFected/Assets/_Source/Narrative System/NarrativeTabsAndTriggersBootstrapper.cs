using Core;
using System;
using TriggerZoneSystem;
using UnityEngine;

namespace NarrativeSystem
{
    public class NarrativeTabsAndTriggersBootstrapper : MonoBehaviour
    {
        [SerializeField] private TabAndTrigger[] tabsAndTriggers = new TabAndTrigger[0];

        public void Bootstrapp(ActionMapsController actionMapsController)
        {
            if (actionMapsController is null) throw new ArgumentNullException(nameof(actionMapsController));

            foreach (var tabAndTrigger in tabsAndTriggers)
            {
                NarrativeController narrativeTriggerController = new(tabAndTrigger.Tab, tabAndTrigger.Trigger, actionMapsController);
            }
        }

        [Serializable]
        private struct TabAndTrigger
        {
            [SerializeField] private NarrativeTab tab;
            [SerializeField] private TriggerZone2D trigger;

            public readonly NarrativeTab Tab { get => tab; }
            public readonly TriggerZone2D Trigger { get => trigger; }
        }
    }
}