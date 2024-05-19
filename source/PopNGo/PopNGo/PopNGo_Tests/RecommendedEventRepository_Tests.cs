using Moq;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PopNGo.DAL.Concrete;
using PopNGo.DAL.Abstract;
using PopNGo.Models;
using System.Collections.Generic;

namespace PopNGo_Tests;

public class RecommendedEventRepositoryTests
{
    private static readonly string _seedFile = @"../../../Sql/SEED.sql";  // relative path from where the executable is: bin/Debug/net7.0
    private static readonly InMemoryDbHelper<PopNGoDB> _dbHelper = new(_seedFile, DbPersistence.OneDbPerTest);
    private static RecommendedEventRepository _recommendedEventRepository = null!;
    private static PopNGoDB _context = null!;

    [SetUp]
    public void Setup()
    {
        _context = _dbHelper.GetContext();
        _recommendedEventRepository = new RecommendedEventRepository(_context);
    }

    [Test]
    public void GetRecommendedEvents_ShouldReturnEvents()
    {
        // Arrange
        var userId = 1;
        var event1 = new RecommendedEvent { Id = 1, UserId = userId, EventId = 1 };
        var event2 = new RecommendedEvent { Id = 2, UserId = userId, EventId = 2 };
        var event3 = new RecommendedEvent { Id = 3, UserId = userId, EventId = 3 };
        _context.RecommendedEvents.AddRange(event1, event2, event3);
        _context.SaveChanges();

        // Act
        var result = _recommendedEventRepository.GetRecommendedEvents(userId);

        // Assert
        Assert.That(result.Count, Is.EqualTo(3));
        Assert.That(result[0].Id, Is.EqualTo(1));
        Assert.That(result[1].Id, Is.EqualTo(2));
        Assert.That(result[2].Id, Is.EqualTo(3));
    }

    [Test]
    public void SetRecommendedEvents_ShouldSetEvents()
    {
        // Arrange
        var userId = 1;
        var eventIds = new List<int> { 1, 2, 3 };

        // Act
        _recommendedEventRepository.SetRecommendedEvents(userId, eventIds);

        // Assert
        var result = _context.RecommendedEvents.ToList();
        Assert.That(result.Count, Is.EqualTo(3));
        Assert.That(result[0].UserId, Is.EqualTo(userId));
        Assert.That(result[0].EventId, Is.EqualTo(1));
        Assert.That(result[1].UserId, Is.EqualTo(userId));
        Assert.That(result[1].EventId, Is.EqualTo(2));
        Assert.That(result[2].UserId, Is.EqualTo(userId));
        Assert.That(result[2].EventId, Is.EqualTo(3));
    }
}
