using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralLevelSystem
{
    internal class LevelBuilderTest : MonoBehaviour
    {
        [SerializeField] private FragmentCount[] fragmentsCount = new FragmentCount[0];
        [SerializeField] private Transform levelContent;
        [SerializeField] private float fragmentSize;

        private LevelFragment[] LevelFragments { get { return GetLevelFragments().ToArray(); } }

        [ContextMenu("Build Level")]
        private void BuildLevel()
        {
            LevelBuilder.BuildLevel(LevelFragments, levelContent, fragmentSize);
        }

        private List<LevelFragment> GetLevelFragments()
        {
            List<LevelFragment> levelFragments = new();

            foreach (var fragmentCount in fragmentsCount)
            {
                for (int i = 0; i < fragmentCount.Count; i++)
                {
                    levelFragments.Add(fragmentCount.Fragment);
                }
            }

            return levelFragments;
        }

        [Serializable]
        private struct FragmentCount
        {
            [SerializeField] private LevelFragment fragment;
            [SerializeField] private int count;

            public readonly LevelFragment Fragment { get { return fragment; } }
            public readonly int Count { get { return count; } }
        }
    }
}
