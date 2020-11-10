using System;
using System.Linq;
using FestivalProject.DAL;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FestivalProject.Tests
{
    public class FestivalDbContextTests : IDisposable
    {
        private readonly FestivalDbContext _testContext;
        public FestivalDbContextTests()
        {
            var setup = new FestivalDbContextSetup("testDb");
            _testContext = setup.DbContextFactory.CreateDbContext();
            setup.PrepareDatabase();
        }
        [Fact]
        public void Interpret_GetAll()
        {
            int numberOfInterprets = 2;


            var interpretsList = _testContext.Interprets
                .ToList(); ;

            Assert.Equal(numberOfInterprets, interpretsList.Count);

        }

        [Fact]
        public void Interpret_GetById()
        {
            var interpret = new InterpretEntity()
            {
                Id = Guid.Parse("c993e8d3-719b-43d7-908b-e26dc6f4ace0"),
                Name = "Metallica",
                LogoUri =
                    "https://www.adamdurica.com/wp-content/uploads/2019/04/album_adam_durica_mandolina-400x400.jpg",
                Rating = 9.7f,
                Genre = MusicGenre.Metal,
                Description = "Without word one of the best metal groups."
            };


            var returnedInterpret = _testContext.Interprets
                .Include(x => x.MemberList)
                .Include(x=> x.FestivalInterpret)
                    .ThenInclude(x=> x.Festival)
                .Include(x => x.StageInterpret)
                    .ThenInclude(x => x.Stage)
                .First(x => x.Id == interpret.Id);

            Assert.Equal(interpret.Id, returnedInterpret.Id);

        }

        [Fact]
        public void Festival_GetById()
        {
            var festival = new FestivalEntity()
            {
                Id = Guid.Parse("46abef51-c53f-4cc5-a270-a2756ef1455e"),
                Capacity = 1500,
                Name = "Grape",
                City = "Piestany",
                Street = "Letiskova 123",
                Country = "Slovakia",
                Description = "One of the best festivals in Slovakia!",
                StartTime = new DateTime(2020, 7, 25),
                EndTime = new DateTime(2020, 7, 23),
                Genre = MusicGenre.Rock,
                Price = 55,
            };


            var returnedFestival = _testContext.Festivals
                .Include(x => x.StageList)
                    .ThenInclude(x => x.StageInterpret)
                .Include(x => x.FestivalInterpret)
                    .ThenInclude(x => x.Interpret)
                .First(x => x.Id == festival.Id);

            Assert.Equal(festival.Id, returnedFestival.Id);

        }

       

        public void Dispose() => _testContext.Dispose();
      
    }
}
