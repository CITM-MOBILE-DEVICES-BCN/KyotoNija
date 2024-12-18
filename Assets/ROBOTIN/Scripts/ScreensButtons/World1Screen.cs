using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ROBOTIN
{
    public class World1Screen : MonoBehaviour
    {
        [SerializeField] private List<SelectLevelButton> levelButtons;
        [SerializeField] private Button backButton;
        [SerializeField] private Slider levelSlider;

        public int levelsPerPage = 4;
        private int totalPages;

        private void Awake()
        {
            for (int i = 0; i < levelButtons.Count; i++)
            {
                levelButtons[i].Init(i + 1);
            }

            backButton.onClick.AddListener(OnBackButtonClicked);
            levelSlider.onValueChanged.AddListener(OnSliderValueChanged);
        }

        private void Start()
        {
            totalPages = (levelButtons.Count / levelsPerPage) + ((levelButtons.Count % levelsPerPage != 0) ? 1 : 0);
            levelSlider.minValue = 0;
            levelSlider.maxValue = totalPages - 1;
            //levelSlider.wholeNumbers = true;

            UpdateLevelButtons(0);
        }

        private void OnBackButtonClicked()
        {
            GameManager.instance.UnLoadScreen(gameObject.name);
        }

        private void OnSliderValueChanged(float value)
        {
            int sliderPosition = Mathf.Clamp(Mathf.RoundToInt(value), 0, totalPages - 1);
            UpdateLevelButtons(sliderPosition);
        }

        private void UpdateLevelButtons(int sliderPosition)
        {
            int startLevel = sliderPosition * levelsPerPage;
            int endLevel = Mathf.Min(startLevel + levelsPerPage, levelButtons.Count);

            for (int i = 0; i < levelButtons.Count; i++)
            {
                if (i >= startLevel && i < endLevel)
                {
                    levelButtons[i].gameObject.SetActive(true);
                }
                else
                {
                    levelButtons[i].gameObject.SetActive(false);
                }
            }
        }
    }
}