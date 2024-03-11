// Props object example:
// {
//     img: String link,
//     title: String,
//     date: DateTime,
//     city: String,
//     state: String,
//     favorited: Boolean
//     tags: Array[String],
// }

/**
 * Takes in the event card element and the event info props and updates the event card element
 * Props:
{
     img: String link,
     title: String,
     date: DateTime,
     city: String,
     state: String,
     favorited: Boolean
     tags: Array[String],
 }
 * @param {HTMLElement} eventCardElement 
 * @param {Object} props 
 */

export const buildEventCard = (eventCardElement, props) => {
    // Set the image
    if (props.img === null || props.img === undefined) {
        eventCardElement.querySelector('#event-card-image').src = '/media/images/placeholder_event_card_image.png';
    } else {
        eventCardElement.querySelector('#event-card-image').src = props.img;
    }

    // Set the title
    eventCardElement.querySelector('#event-card-title').textContent = props.title;

    // Set the date
    eventCardElement.querySelector('#day-number').textContent = props.date.getDate();
    eventCardElement.querySelector('#month').textContent = props.date.toLocaleString('default', { month: 'short' });

    // Set the location
    eventCardElement.querySelector('#event-card-location').textContent = `${props.city}, ${props.state}`;

    // Set the favorite status
    const heart = eventCardElement.querySelector('#bookmark-container');
    heart.src = props.favorited ? '/media/images/heart-filled.svg' : '/media/images/heart-outline.svg';

    heart.addEventListener('click', () => {
        // Update the favorite status and the image source
        props.favorited = !props.favorited;
        heart.src = props.favorited ? '/media/images/heart-filled.svg' : '/media/images/heart-outline.svg';
    });

    // TODO: Set the tags
/*    const tagsContainer = eventCardElement.querySelector('#eventCardTags');
    tagsContainer.innerHTML = '';
    props.tags.forEach(tag => {
        const tagEl = document.createElement('span');
        tagEl.classList.add('tag');
        tagEl.textContent = tag;
        tagsContainer.appendChild(tagEl);
    });*/
 
}