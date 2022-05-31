using System;
using Cysharp.Threading.Tasks;
using Game.Player.Storage;
using UnityEngine;

namespace Players
{
    public class PlayersSelector : MonoBehaviour
    {
        private SelectedPlayerPreviews selected;
        private PlayerPreviews characters;
        private IPlayersStorage storage;

        private async void Start()
        {
            storage = FindObjectOfType<PlayersStorageWrapper>();
            selected = FindObjectOfType<SelectedPlayerPreviews>();
            characters = FindObjectOfType<PlayerPreviews>();
            try
            {
                await HandleFields();
            }
            catch (OperationCanceledException)
            {
                print("canceled");
            }
        }

        private async UniTask HandleFields()
        {
            while (true)
            {
                var selectedField = await UniTask.WhenAny(selected.HandleField(), characters.HandleField());
                if (selectedField.winArgumentIndex == 0)
                {
                    selectedField.result1.Mark();
                    HandleChangePlayer(selectedField.result1, await characters.HandleField());
                }
                else
                {
                    await HandleShowContextPlayer(selectedField.result2);
                }
            }
        }

        private async UniTask HandleShowContextPlayer(PlayerPreview preview)
        {
            preview.ShowContext();
            await preview.HandleField();
            preview.HideContext();
        }

        private void HandleChangePlayer(SelectedPlayerPreview selectedField, PlayerPreview preview)
        {
            preview.Mark();
            var players = storage.GetSelectedPlayers();
            switch (selectedField.GetNumber())
            {
                case SelectedPlayerPreview.PlayerNumber.First:
                    players.First = preview.GetPreset();
                    break;
                case SelectedPlayerPreview.PlayerNumber.Second:
                    players.Second = preview.GetPreset();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            selectedField.Unmark();
            preview.Unmark();
            storage.SetSelectedPlayer(players);
        }
    }
}