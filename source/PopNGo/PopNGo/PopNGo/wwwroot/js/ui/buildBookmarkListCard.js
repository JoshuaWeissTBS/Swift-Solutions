import { validateObject } from "../validation.js";

/**
 * Takes in the the bookmark list card element and props and builds the card
 * Props:
{
    bookmarkListName: String,
    eventQuantity: Number,
    onClick: Function,
 }
 * @function buildEventCard
 * @param {HTMLElement} eventCardElement 
 * @param {Object} props 
 */
export const buildBookmarkListCard = (eventCardElement, props) => {
    if (!validateBuildBookmarkListCardProps(props)) {
        throw new Error('Invalid props');
    }

    const { bookmarkListName, eventQuantity, onClick } = props;

    // Set the bookmark list name
    eventCardElement.querySelector('.bookmarkListCardTitleText').textContent = bookmarkListName;

    // Set the event quantity
    eventCardElement.querySelector('.bookmarkListCardQuantityText').textContent = eventQuantity;

    // Add the event listener
    eventCardElement.addEventListener('click', onClick);
}


/**
 * Takes in the bookmark list card props and validates them
 * @param {any} data
 * @returns {boolean}
 */
export function validateBuildBookmarkListCardProps(data) {
    if (data === undefined || data === null) {
        return false;
    }

    const schema = {
        bookmarkListName: x => typeof x === 'string',
        eventQuantity: x => typeof x === 'number',
        onClick: x => (typeof x === 'function' || x === undefined || x === null),
    }

    return validateObject(data, schema).length === 0;
}
