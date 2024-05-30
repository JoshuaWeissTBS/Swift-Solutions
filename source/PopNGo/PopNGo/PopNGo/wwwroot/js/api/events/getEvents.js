/**
 * Purpose: Fetches event data from the server based on query string.
 * 
 * Query string is the search term that the user enters in the search bar,
 * just like searching on Google. Example: "Sports events in Monmouth, Oregon"
 * 
 * Start is the index of the first event to return. This is used for pagination.
 * @async
 * @function getEvents
 * @param {string} query
 * @param {number} start - The index of the first event to return
 * @returns {Object[]}
 */
export async function getEvents(query, start, date = null) {
    // let endpoint = `/api/search/events?q=${query}&start=${start}`;

    // if (date !== null) {
    //     endpoint += `&date=${date}`;
    // }
    // try {
    //     const response = await fetch(endpoint);
    //     if (!response.ok) {
    //         throw new Error('Network response was not ok');
    //     }
    //     return await response.json();
    // } catch (error) {
    //     console.error('There was a problem with the fetch operation:', error);
    //     throw error;
    // }

    // Mock data
    let events = [
        {
            "apiEventID": "L2F1dGhvcml0eS9ob3Jpem9uL2NsdXN0ZXJlZF9ldmVudC8yMDI0LTA4LTE0fF8xNTIwOTEwMzA3NDc2NTU2NTcxNA==",
            "eventImage": "http://static1.squarespace.com/static/55f10ca1e4b037162e39b30c/5b580ae3f950b76718ac37bb/5e23c29f6570d54754b4688d/1706496590221/OGA+Logo.jpg?format=1500w",
            "eventName": "OGA Tour - Individual Series - Creekside — Pacific Northwest Golf Tournaments",
            "eventDate": "2024-08-14T12:00:00",
            "eventLocation": "6250 Club House Drive Southeast, Salem, OR 97306, United States",
            "eventDescription": null,
            "eventOriginalLink": "https://www.pnwgolftournaments.com/adult-golf-tournaments/oga-tour-individual-series-creekside",
            "latitude": 44.864925,
            "longitude": -123.042870,
            "venuePhoneNumber": "+15033634653",
            "tags": [],
            "ticketLinks": [],
            "venueName": "Creekside Golf Club",
            "venueRating": 4.7,
            "venueWebsite": "https://www.golfcreekside.com/"
        },
        {
            "apiEventID": "L2F1dGhvcml0eS9ob3Jpem9uL2NsdXN0ZXJlZF9ldmVudC8yMDI0LTA2LTA1fDU0Mzk0ODMyODIxMDA3NTQ0MTc=",
            "eventDate": "2024-06-05T11:45:00",
            "eventName": "KNOW June Luncheon",
            "eventDescription": null,
            "eventLocation": "155 McNary Estates Drive North, Keizer, OR 97303, United States",
            "eventImage": null,
            "eventOriginalLink": "https://cm.keizerchamber.com/events/details/know-may-luncheon-28831",
            "latitude": 45.012234,
            "longitude": -123.023796,
            "venuePhoneNumber": "+15033934653",
            "venueName": "McNary Golf Club",
            "venueRating": 4.3,
            "venueWebsite": "http://mcnarygolfclub.com/",
            "tags": [],
            "ticketLinks": [],
        },
        {
            "apiEventID": "L2F1dGhvcml0eS9ob3Jpem9uL2NsdXN0ZXJlZF9ldmVudC8yMDI0LTA3LTEzfDE1NDA0NzczNTA5ODU5NDk1NDcx",
            "eventDate": "2024-07-13T07:00:00",
            "eventName": "Oregon Parent-Child Chapman Tournament",
            "eventDescription": "Entries are open to Grandparent, Parent and Child\n(including in-laws)\nteams, at least one of whom must be an amateur in\ngood standing of\nan OGA Member Club. The format is 18-hole\nChapman stroke play. Each player plays a shot\nfrom the teeing ground and each plays their\npartner’s ball for the\nsecond shot. After the second shot, partners select\nthe ball with which\nthey wish to score, and play that ball alternately to\ncomplete the hole.\nEach team plays either Saturday or Sunday. Team\nhandicaps are\ncalculated using 60% of the low handicap plus 40%\nof the higher\nhandicap and is applied at the end of the round.",
            "eventLocation": "2025 Golf Course Road South, Salem, OR 97302, United States",
            "eventImage": "https://www.amateurgolf.com/images/uploads/00007167.jpg",
            "eventOriginalLink": "https://www.amateurgolf.com/amateur-golf-tournaments/789/Oregon-Parent-Child-Chapman-Tournament",
            "latitude": 44.913010,
            "longitude": -123.071800,
            "venuePhoneNumber": "+15033636652",
            "venueName": "Salem Golf Club",
            "venueRating": 4.4,
            "tags": [],
            "ticketLinks": [],
            "venueWebsite": "https://www.salemgolfclub.com/"
        },
        {
            "apiEventID": "L2F1dGhvcml0eS9ob3Jpem9uL2NsdXN0ZXJlZF9ldmVudC8yMDI0LTA1LTMxfDE0NzMwMzY0Mzc1MTAyOTEwNzMy",
            "eventDate": "2024-05-31T04:00:00",
            "eventName": "Friday Night Buckets Series",
            "eventDescription": null,
            "eventLocation": "4050 Fairview Industrial Drive Southeast #100, Salem, OR 97302, United States",
            "eventImage": "https://cdn.exposureevents.com/assets/files/png/286657?v=50395047&w=300&h=200",
            "eventOriginalLink": "https://basketball.exposureevents.com/222243/friday-night-buckets-series",
            "latitude": 44.895367,
            "longitude": -122.999150,
            "venuePhoneNumber": "+15033851923",
            "venueName": "NPJ Sports Complex",
            "venueRating": 3.5,
            "tags": [],
            "ticketLinks": [],
            "venueWebsite": "http://www.npjsportscomplex.com/"
        },
        {
            "apiEventID": "l2F1dGhvcml0eS9ob3Jpem9uL2NsdXN0ZXJlZF9ldmVudC8yMDI0LTA1LTAzfDEwODIwNjc5NzUxOTA4MjIwODEw",
            "eventDate": "2024-05-03T09:00:00",
            "eventName": "Schreiner's Garden 2024 Bloom Season Event",
            "eventDescription": "Join Schreiner's Gardens for our annual Bloom Season from May 10-31, 2024.",
            "eventLocation": "3625 Quinaby Road Northeast, Salem, OR 97303, United States",
            "eventImage": "https://travel-salem.imgix.net/images/Schreiners-Gardens_2024-Bloom-Season_Wandering-Display-Garden.jpg?auto=compress%2Cformat&fit=max&h=1080&q=80&w=1920&s=919236c12a9f28d5eef1db1cabb8062f",
            "eventOriginalLink": "https://www.hope1079.com/events/event/schreiners-garden-2024-bloom-season-event/",
            "latitude": 45.035360,
            "longitude": -122.988270,
            "tags": [],
            "ticketLinks": [],
            "venuePhoneNumber": "+15033933232",
            "venueName": "Schreiner's Gardens",
            "venueRating": 4.8,
            "venueWebsite": "http://www.schreinersgardens.com/"
          },
          {
            "apiEventID": "l2F1dGhvcml0eS9ob3Jpem9uL2NsdXN0ZXJlZF9ldmVudC8yMDI0LTA1LTI4fDMwODYxMjgwNDE3MDI0MDYzMzk=",
            "eventDate": "2024-05-28T07:30:00",
            "eventName": "Marion County Commissioner's Breakfast",
            "eventDescription": "This no-host breakfast gives you a chance to have a conversation with your Marion County commissioner. It is meant for community leaders to stay up to date on changes at the county and for the commissioners to learn what is happening in our community.",
            "eventLocation": "7760 3rd Street Southeast, Turner, OR 97392, United States",
            "eventImage": null,
            "eventOriginalLink": "http://business.staytonsublimitychamber.org/events/details/marion-county-commissioner-s-breakfast-05-28-2024-19096",
            "latitude": 44.842980,
            "longitude": -122.952390,
            "tags": [],
            "ticketLinks": [],
            "venuePhoneNumber": "+15037431285",
            "venueName": "Turnaround Cafe",
            "venueRating": 4.7,
            "venueWebsite": "http://www.turnaroundcafe.com/"
          },
          {
            "apiEventID": "l2F1dGhvcml0eS9ob3Jpem9uL2NsdXN0ZXJlZF9ldmVudC8yMDI0LTA1LTI4fDE1MTEyMzQ3NjY1MTAzMDEwNDQx",
            "eventDate": "2024-05-28T16:30:00",
            "eventName": "Kroc Teen Session — Project PEACE",
            "eventDescription": null,
            "eventLocation": "1865 Bill Frey Drive, Salem, OR 97301, United States",
            "eventImage": null,
            "eventOriginalLink": "https://www.projectpeace4teens.org/upcoming-trainings/2yxdfljflatpldt",
            "latitude": 44.975870,
            "longitude": -123.010155,
            "tags": [],
            "ticketLinks": [],
            "venuePhoneNumber": "+15035665762",
            "venueName": "The Kroc Center - Salem, OR",
            "venueRating": 3.7,
            "venueWebsite": "https://salem.kroccenter.org/"
          },
          {
            "apiEventID": "l2F1dGhvcml0eS9ob3Jpem9uL2NsdXN0ZXJlZF9ldmVudC8yMDI0LTA1LTI4fDE0MDY1NDA1NDc4MjcyMzk2MzU1",
            "eventDate": "2024-05-28T13:00:00",
            "eventName": "2024 Volunteering at Marion Polk Food Share",
            "eventDescription": "volunteer work at MPFS can vary with the donations, so the staff there will provide demos, instructions, and any needed equipment. Shift time is 1-3pm every fourth Tuesday of the […]",
            "eventLocation": "1660 Salem Industrial Drive Northeast, Salem, OR 97301, United States",
            "eventImage": null,
            "eventOriginalLink": "https://marioncomga.org/event/2024-volunteering-at-marion-polk-food-share/2024-05-28/",
            "latitude": 44.972360,
            "longitude": -123.009910,
            "tags": [],
            "ticketLinks": [],
            "venuePhoneNumber": "+15035813855",
            "venueName": "Marion Polk Food Share",
            "venueRating": 4.7,
            "venueWebsite": "https://www.marionpolkfoodshare.org/"
          },
          {
            "apiEventID": "l2F1dGhvcml0eS9ob3Jpem9uL2NsdXN0ZXJlZF9ldmVudC8yMDI0LTA2LTAyfDE3ODY1NjExODY0ODAzMjc4NjA0",
            "eventDate": "2024-06-02T15:00:00",
            "eventName": "eD DESMARTEAU is LIVE at the OLD ZEN BAR!",
            "eventDescription": "ed will delight you with his renditions of your favorite classic rock songs ranging from the 60’s to today, from such artists as; The Beatles, Eagles, Moody blues, James Taylor, Neil Young, Neil Diamond, Tom Petty, Bob Seger, John Denver, Eric Clapton, Jimmy Buffet, Gordon Lightfoot, Cat Stevens, Steve Miller, Johnny Cash, Toby Keith, and many more. He will also include a few originals. This is a fun interactive one man acoustic show, you won’t want to miss. Come sing along and get your dance on!       ",
            "eventLocation": "1115 Edgewater Street Northwest, Salem, OR 97304, United States",
            "eventImage": null,
            "eventOriginalLink": "https://www.facebook.com/events/old-zen-wine-bar/ed-desmarteau-is-live-at-the-old-zen-bar/1447934526078159/",
            "latitude": 44.941470,
            "longitude": -123.057040,
            "tags": [],
            "ticketLinks": [],
            "venuePhoneNumber": "+19713452760",
            "venueName": "Old Zen Wine Bar",
            "venueRating": 4.8,
            "venueWebsite": "https://www.oldzenwinebar.com/"
          },
          {
            "apiEventID": "l2F1dGhvcml0eS9ob3Jpem9uL2NsdXN0ZXJlZF9ldmVudC8yMDI0LTA1LTA5fDk2NTY5MjgwNzIyNjk1MzQ5NjQ=",
            "eventDate": "2024-05-30T19:00:00",
            "eventName": "Independence Men's 12 x 12 Study Group",
            "eventDescription": null,
            "eventLocation": "437 D Street, Independence, OR 97351, United States",
            "eventImage": null,
            "eventOriginalLink": "https://sober.com/aa-meeting/independence-mens-12-x-12-study-group/",
            "latitude": 44.850060,
            "longitude": -123.189390,
            "tags": [],
            "ticketLinks": [],
            "venuePhoneNumber": null,
            "venueName": null,
            "venueRating": 0.0,
            "venueWebsite": null
          },
    ]

    return events;
}

