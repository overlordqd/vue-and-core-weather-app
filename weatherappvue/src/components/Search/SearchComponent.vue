<template>
 <div class="form-group">
      <label for="city" weather-icon="1">Enter the city name you desire, or the zip code...</label>
      <input id="city" class="form-control" type="text" v-model="input" v-debounce:250="inputChanged">
    </div>
</template>

<script>
export default {
  name: "SearchComponent",
  props: ["searchInput"],
    methods: {
    inputChanged: function(newVal)
    {
      this.$emit('input', newVal);
    }
  },
  watch: {
    searchInput: function(newVal) {
      this.input = newVal.name;
    }
  },
  data: function() {
    return { input: this.searchInput };
  }
};
</script>

<style>
</style>