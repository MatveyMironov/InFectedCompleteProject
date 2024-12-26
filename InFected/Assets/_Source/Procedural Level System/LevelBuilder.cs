using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ProceduralLevelSystem
{
    public static class LevelBuilder
    {
        public static void BuildLevel(LevelFragment[] fragmentPrefabs, Transform levelContent, float fragmentSize)
        {
            if (fragmentPrefabs.Length == 0) { return; }

            LevelGrid levelGrid = new();
            List<LevelFragment> availableFragmentPrefabs = new(fragmentPrefabs);

            List<FragmentPlacementData> fragmentPlacementDatas = new();

            FragmentPlacementData placementData = PlaceFragmentAtPosition(availableFragmentPrefabs[0], new(0, 0), levelGrid, levelContent, fragmentSize);
            fragmentPlacementDatas.Add(placementData);
            availableFragmentPrefabs.RemoveAt(0);

            fragmentPlacementDatas.AddRange(PlaceRandomFragmentsAtRandomPosition(availableFragmentPrefabs, levelGrid, levelContent, fragmentSize));

            ManageAllFragmentsConnections(fragmentPlacementDatas.ToArray(), levelGrid.OccupiedPositions);
        }

        private static FragmentPlacementData PlaceFragmentAtPosition(LevelFragment fragmentPrefab, Vector2Int gridPosition, LevelGrid levelGrid, Transform levelContent, float fragmentSize)
        {
            Vector3 worldContentOffset = new(gridPosition.x * fragmentSize, gridPosition.y * fragmentSize, 0);

            levelGrid.TryPlaceFragmentAtPosition(fragmentPrefab, gridPosition);
            LevelFragment levelFragmentInstance = Object.Instantiate(fragmentPrefab, levelContent);
            levelFragmentInstance.transform.localPosition = levelContent.position + worldContentOffset;
            return new(levelFragmentInstance, gridPosition);
        }

        private static List<FragmentPlacementData> PlaceRandomFragmentsAtRandomPosition(List<LevelFragment> fragmentPrefabs, LevelGrid levelGrid, Transform levelContent, float fragmentSize)
        {
            List<FragmentPlacementData> fragmentPlacementDatas = new();

            for (int i = fragmentPrefabs.Count - 1; i >= 0; i--)
            {
                int index = Random.Range(0, fragmentPrefabs.Count);
                LevelFragment fragmentPrefab = fragmentPrefabs[index];
                FragmentPlacementData placementData = PlaceFragmentAtRandomPosition(fragmentPrefab, levelGrid, levelContent, fragmentSize);
                fragmentPlacementDatas.Add(placementData);
                fragmentPrefabs.RemoveAt(index);
            }

            return fragmentPlacementDatas;
        }

        private static FragmentPlacementData PlaceFragmentAtRandomPosition(LevelFragment fragmentPrefab, LevelGrid levelGrid, Transform levelContent, float fragmentSize)
        {
            List<Vector2Int> availablePositions = FindAvailablePlacementPositions(levelGrid);
            int index = Random.Range(0, availablePositions.Count);
            Vector2Int gridPosition = availablePositions[index];
            return PlaceFragmentAtPosition(fragmentPrefab, gridPosition, levelGrid, levelContent, fragmentSize);
        }

        private static List<Vector2Int> FindAvailablePlacementPositions(LevelGrid levelGrid)
        {
            List<Vector2Int> availablePositions = new();

            Vector2Int[] occupiedPositions = levelGrid.OccupiedPositions;

            foreach (Vector2Int occupiedPosition in occupiedPositions)
            {
                AddAvailablePosition(occupiedPosition, Vector2Int.up, availablePositions, occupiedPositions);
                AddAvailablePosition(occupiedPosition, Vector2Int.right, availablePositions, occupiedPositions);
                AddAvailablePosition(occupiedPosition, Vector2Int.down, availablePositions, occupiedPositions);
                AddAvailablePosition(occupiedPosition, Vector2Int.left, availablePositions, occupiedPositions);
            }

            return availablePositions;
        }

        private static void AddAvailablePosition(Vector2Int occupiedPosition, Vector2Int offset, List<Vector2Int> availablePositions, Vector2Int[] occupiedPositions)
        {
            Vector2Int position = occupiedPosition + offset;

            if (!occupiedPositions.Contains(position))
            {
                availablePositions.Add(position);
            }
        }

        private static void ManageAllFragmentsConnections(FragmentPlacementData[] fragmentPlacementDatas, Vector2Int[] fragmentsGridPositions)
        {
            foreach (FragmentPlacementData fragmentPlacement in fragmentPlacementDatas)
            {
                ManageFragmentConnections(fragmentPlacement, fragmentsGridPositions);
            }
        }

        private static void ManageFragmentConnections(FragmentPlacementData placementData, Vector2Int[] fragmentsGridPositions)
        {
            ManageSingleConnection(placementData.Fragment.UpperConnection, placementData.GridPosition + Vector2Int.up, fragmentsGridPositions);
            ManageSingleConnection(placementData.Fragment.RightConnection, placementData.GridPosition + Vector2Int.right, fragmentsGridPositions);
            ManageSingleConnection(placementData.Fragment.LowerConnection, placementData.GridPosition + Vector2Int.down, fragmentsGridPositions);
            ManageSingleConnection(placementData.Fragment.LeftConnection, placementData.GridPosition + Vector2Int.left, fragmentsGridPositions);
        }

        private static void ManageSingleConnection(LevelFragment.FragmentConnection fragmentConnection, Vector2Int targetPosition, Vector2Int[] fragmentsGridPositions)
        {
            if (fragmentsGridPositions.Contains(targetPosition))
            {
                fragmentConnection.Connect();
            }
            else
            {
                fragmentConnection.Disconnect();
            }
        }

        private readonly struct FragmentPlacementData
        {
            public readonly LevelFragment Fragment;
            public readonly Vector2Int GridPosition;

            public FragmentPlacementData(LevelFragment fragment, Vector2Int gridPosition)
            {
                Fragment = fragment;
                GridPosition = gridPosition;
            }
        }
    }
}