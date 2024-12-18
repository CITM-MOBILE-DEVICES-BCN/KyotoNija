using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ROBOTIN
{
    public class PlayerSkinPreview : MonoBehaviour
    {
        private Image skinPreview;

        // Start is called before the first frame update
        void Start()
        {
            skinPreview = GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {
            skinPreview.sprite = GameManager.instance.playerData.playerSkin;
        }
    }
}
