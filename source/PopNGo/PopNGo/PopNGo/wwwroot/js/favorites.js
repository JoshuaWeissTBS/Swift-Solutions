import { getBookmarkLists } from './api/bookmarkLists/getBookmarkLists.js';
import { buildBookmarkListCard } from './ui/buildBookmarkListCard.js';
import { buildNewBookmarkListCard } from './ui/buildNewBookmarkListCard.js';

document.addEventListener('DOMContentLoaded', function () {
    initPage();
});

function initPage() {
    getBookmarkLists().then(bookmarkLists => {
        if (bookmarkLists.length === 0) {
            displayNoBookmarkListsMessage();
        } else {
            displayBookmarkLists(bookmarkLists);
        }
    }).catch((error) => {
        // If the user is not logged in, display a login prompt
        displayLoginPrompt();
    });
}

function displayLoginPrompt() {
    document.getElementById('favorite-events-title').style.display = 'none'; // Hide the title if the user is not logged in
    document.getElementById('login-prompt').style.display = 'block';
}

function displayNoBookmarkListsMessage() {
    document.getElementById('favorite-events-title').style.display = 'none';
    document.getElementById('no-favorites-message').style.display = 'block';
}

/// Displaying bookmark lists

/**
 * Returns populated bookmark list card element. Element partial must be defined in the HTML file.
 * @param {String} name
 * @param {Number} eventQuantity
 * @returns {HTMLElement}
 */
function createBookmarkListCard(name, eventQuantity) {
    const props = {
        bookmarkListName: name,
        eventQuantity: eventQuantity,
        onClick: () => {
            // If the user clicks on the bookmark list, display the events from that list
            displayEventsFromBookmarkList(name);
        }
    };

    // Select and clone the bookmark list card template
    const bookmarkListCardTemplate = document.getElementById('bookmark-list-card-template');
    const bookmarkListCard = bookmarkListCardTemplate.content.cloneNode(true);

    // Build the card
    buildBookmarkListCard(bookmarkListCard, props);

    return bookmarkListCard;
}

/**
 * Takes BookmarkList[] as from getBookmarkLists and displays them on screen
 * @param {BookmarkList[]} bookmarkLists
 */
function displayBookmarkLists(bookmarkLists) {
    // Select the bookmark list container
    const bookmarkListContainer = document.getElementById('bookmark-list-cards-container');

    // Clear the container
    bookmarkListContainer.innerHTML = '';

    // Create a card for each bookmark list
    bookmarkLists.forEach(bookmarkList => {
        try {
            const card = createBookmarkListCard(bookmarkList.title, bookmarkList.favoriteEventQuantity);
            bookmarkListContainer.appendChild(card);
        } catch (error) {
            console.error("Props for bookmark list card was invalid, skipping...")
        }
    });

    // Create and append the "Create new bookmark list" card
    const createNewBookmarkListCardTemplate = document.getElementById('create-new-bookmark-list-card-template');
    const createNewBookmarkListCard = createNewBookmarkListCardTemplate.content.cloneNode(true);
    buildNewBookmarkListCard(createNewBookmarkListCard, { onClickCreateBookmarkList: createNewBookmarkList });
    bookmarkListContainer.appendChild(createNewBookmarkListCard);
}

/// Happens on click of "Create new bookmark list" button
function createNewBookmarkList(bookmarkListName) {
    console.log(bookmarkListName);
}

/// Displaying events from a bookmark list
function displayEventsFromBookmarkList(bookmarkList) {
    // TODO:
}
