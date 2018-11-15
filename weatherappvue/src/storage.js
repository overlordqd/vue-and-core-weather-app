const localStorageKey = 'search-history';

export const storage = {
  data() {
    return {
      searchHistory: [],
      selectedCity: Object
    }
  },
  methods: {
    initLocalStorage() {
      if (localStorage.getItem(localStorageKey)) {
        try {
          this.searchHistory = JSON.parse(localStorage.getItem(localStorageKey));
        } catch (e) {
          localStorage.removeItem(localStorageKey);
        }
      }
    },
    persistCurrentWeather(currentWeatherData) {
      if(!this.searchHistory || !this.searchHistory.some(i => { return i.city.name === this.selectedCity.name; })){
        this.searchHistory.push({ city: this.selectedCity, weather: currentWeatherData, lastAccessed: new Date().toISOString() }); 
      }
      else {
        var persistedDataIndex = this.searchHistory.findIndex(i => { return i.city.name == this.selectedCity.name; });
        this.searchHistory[persistedDataIndex].weather = currentWeatherData;
        this.searchHistory[persistedDataIndex].lastAccessed = new Date().toISOString();
      }

      const parsed = JSON.stringify(this.searchHistory);
      localStorage.setItem(localStorageKey, parsed);
    },
    clearHistory(){
      this.searchHistory = [];
      localStorage.removeItem(localStorageKey);
    },
  }
}