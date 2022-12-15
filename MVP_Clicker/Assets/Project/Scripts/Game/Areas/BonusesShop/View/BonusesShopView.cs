using UnityEngine;

namespace Project.Scripts.Game.Areas.BonusesShop.View
{
    public class BonusesShopView : MonoBehaviour
    {
        [SerializeField] private GameObject _shopMenu;
        [SerializeField] private GameObject _shopMenuOpener;

        public void OpenShopMenu()
        {
            _shopMenu.SetActive(true);
            _shopMenuOpener.SetActive(false);
        }

        public void CloseShopMenu()
        {
            _shopMenu.SetActive(false);
            _shopMenuOpener.SetActive(true);
        }
    }
}