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

        private SelectedPlayers? savedPlayers;

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
                throw new ArgumentException("First and second player not selected. Programmer is stupid");
            PlayerPrefs.GetString(FirstPlayerId, players.First == null ? "" : players.First.Player.characterId);
            PlayerPrefs.GetString(SecondPlayerId, players.Second == null ? "" : players.Second.Player.characterId);
            return players;
        }

        private SelectedPlayers LoadSelectedPlayers()
        {
            return new SelectedPlayers(
                first: LoadPlayer(FirstPlayerId),
                second: LoadPlayer(SecondPlayerId)
            );
        }

        [CanBeNull]
        private PlayerPreset LoadPlayer(string tag)
        {
            var id = PlayerPrefs.GetString(tag, "");
            if (id == "")
                return null;
            var level = PlayerPrefs.GetInt(CharacterLevel + id, 1);
            var item = GetCollection().GetPlayerById(id);
            return new PlayerPreset(
                player: item, 
                level: level
            );
        }


        private const string FirstPlayerId = "player_selected_0";
        private const string SecondPlayerId = "players_selected_1";
        private const string CharacterLevel = "character_level_";
    }
}