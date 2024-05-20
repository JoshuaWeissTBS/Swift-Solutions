/**
 * Returns list of recommended events
 * @async
 * @function getRecommendedEvents
 * @returns {Promise<object>}
 */
export async function getRecommendedEvents() {
  let res = await fetch(`/api/RecommendationsApi/RecommendedEvents`)
  return await res.json();
}
