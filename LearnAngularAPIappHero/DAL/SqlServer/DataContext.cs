using BLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SqlServer
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		public DataContext()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server =.; Database = AngularHero; User Id = sa; Password = sa123456; Encrypt = True; TrustServerCertificate = True; Trusted_Connection = True; ");
		}
		public virtual DbSet<Hero> Heros { get; set; }
	}
}
