<template>
  <div id="app">
    <div class="row">
      <div class="col-sm"></div>
      <div class="col-sm">
        <search-component @input="setCurrentInput($event)" @backspace="setCurrentInput('')" :searchInput="this.selectedCity.name"></search-component>
      </div>
      <div class="col-sm"></div>
    </div>
    <div class="row" v-if="!selectedCity">
      <div class="col-sm-4"></div>
      <div class="col-sm-4">      
      <ul>
        <search-result-item 
          v-for="f in filteredCities" :key="f.id" :city="f" 
          @city-selected="selectedCity=$event">
        </search-result-item>
      </ul>
      </div>
    </div>
    <div class="row" v-show="selectedCity">
       <div class="col-sm-4"></div>
      <div class="col-sm-4 col-sm-offset-4">
        <weather-overview v-bind:city="selectedCity" @weather-data-fetched="persistCurrentWeather"></weather-overview>
      </div>
    </div>
    <div class="row" v-show="searchHistory && searchHistory.length">
       <div class="col-sm-4"></div>
      <div class="col-sm-4 col-sm-offset-4">
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
import SearchResultItem from "./components/Search/SearchResultItem";

export default {
  name: "app",
  components: { SearchComponent, WeatherOverview, HistoryComponent, SearchResultItem },
  data() {
    return {
      searchInput: "",
      cities: [],
      selectedCity: "",
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
    getCities: function(){
      var app = this;
      HTTP.get(`/locations/getcities?input=${this.searchInput}`)
        .then(response => {
          app.cities = response.data;
        })
        .catch(e => {
          app.console.log(e);
        });
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
    setCurrentInput(input) {
      this.searchInput = input;
      if (this.selectedCity) {
        this.selectedCity = '';
        this.cities = [];
        return;
      }

      if (!this.searchInput || this.searchInput.length < 2) 
        return;

      this.getCities();
    },
  },
  computed: {
    filteredCities: function(){
      return this.$options.filters.unique(this.cities, 'name').slice(0, 15);
    }
  }
};
</script>