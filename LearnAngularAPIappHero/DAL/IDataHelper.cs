using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public interface IDataHelper<TEntity>
	{
		// Read
		List<TEntity> GetAllData();
		TEntity Find(int ID);

		// Write
		int Add(TEntity entity);
		int Edit(int ID, TEntity entity);
		int Delete(int ID);
	}
}
