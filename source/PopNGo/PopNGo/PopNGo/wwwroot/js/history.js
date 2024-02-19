// Purpose: Contains the javascript functions for the history page.

// Fetch event data and display it on page load
document.addEventListener('DOMContentLoaded', function () {
    console.log("History page loaded.")
    fetchAndDisplayEvents();
});

/*
constructEventCard creates a html element based on the event object passed to it into this template:
<template id="event-card-template">
    <div class="row text-dark mb-3">
        <div class="col-12">
            <div class="card border-0">
                <div class="card-body" id="event-card-body">
                    <h5 class="card-title" id="event-name">Event Name</h5>
                    <p class="card-text" id="event-description">Event Description</p>
                    <p class="card-text" id="event-datetime">Event Date and time</p>
                    <p class="card-text" id="event-location">Event Location</p>
                </div>
            </div>
        </div>
    </div>
</template>*/
function constructEventCard(event) {
    const template = document.getElementById('event-card-template');
    const eventCard = template.content.cloneNode(true);
    eventCard.querySelector('#event-name').textContent = event.eventName || 'Event Name Not Available';
    eventCard.querySelector('#event-description').textContent = event.eventDescription || 'No description available.';
    eventCard.querySelector('#event-datetime').textContent = `Start: ${event.eventStartTime || 'Unknown Start Time'}, End: ${event.eventEndTime || 'Unknown End Time'}`;
    eventCard.querySelector('#event-location').textContent = event.full_Address || 'Location information not available';
    return eventCard;
}

// Append event cards to the container element
function displayEvents(events) {
    const container = document.getElementById('event-history-card-container');
    if (!container) {
        console.error('Container element #event-history-card-container not found.');
        return;
    }

    // Clear the container
    container.innerHTML = '';

    // Append event cards to the container
    events.forEach(event => {
        const eventCard = constructEventCard(event);
        container.appendChild(eventCard);
    });
}

// Fetch event data and display it
async function fetchAndDisplayEvents() {
    let data = []

    fetch("/api/eventHistory").then(response => response.json())
        .then(data => displayEvents(data))
        .catch(error => console.error('Error fetching event data:', error));

    console.log(response)

    // Temporary data until backend is implemented
    data = [
        {
            "eventName": "Event 1",
            "eventDescription": "This is the first event.",
            "eventStartTime": "2021-01-01T00:00:00",
            "eventEndTime": "2021-01-01T23:59:59",
            "full_Address": "123 Main St, Springfield, IL 62701",
        },
        {
            "eventName": "Event 2",
            "eventDescription": "This is the second event.",
            "eventStartTime": "2021-01-02T00:00:00",
            "eventEndTime": "2021-01-02T23:59:59",
            "full_Address": "456 Elm St, Springfield, IL 62702",
        }
    ];

    displayEvents(data);
}