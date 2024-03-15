
export async function getLocationCoords(country, state, city) {
    if(!country || !state || !city) return null;
    
    const getApiKeyResponse = await fetch('/api/MapApi/GetGeolocationApiKey');
    const apiKey = await getApiKeyResponse.text();
    if(!apiKey) return;
    
    try {
        const url = 'https://maps.googleapis.com/maps/api/geocode/json?';
        console.debug(`Looking for location: ${country}, ${state}, ${city}.`)
        const response = await fetch(`${url}components=country:${country}|administrative_area_level:${state}|locality:${city}&key=${apiKey}`);

        const data = await response.json();

        console.debug("Results, pre-processed: ", data.results);
        data.results = data.results.map(c => {
            if(c.types.find(t => /^[sublocality|locality|country]/.test(t)))
                return c;
        }).filter(entry => !!entry);

        return data.results[0].geometry?.location ?? null;
    } catch(error) {
        console.error('There was a problem with the fetch operation:', error);
        throw error;
    }
}