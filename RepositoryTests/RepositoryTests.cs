using System.Data.Entity;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Repository;

namespace RepositoryTests
{
    [TestFixture]
    public class WhenUsingRepositoryOfTypeT
    {
        private Repository.Repository sut;
        private IDbConctext dbContext;

        [SetUp]
        public void Given()
        {
            var dbSet = new FakeDbSet<MyEntity>();
            MyEntity[] myEntities = { new MyEntity { Id = 1 }, new MyEntity { Id = 2 } };
            myEntities.ToList().ForEach(me => dbSet.Add(me));

            dbContext = A.Fake<IDbConctext>();
            A.CallTo(() => dbContext.Set<MyEntity>()).Returns(dbSet);

            sut = new Repository.Repository(dbContext);
        }

        [Test]
        public void GetAllReturnsAllEntitiesOfTypeT()
        {
            var result = sut.GetAll<MyEntity>();
            result.Select( me => me.Id).ShouldBeEquivalentTo( new [] {1, 2});
        }

        [Test]
        public void GetByIdReturnsTheCorrectInstance()
        {
            var result = sut.GetById<MyEntity>(1);
            result.Id.Should().Be(1);
        }

        [Test]
        public void SaveChangesCallsDbContextSaveChanges()
        {
            sut.SaveChanges();
            A.CallTo(() => dbContext.SaveChanges()).MustHaveHappened(Repeated.Exactly.Once);
        }

        class MyEntity : IHaveId
        {
            public int Id { get; set; }
        }
    }
}
