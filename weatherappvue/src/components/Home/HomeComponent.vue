<template>
  <div>
    <div class="row">
      <div class="col-sm-12 col-md-6 offset-md-3 col-lg-6 lg-offset-3">
        <search-component :searchInput="this.selectedCity.name" @selection-cleared="setSelectedCity('')" 
          @city-selected="setSelectedCity($event)"></search-component>
      </div>
    </div>
    <div class="row" v-show="selectedCity">
      <div class="col-sm-12 col-md-6 offset-md-3 col-lg-6 lg-offset-3">
        <weather-overview v-bind:city="selectedCity" @weather-data-fetched="persistCurrentWeather"></weather-overview>
      </div>
    </div>
    <!-- <footer class="fixed-bottom"> -->
      <div class="row" v-show="searchHistory && searchHistory.length">
        <div class="col-sm-12 col-md-6 offset-md-3 col-lg-6 lg-offset-3">
          <history-component :limit="2" v-bind:searchHistory="this.searchHistory" @clear-history-requested="clearHistory"></history-component>
        </div>
      </div>
    <!-- </footer> -->
  </div>
</template>

<script>
import SearchComponent from '../Search/SearchComponent'
import HistoryComponent from '../History/HistoryComponent'
import WeatherOverview from '../Detail/WeatherOverview'
import { storage } from '@/storage'

export default {
  name: 'HomeComponent',
  mixins: [storage],
  components: { SearchComponent, WeatherOverview, HistoryComponent },
  data() {
    return {
      searchInput: '',
      cities: [],
      selectedCity: ''
    };
  },
  mounted() {
    this.initLocalStorage();
  },
  methods: {
    setSelectedCity: function(city){
      this.selectedCity = city;
    },    
  },
};
</script>

<style>
footer {
    position: fixed;
    bottom: 0;
}
</style>