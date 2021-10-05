using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsharpExcercise;

namespace OblRestExcercise.Managers
{
	public class FootballPlayersManager
	{
		private static int _nextId = 1;
		private static readonly List<FootballPlayer> Data = new List<FootballPlayer>
		{
			new FootballPlayer {ID = _nextId++, Name = "Victor", Price = 10, ShirtNumber = 2},
			new FootballPlayer {ID = _nextId++, Name = "Peter", Price = 500, ShirtNumber = 5}
		};

		public List<FootballPlayer> GetAll()
		{
			return new List<FootballPlayer>(Data);
		}

		public List<FootballPlayer> GetWithContains(string substring)
		{
			List<FootballPlayer> resultPlayers = new List<FootballPlayer>(Data);
			if (substring != null)
			{
				resultPlayers = resultPlayers.FindAll(player => player.Name.Contains(substring))
					;
			}
			return resultPlayers;
		}

		public FootballPlayer GetById(int id)
		{
			return Data.Find(item => item.ID == id);
		}

		public FootballPlayer Add(FootballPlayer newPlayer)
		{
			newPlayer.ID = _nextId++;
			Data.Add(newPlayer);
			return newPlayer;
		}

		public FootballPlayer Delete(int id)
		{
			FootballPlayer player = Data.Find(player1 => player1.ID == id);
			if (player == null) return null;
			Data.Remove(player);
			return player;
		}

		public FootballPlayer Update(int id, FootballPlayer updates)
		{
			FootballPlayer player = Data.Find(player1 => player1.ID == id);
			if (player == null) return null;
			player.Name = updates.Name;
			player.Price = updates.Price;
			player.ShirtNumber = updates.ShirtNumber;
			return player;
		}
	}
}
