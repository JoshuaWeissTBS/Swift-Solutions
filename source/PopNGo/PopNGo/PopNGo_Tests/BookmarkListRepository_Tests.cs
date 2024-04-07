using Moq;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PopNGo.DAL.Concrete;
using PopNGo.DAL.Abstract;
using PopNGo.Models;
using System.Collections.Generic;

namespace PopNGo_Tests;

public class BookMarkRepositoryTests
{
    private static readonly string _seedFile = @"..\..\..\..\PopNGo\Data\Scripts\Testing\SEED.sql";  // relative path from where the executable is: bin/Debug/net7.0

    // Create this helper like this, for whatever context you desire
    private static readonly InMemoryDbHelper<PopNGoDB> _dbHelper = new(_seedFile, DbPersistence.OneDbPerTest);
    private static BookmarkListRepository _bookmarkListRepository = null!;
    private static PopNGoDB _context = null!;

    [SetUp]
    public void Setup()
    {
        _context = _dbHelper.GetContext();
        _bookmarkListRepository = new BookmarkListRepository(_context);
    }
    [Test]
    public void GetBookmarkLists_ShouldReturnBookmarkLists()
    {
        // Arrange
        var userId = 1;

        // Act
        var result = _bookmarkListRepository.GetBookmarkLists(userId);

        // Assert that the result is not null and is of type List<BookmarkList>
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<List<BookmarkList>>());
    }


    [Test]
    public void AddBookmarkList_ShouldAddNewBookmarkList()
    {
        // Arrange
        var userId = 1;
        var listName = "Test List";

        // Act
        _bookmarkListRepository.AddBookmarkList(userId, listName);

        // Assert
        // Assumes there is already a bookmark list in the database
        Assert.That(_bookmarkListRepository.GetBookmarkLists(userId).Count, Is.EqualTo(2));
        Assert.That(_bookmarkListRepository.GetBookmarkLists(userId).Last().Title, Is.EqualTo(listName));
    }

    [Test]
    public void AddBookmarkList_ShouldThrowExceptionWhenListNameIsNull()
    {
        // Arrange
        var userId = 1;
        var listName = "";

        // Assert
        Assert.Throws<ArgumentNullException>(() => _bookmarkListRepository.AddBookmarkList(userId, listName));
    }

    [Test]
    public void AddBookmarkList_ShouldThrowExceptionWhenListNameIsDuplicate()
    {
        // Arrange
        var userId = 1;
        var listName = "Test List";

        // Act
        _bookmarkListRepository.AddBookmarkList(userId, listName);

        // Assert
        Assert.Throws<ArgumentException>(() => _bookmarkListRepository.AddBookmarkList(userId, listName));
    }

    [Test]
    public void GetBookmarkListIdFromName_ShouldReturnListId()
    {
        // Arrange
        var userId = 1;
        var listName = "Wishlist events :)";

        // Act, assuming there is a bookmarkList seeded with the name 'Wishlist events :)'
        var result = _bookmarkListRepository.GetBookmarkListIdFromName(userId, listName);

        // Assert
        Assert.That(result, Is.EqualTo(1));
    }
    /*

    public void GetBookmarkListIdFromName_ShouldThrowExceptionWhenListNameIsNull()
    {
        // Arrange
        var userId = 1;
        var listName = "";

        // Act
        // Assert
        Assert.Throws<ArgumentNullException>(() => _bookmarkRepository.GetBookmarkListIdFromName(userId, listName));
    }

    public void GetBookmarkListIdFromName_ShouldThrowExceptionWhenListNameIsNotFound()
    {
        // Arrange
        var userId = 1;
        var listName = "Test List";

        // Act
        // Assert
        Assert.Throws<ArgumentException>(() => _bookmarkRepository.GetBookmarkListIdFromName(userId, listName));
    }

    // Stub test for AddEventToBookmarkList
    public void AddEventToBookmarkList_ShouldAddEventToBookmarkList()
    {
        // Arrange
        var userId = 1;
        var listId = 1;
        var eventId = "testEventId";

        // Act
        _bookmarkRepository.AddEventToBookmarkList(userId, listId, eventId);

        // Assert
        Assert.That(_bookmarkRepository.GetBookmarkLists(userId).First().Events.Count, Is.EqualTo(1));
        // Assert that new event is added to the list
        Assert.That(_bookmarkRepository.GetBookmarkLists(userId).First().Events.First().ApiEventId, Is.EqualTo(eventId));
        // Assert that bookmark list has its quantity of events increased by 1
        Assert.That(_bookmarkRepository.GetBookmarkLists(userId).First().Quantity, Is.EqualTo(1));
    }*/
}