<template>
  <div id="app">
    <div class="row">
      <div class="col-sm"></div>
      <div class="col-sm">
        <SearchComponent @input="setCurrentInput($event)" v-bind:searchInput="this.selectedCity"></SearchComponent>
      </div>
      <div class="col-sm"></div>
    </div>
    <div class="row" v-if="!selectedCity">
      <div class="col-sm-4"></div>
      <div class="col-sm-4">      
      <ul>
        <li v-for="f in $options.filters.unique(this.filteredCities, 'city').slice(0, 15)" v-bind:key="f.id">
          <a v-on:click="selectCity(f)">{{f.city}} {{f.zip}}</a>
        </li>
      </ul>
      </div>
    </div>
    <div class="row" v-show="selectedCity">
       <div class="col-sm-4"></div>
      <div class="col-sm-4 col-sm-offset-4">
        <CityDetail v-bind:city="selectedCity"></CityDetail>
      </div>
    </div>
    <div class="row" v-show="searchHistory">
       <div class="col-sm-4"></div>
      <div class="col-sm-4 col-sm-offset-4">
        <HistoryComponent v-bind:searchHistory="this.searchHistory"></HistoryComponent>
      </div>
    </div>
  </div>
</template>

<script>
import SearchComponent from "./components/Search/SearchComponent";
import HistoryComponent from "./components/History/HistoryComponent";
import CityDetail from "./components/Detail/CityDetail";
import { HTTP } from "./http-common";

export default {
  name: "app",
  components: { SearchComponent, CityDetail, HistoryComponent },
  data() {
    return {
      searchInput: "",
      filteredCities: [],
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
    saveToHistory() {
      const parsed = JSON.stringify(this.searchHistory);
      localStorage.setItem("search-history", parsed);
    },
    selectCity(city) {
      this.selectedCity = city;
      if (
        !this.searchHistory ||
        !this.searchHistory.some(i => {
          return i.city == city.city;
        })
      ) {
        this.searchHistory.push(city);
        this.saveToHistory();
      }
    },
    setCurrentInput(input) {
      this.searchInput = input;
      if (this.selectedCity) {
        this.selectedCity = "";
      }

      if (!this.searchInput || this.searchInput.length < 2) return;

      HTTP.get("/locations/getcities?input=" + this.searchInput)
        .then(response => {
          this.filteredCities = response.data;
        })
        .catch(e => {
          window.console.log(e);
        });
    }
  },
  computed: {
    isInputPostalCode() {
      if (!this.searchInput || this.searchInput.length < 2) return false;

      return RegExp(/^[0-9]+$/).test(this.searchInput);
    }    
  }
};
</script>

<style lang="scss">
</style>