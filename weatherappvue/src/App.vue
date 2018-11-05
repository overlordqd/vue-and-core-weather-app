<template>
  <div id="app">
    <div class="row">
      <div class="col-sm"></div>
      <div class="col-sm">
        <SearchComponent @input="setCurrentInput($event)" v-bind:searchInput="this.selectedCity"></SearchComponent>
      </div>
      <div class="col-sm"></div>
    </div>
    <div class="row" v-show="!selectedCity">
      <div class="col-sm-4"></div>
      <div class="col-sm-4">      
      <ul>
        <li v-for="f in $options.filters.unique(this.filteredResults, 'city').slice(0, 15)" v-bind:key="f.id">
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
  </div>
</template>

<script>
import cities from "./data/cities";
import SearchComponent from "./components/Search/SearchComponent";
import CityDetail from "./components/Detail/CityDetail";

export default {
  name: "app",
  components: { SearchComponent, CityDetail },
  data() {
    return {
      searchInput: "",
      cities,
      selectedCity: ""
    };
  },
  methods: {
    selectCity(city) {
      this.selectedCity = city;
    },
    setCurrentInput(input) {
      this.searchInput = input;
      if (this.selectedCity) {
        this.selectedCity = "";
      }
    }
  },
  computed: {
    isInputPostalCode() {
      if (!this.searchInput || this.searchInput.length < 2) return false;

      return RegExp(/^[0-9]+$/).test(this.searchInput);
    },
    filteredResults() {
      if (!this.searchInput || this.searchInput.length < 2) return [];

      return cities.filter(f => {
        if (this.isInputPostalCode) {
          return f.zip.startsWith(this.searchInput);
        } else {
          return f.city
            .toLowerCase()
            .startsWith(this.searchInput.toLowerCase());
        }
      });
    }
  }
};
</script>

<style>
</style>