using BandAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BandAPI.DbContexts
{
	public class BandAlbumContext : DbContext
	{
		public BandAlbumContext(DbContextOptions<BandAlbumContext> options) :
			base(options)
		{

		}

		public DbSet<Band> Bands { get; set; }
		public DbSet<Album> Albums { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Band Seeder
			modelBuilder.Entity<Band>().HasData(
			new Band(){
				Id = Guid.Parse("2c64a452 - 0d46 - 4d10 - 9801 - 995ccb964c1b"),
				Name = "Metallica",
				Founded = new DateTime(1980, 1, 1),
				MainGenre="Heavy Metal"
			},
			new Band()
			{
				Id = Guid.Parse("82fe9c1a-57be-4b28-b2ff-11f4e17acaad"),
				Name = "Guns'N'Roses",
				Founded = new DateTime(1985, 2, 1),
				MainGenre = "Rock"
			},
			new Band()
			{
				Id = Guid.Parse("67952c0e-6009-472b-8bec-b19f3a79d9a9"),
				Name = "ABBA",
				Founded = new DateTime(1965, 7, 1),
				MainGenre = "Disco"
			},
			new Band()
			{
				Id = Guid.Parse("87f1ab3e-cea6-4e50-8f3b-d09524a0a6ee"),
				Name = "Oasis",
				Founded = new DateTime(1965, 12, 1),
				MainGenre = "Alternative"
			},
			new Band()
			{
				Id = Guid.Parse("bbd1357d-eb6c-4b2a-9290-98d704c004c3"),
				Name = "A-ha",
				Founded = new DateTime(1981, 6, 1),
				MainGenre = "Pop"
			});

			//Album Seeder
			modelBuilder.Entity<Album>().HasData(
				new Album { 
					Id=Guid.Parse("beaacd3f-aaa4-4044-9c66-cec29ee3805c"),
					Title="Master of Puppets",
					Description="One of the best heavy metal albums ever",
					BandId= Guid.Parse("2c64a452 - 0d46 - 4d10 - 9801 - 995ccb964c1b")
				},
				new Album
				{
					Id = Guid.Parse("d2663550-2412-4e29-8b7c-056431032cec"),
					Title = "Appetite for Destruction",
					Description = "Amazing Rock Album with raw sound",
					BandId = Guid.Parse("82fe9c1a-57be-4b28-b2ff-11f4e17acaad")
				},
				new Album
				{
					Id = Guid.Parse("491d3ef0-cfa6-4ec6-98f8-20112c9f3d29"),
					Title = "Waterloo",
					Description = "Very groovy album",
					BandId = Guid.Parse("67952c0e-6009-472b-8bec-b19f3a79d9a9")
				},
				new Album
				{
					Id = Guid.Parse("814092af-023e-4ccc-9474-86b29da4588e"),
					Title = "Be Here Now",
					Description = "One of the best albums by Oasis",
					BandId = Guid.Parse("87f1ab3e-cea6-4e50-8f3b-d09524a0a6ee")
				},
				new Album
				{
					Id = Guid.Parse("36a6190e-6eed-4ae8-88a1-6d987c47c029"),
					Title = "Hunting High and Low",
					Description = "One of the best heavy metal albums ever",
					BandId = Guid.Parse("bbd1357d-eb6c-4b2a-9290-98d704c004c3")
				});

			base.OnModelCreating(modelBuilder);
		}
	}
}
