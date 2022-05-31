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
            PlayerPrefs.GetString(FirstPlayerId, players.First == null ? "" : players.First.Player.characterId);
            PlayerPrefs.GetString(SecondPlayerId, players.Second == null ? "" : players.Second.Player.characterId);
            return players;
        }

        private SelectedPlayers GenerateStartupPlayers()
        {
            var players = new SelectedPlayers(
                first: LoadPlayer(GetCollection().GetPlayers().First()),
                second: null
            );
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
            var level = PlayerPrefs.GetInt(CharacterLevel + player.characterId, 1);
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


        private const string FirstPlayerId = "player_selected_0";
        private const string SecondPlayerId = "players_selected_1";
        private const string CharacterLevel = "character_level_";
    }
}