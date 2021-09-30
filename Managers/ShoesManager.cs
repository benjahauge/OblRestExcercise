using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OblRestExcercise.Models;

namespace OblRestExcercise.Managers
{
	public class ShoesManager
	{
		private static int _nextId = 1;
		private static readonly List<Shoe> Data = new List<Shoe>
		{
			new Shoe {ID = _nextId++, Brand = "Adidas", Name = "NMD", Price = 749},
			new Shoe {ID = _nextId++, Brand = "Puma", Name = "Smash", Price = 500},
			new Shoe {ID = _nextId++, Brand = "Nike", Name = "AirForce 1", Price = 899}
		};

		public List<Shoe> GetAll()
		{
			return new List<Shoe>(Data);
		}

		public List<Shoe> GetWithContains(string substring)
		{
			List<Shoe> resultShoes = new List<Shoe>(Data);
			if (substring != null)
			{
				resultShoes  = resultShoes.FindAll(shoe => shoe.Brand.Contains(substring))
			;
			}
			return resultShoes;
		}

		public Shoe GetById(int id)
		{
			return Data.Find(item => item.ID == id);
		}

		public Shoe Add(Shoe newShoe)
		{
			newShoe.ID = _nextId++;
			Data.Add(newShoe);
			return newShoe;
		}

		public Shoe Delete(int id)
		{
			Shoe shoe = Data.Find(shoe1 => shoe1.ID == id);
			if (shoe == null) return null;
			Data.Remove(shoe);
			return shoe;
		}

		public Shoe Update(int id, Shoe updates)
		{
			Shoe shoe = Data.Find(shoe1 => shoe1.ID == id);
			if (shoe == null) return null;
			shoe.Brand = updates.Brand;
			shoe.Name = updates.Name;
			shoe.Price = updates.Price;
			return shoe;
		}
	}
}
