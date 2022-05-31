using System;
using System.Collections.Generic;
using System.Linq;
using Fight.Player;
using Fight.Player.Collection;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Player.Storage
{
    public class PlayersStoragePrefs : PlayersStorageWrapper
    {
        private IPlayersCollection collection;

        private IPlayersCollection GetCollection()
        {
            return collection ??= FindObjectOfType<PlayersCollectionWrapper>();
        }

        [CanBeNull] private SelectedPlayers savedPlayers;

        public override void SetPlayerLevelById(string characterId, int level)
        {
            PlayerPrefs.SetInt(CharacterLevel + characterId, level);
            PlayerPrefs.Save();
        }

        public override PlayerPreset GetPlayerById(string characterId)
        {
            var level = PlayerPrefs.GetInt(CharacterLevel + characterId, 0);
            return level == 0
                ? null
                : new PlayerPreset(level: level, player: GetCollection().GetPlayerById(characterId));
        }

        public override SelectedPlayers GetSelectedPlayers()
        {
            return savedPlayers ??= LoadSelectedPlayers();
        }


        public override void SetSelectedPlayer(SelectedPlayers players)
        {
            savedPlayers = SaveSelectedPlayers(players);
        }

        private SelectedPlayers SaveSelectedPlayers(SelectedPlayers players)
        {
            if (players.First == null && players.Second == null)
                players = GenerateStartupPlayers();
            PlayerPrefs.SetString(FirstPlayerId, players.First == null ? "" : players.First.Player.characterId);
            PlayerPrefs.SetString(SecondPlayerId, players.Second == null ? "" : players.Second.Player.characterId);
            PlayerPrefs.Save();
            return players;
        }

        private SelectedPlayers GenerateStartupPlayers()
        {
            var preset = new PlayerPreset(
                player: GetCollection().GetPlayers().First(),
                level: 1
            );
            var players = new SelectedPlayers(
                first: preset,
                second: null
            );
            SetPlayerLevelById(preset.Player.characterId, preset.Level);
            SetSelectedPlayer(players);
            return players;
        }

        private SelectedPlayers LoadSelectedPlayers()
        {
            var players = new SelectedPlayers(
                first: LoadPlayer(FirstPlayerId),
                second: LoadPlayer(SecondPlayerId)
            );
            if (players.First == null && players.Second == null)
                players = GenerateStartupPlayers();
            return players;
        }

        private PlayerPreset LoadPlayer(PlayerItem player)
        {
            var level = PlayerPrefs.GetInt(CharacterLevel + player.characterId, 0);
            return new PlayerPreset(
                player: player,
                level: level
            );
        }

        [CanBeNull]
        private PlayerPreset LoadPlayer(string tag)
        {
            var id = PlayerPrefs.GetString(tag, "");
            if (id == "")
                return null;
            var item = GetCollection().GetPlayerById(id);
            return LoadPlayer(item);
        }


        private const string FirstPlayerId = "players_selected_0";
        private const string SecondPlayerId = "players_selected_1";
        private const string CharacterLevel = "character_level_";
    }
}