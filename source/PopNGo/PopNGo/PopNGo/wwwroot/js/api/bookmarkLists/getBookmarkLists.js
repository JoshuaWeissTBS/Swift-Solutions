/**
 * Takes in an api event id and returns a boolean indicating if the event is favorited
 * 
 * BookmarkList example:
 * 
        id = Int
        title = String
        favoriteEvents = FavoriteEvent[]
        userId = int
 * }
 * 
 * @async
 * @function getBookmarkLists
 * @returns {Promise<BookmarkList[]>}
 */
export async function getBookmarkLists() {
    let res = await fetch(`/api/BookmarkListApi/BookmarkLists`)
    return await res.json();
}