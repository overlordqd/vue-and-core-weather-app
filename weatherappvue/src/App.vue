<template>
  <div id="app">
    <div class="row">
      <div class="col-sm">
      </div>
      <div class="col-sm">
        <SearchComponent @input="setCurrentInput($event)" v-bind:searchInput="this.selectedCity"></SearchComponent>
      </div>
      <div class="col-sm">

      </div>
    </div>
    <div class="row">
      <ul>
        <li v-for="f in unique(this.filteredResults, 'city').slice(0, 15)" v-bind:key="f.id">
          <a v-on:click="selectCity(f)">{{f.city}} {{f.zip}}</a>
        </li>
      </ul>
    </div>
    <div class="row" v-show="selectedCity">
      <DetailComponent v-bind:city="selectedCity"></DetailComponent>
    </div>
  </div>
</template>

<script>
import cities from "./data/cities";
import SearchComponent from "./components/Search/SearchComponent";
import DetailComponent from "./components/Detail/CityDetail";

export default {
  name: "app",
  components: { SearchComponent, DetailComponent },
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
    },
    unique(arr, key) {
      if (arr == null) {
        return [];
      }
      var output = [];
      var usedKeys = {};
      for (var i = 0; i < arr.length; i++) {
        if (!usedKeys[arr[i][key]]) {
          usedKeys[arr[i][key]] = true;
          output.push(arr[i]);
        }
      }
      return output;
    }
  },
  computed: {
    isInputPostalCode() {
      if (!this.searchInput || this.searchInput.length < 2) return false;

      return RegExp(/^[0-9]+$/).test(this.searchInput);
    },
    filteredResults() {
      if (!this.searchInput || this.searchInput.length < 2) return null;

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