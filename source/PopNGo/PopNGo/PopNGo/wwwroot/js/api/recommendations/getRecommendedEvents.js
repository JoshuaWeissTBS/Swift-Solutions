/**
 * Returns list of recommended events
 * @async
 * @function getRecommendedEvents
 * @param {string} location - location of the user 'City, State, Country'
 * @returns {Promise<Array<object>>}
 */
export async function getRecommendedEvents(location) {
  // let res = await fetch(`/api/RecommendationsApi/RecommendedEvents?location=${location}`)
  // return await res.json();

  // Mock data
  let mock = [
    {
      "apiEventID": "L2F1dGhvcml0eS9ob3Jpem9uL2NsdXN0ZXJlZF9ldmVudC8yMDI0LTA2LTA4fDE1NjMzODg1NzUxODQ4ODkxNzQw",
      "eventDate": "2024-06-08T07:00:00",
      "eventName": "NWGolfGuys - Senior and Ladies Club Championship — Pacific Northwest Golf Tournaments",
      "eventDescription": null,
      "eventLocation": "155 Northwest Country Club Lane, Albany, OR 97321, United States",
      "eventImage": "http://static1.squarespace.com/static/55f10ca1e4b037162e39b30c/5b580ae3f950b76718ac37bb/65af59599b832b38ffaeb1c8/1705990630873/NW-Golf-Guys-Logo.png?format=1500w",
      "eventOriginalLink": "https://www.pnwgolftournaments.com/adult-golf-tournaments/nwgolfguys-senior-and-ladies-club-championship",
      "latitude": 44.660706,
      "longitude": -123.103806,
      "latitude": 44.983345,
      "longitude": -123.313390,
      "venuePhoneNumber": "+15419266059",
      "venueName": "Albany Golf & Event Center / Spring Hill Golf Club",
      "venueRating": 4.3,
      "venueWebsite": "http://www.albany-golf.com/"
    },
    {
      "apiEventID": "l2F1dGhvcml0eS9ob3Jpem9uL2NsdXN0ZXJlZF9ldmVudC8yMDI0LTA2LTIxfDE3NDk5NTkwODQ4NzgyMjM0NTk2",
      "eventDate": "2024-06-21T07:30:00",
      "eventName": "3rd Annual Golf Tournament",
      "eventDescription": "Play golf and support Dallas community service projects & student scholarships. 2-Person scramble - 7:30 a.m. shotgun start. $100 per person includes green fees, shared cart, range balls, lunch & more. Charity tournament hosted by Dallas Rotary club. June 7 sign-up deadline.",
      "eventLocation": "13935 Oregon 22, Dallas, OR 97338, United States",
      "eventImage": "https://cdn-az.allevents.in/events7/banners/eff120a651538cf7b2555908b07aee0419757dd1f19e38dd1cda6a94222201ad-rimg-w1200-h927-dcffffff-gmir?v=1716242968",
      "eventOriginalLink": "https://allevents.in/dallas/dallas-rotary-golf-tournament/200026547724329",
      "latitude": 44.983345,
      "longitude": -123.313390,
      "tags": [],
      "ticketLinks": [],
      "venuePhoneNumber": "+15036236666",
      "venueName": "Cross Creek Golf Course",
      "venueRating": 4.5,
      "venueWebsite": "http://crosscreekgc.com/"
    },
    {
      "apiEventID": "l2F1dGhvcml0eS9ob3Jpem9uL2NsdXN0ZXJlZF9ldmVudC8yMDI0LTA4LTA1fDQ0NjIxNzEyNjk0MTMwOTA4ODA=",
      "eventDate": "2024-08-05T16:00:00",
      "eventName": "Mstar Kids Sports Camp",
      "eventDescription": "Choose from soccer, basketball, cheer, flag football, disc golf or kickstart for preschoolers!\nAvailable for kids 4 years old through entering 5th grade!\nCheck out the link for early bird pricing and registration. Limited spots per sport available!",
      "eventLocation": "4775 27th Avenue Southeast, Salem, OR 97302, United States",
      "eventImage": "https://cdn-az.allevents.in/events6/banners/b38d3bd4b343d1fa0786d943660772c7be97567989905288b1892679792b53c0-rimg-w1200-h675-dc019576-gmir?v=1715133032",
      "eventOriginalLink": "https://allevents.in/salem/mstar-kids-sports-camp/200026492422233",
      "latitude": 44.886963,
      "longitude": -123.007520,
      "venuePhoneNumber": null,
      "venueName": null,
      "venueRating": 0.0,
      "venueWebsite": null
    },
    {
      "apiEventID": "l2F1dGhvcml0eS9ob3Jpem9uL2NsdXN0ZXJlZF9ldmVudC8yMDI0LTA3LTExfF8zMTg0MDcyODk1NTA5NjM1Njcz",
      "eventDate": "2024-07-12T00:00:00",
      "eventName": "Breakthrough Basketball Essential Skills Camp",
      "eventDescription": "Breakthrough Basketball conducts quality, high-intensity, drill based camps that focus on not only bettering a players skill set on the court but also building character and confidence off the court. These camps will strengthen your athletes mentality while boosting their confidence to become more aggressive and skilled players. Our camps will provide a focused, fun learning environment that cannot be rivaled.",
      "eventLocation": "4050 Fairview Industrial Drive Southeast #100, Salem, OR 97302, United States",
      "eventImage": "https://www.breakthroughbasketball.com/camps/graphics/googleeventimage.png",
      "eventOriginalLink": "https://www.breakthroughbasketball.com/camps/camp.asp?name=SalemORCamp1",
      "latitude": 44.895367,
      "longitude": -122.999150,
      "tags": [],
      "ticketLinks": [],
      "venuePhoneNumber": "+15033851923",
      "venueName": "NPJ Sports Complex",
      "venueRating": 3.5,
      "venueWebsite": "http://www.npjsportscomplex.com/"
    },
  ];

  return mock;
}
