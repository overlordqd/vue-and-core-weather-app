<template>
  <div id="app" class="container">
    <div class="row">
      <div class="col-sm-12 col-md-6 offset-md-3 col-lg-6 lg-offset-3">
        <search-component :searchInput="this.selectedCity.name" @selection-cleared="setSelectedCity('')" 
          @city-selected="setSelectedCity($event)"></search-component>
      </div>
    </div>
    <div class="row" v-show="selectedCity">
      <div class="col-sm-12 col-md-6 offset-md-3">
        <weather-overview v-bind:city="selectedCity" @weather-data-fetched="persistCurrentWeather"></weather-overview>
      </div>
    </div>
    <div class="row" v-show="searchHistory && searchHistory.length">
      <div class="col-sm-12 col-md-6 offset-md-3">
        <history-component v-bind:searchHistory="this.searchHistory" @clear-history-requested="clearHistory"></history-component>
      </div>
    </div>
  </div>
</template>

<script>
import { HTTP } from "./http-common";
import SearchComponent from "./components/Search/SearchComponent";
import HistoryComponent from "./components/History/HistoryComponent";
import WeatherOverview from "./components/Detail/WeatherOverview";

export default {
  name: "app",
  components: { SearchComponent, WeatherOverview, HistoryComponent },
  data() {
    return {
      searchInput: '',
      cities: [],
      selectedCity: '',
      searchHistory: []
    };
  },
  mounted() {
    if (localStorage.getItem("search-history")) {
      try {
        this.searchHistory = JSON.parse(localStorage.getItem("search-history"));
      } catch (e) {
        localStorage.removeItem("search-history");
      }
    }
  },
  methods: {
    setSelectedCity: function(city){
      this.selectedCity = city;
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
      localStorage.setItem("search-history", parsed);
    },
    clearHistory(){
      this.searchHistory = [];
      localStorage.removeItem("search-history");
    },    
  },
};
</script>