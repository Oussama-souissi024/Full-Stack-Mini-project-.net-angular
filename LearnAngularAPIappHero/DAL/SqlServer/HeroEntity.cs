using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SqlServer
{
	public class HeroEntity : IDataHelper<Hero>
	{
		private DataContext DB;
		private Hero _Table;
		public HeroEntity()
		{
			DB = new DataContext();
		}

		public int Add(Hero table)
		{			
			if (DB.Database.CanConnect())
			{
				DB.Heros.Add(table);
				DB.SaveChanges();
				return 1;
			}
			else
				return 0;
		}

		public int Delete(int ID)
		{
			if (DB.Database.CanConnect())
			{
				_Table = Find(ID);
				DB.Heros.Remove(_Table);
				DB.SaveChanges();
				return 1;
			}
			else
				return 0;
		}

		public int Edit(int ID, Hero table)
		{
			DB = new DataContext();
			if (DB.Database.CanConnect())
			{
				DB.Heros.Update(table);
				DB.SaveChanges();
				return 1;
			}
			else
				return 0;
		}

		public Hero Find(int ID)
		{
			if (DB.Database.CanConnect())
			{
				return DB.Heros.Where(x => x.HeroId == ID).First();
			}
			else
				return null;
		}

		public List<Hero> GetAllData()
		{
			if (DB.Database.CanConnect())
			{
				return DB.Heros.ToList();
			}
			else
				return null;
		}
	}
}
