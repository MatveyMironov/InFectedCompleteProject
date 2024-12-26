using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class ImageLoadCapacityDisplayer : LoadCapacityDisplayer
    {
        [SerializeField] private Image imagePrefab;
        [SerializeField] private Transform content;

        [SerializeField] private Color filledColor;
        [SerializeField] private Color emptyColor;

        private List<Image> _images = new();

        protected override void DisplayCapacityImplementation(int capacity)
        {
            HideCapacity();

            for (int i = 0; i < capacity; i++)
            {
                Image image = Instantiate(imagePrefab, content);
                image.color = emptyColor;
                _images.Add(image);
            }

            DisplayEmptyLoad();
        }

        protected override void DisplayLoadImplementation(int load)
        {
            DisplayEmptyLoad();

            if (load > _images.Count)
            {
                load = _images.Count;
            }

            for (int i = 0; i < load; i++)
            {
                _images[i].color = filledColor;
            }
        }

        private void HideCapacity()
        {
            foreach (Image image in _images)
            {
                Destroy(image.gameObject);
            }

            _images.Clear();
        }

        private void DisplayEmptyLoad()
        {
            foreach (var image in _images)
            {
                image.color = emptyColor;
            }
        }
    }
}
