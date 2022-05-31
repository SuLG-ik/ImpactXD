using Fight.Player.Collection;
using UnityEngine;

namespace Wish
{
    public class WishPreview : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private WishPlayerPreview playerPreview;
        [SerializeField] private WishPlayerDrop playerDrop;

        public void NewPlayer(PlayerItem player)
        {
            playerPreview.SetPlayer(player);
            playerDrop.SetPrimogems(0);
            animator.Play("show");
        }

        public void RepeatPlayer(PlayerItem player, int primogems)
        {
            playerPreview.SetPlayer(player);
            playerDrop.SetPrimogems(primogems);
            animator.Play("show");
        }
    }
}