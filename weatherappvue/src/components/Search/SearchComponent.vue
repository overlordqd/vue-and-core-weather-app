<template>
 <div class="form-group">
      <label for="city">Enter the city name you desire, or the zip code...</label>
      <input id="city" class="form-control" type="text" v-model="input" v-on:input="$emit('input', $event.target.value)">
    </div>
</template>

<script>
export default {
  name: "SearchComponent",
  props: ["searchInput"],
  watch: {
    searchInput: function(newVal, oldVal) {
      this.input = newVal.city;
    }
  },
  data: function() {
    return { input: this.searchInput };
  }
};
</script>

<style>
</style>