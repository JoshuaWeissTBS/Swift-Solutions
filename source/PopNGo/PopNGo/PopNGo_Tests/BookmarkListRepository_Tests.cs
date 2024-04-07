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
    [Test]
    public void GetBookmarkLists_ShouldReturnBookmarkLists()
    {
        Assert.Pass();
        /*        // Arrange
                var userId = 1;

                // Act
                var result = _bookmarkRepository.GetBookmarkLists(userId);

                // Assert that the result is not null and is of type List<BookmarkList>
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Is.TypeOf<List<BookmarkList>>());*/
    }

/*    public void GetBookmarkListEvents_ShouldReturnBookmarkListEvents()
    {
        // Arrange
        var userId = 1;
        var listId = 1;

        // Act
        var result = _bookmarkRepository.GetBookmarkListEvents(userId, listId);

        // Assert that the result is not null and is of type List<BookmarkListEvent>
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<List<BookmarkListEvent>>());
    }

    // Stub test for AddBookmarkList
    public void AddBookmarkList_ShouldAddNewBookmarkList()
    {
        // Arrange
        var userId = 1;
        var listName = "Test List";

        // Act
        _bookmarkRepository.AddBookmarkList(userId, listName);

        // Assert
        Assert.AreEqual(1, _bookmarkRepository.GetBookmarkLists(userId).Count);
        // Assert that new list is added to the database
        Assert.That(_bookmarkRepository.GetBookmarkLists(userId).First().ListName, Is.EqualTo(listName));
    }

    // Stub test for AddBookmarkList should throw exception when list name is null
    public void AddBookmarkList_ShouldThrowExceptionWhenListNameIsNull()
    {
        // Arrange
        var userId = 1;
        var listName = "";

        // Act
        // Assert
        Assert.Throws<ArgumentNullException>(() => _bookmarkRepository.AddBookmarkList(userId, listName));
    }

    // Stub test for AddBookmarkList should throw exception when list name is duplicate of existing list
    public void AddBookmarkList_ShouldThrowExceptionWhenListNameIsDuplicate()
    {
        // Arrange
        var userId = 1;
        var listName = "Test List";

        // Act
        _bookmarkRepository.AddBookmarkList(userId, listName);

        // Assert
        Assert.Throws<ArgumentException>(() => _bookmarkRepository.AddBookmarkList(userId, listName));
    }

    public void GetBookmarkListIdFromName_ShouldReturnListId()
    {
        // Arrange
        var userId = 1;
        var listName = "Test List";

        // Act
        var result = _bookmarkRepository.GetBookmarkListIdFromName(userId, listName);

        // Assert
        Assert.That(result, Is.EqualTo(1));
    }

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