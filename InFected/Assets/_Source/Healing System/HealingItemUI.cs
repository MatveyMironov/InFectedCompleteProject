using UISystem;
using UnityEngine;

public class HealingItemUI : HideableUI
{
    [SerializeField] private CountDisplayer firstAidKitsDisplayer;

    public CountDisplayer FirstAidKitsDisplayer { get => firstAidKitsDisplayer; }
}
