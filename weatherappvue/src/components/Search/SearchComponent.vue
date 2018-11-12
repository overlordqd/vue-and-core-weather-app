<template>
<div>
  <div class="row">
    <div class="col">
      <search-input @input="setCurrentInput($event)" @backspace="setCurrentInput('')" :searchInput="this.selectedCity.name"></search-input>
    </div>
  </div>
  <div class="row" v-if="!selectedCity">
    <div class="col">      
      <ul>
        <search-result-item v-for="f in filteredCities" :key="f.id" :city="f" @city-selected="setSelectedCity"></search-result-item>
      </ul>
    </div>
  </div>
</div>
</template>

<script>
import { HTTP } from "../../http-common";
import SearchInput from "./SearchInput";
import SearchResultItem from "./SearchResultItem";

export default {
  name: 'SearchComponent',
  components: { SearchInput, SearchResultItem },
  data() {
    return {
      searchInput: "",
      cities: [],
      selectedCity: "",
      searchHistory: []
    };
  },
  methods: {
    setSelectedCity: function(city){
      this.selectedCity = city;
      this.$emit('city-selected', city);
    },
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