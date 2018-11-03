<template>
    <div class="col-sm-4 col-sm-offset-2">
        <h4>Current weather for <span v-text="city.city"></span></h4>
        <label for="currentTemp">Current temperature: </label>
        <p v-text="$options.filters.celsius(currentTemp)"></p>

        <div v-show="forecast && forecast.length" class="com-sm-offset-3" >
            <label>5 days forecast</label>
            <ul>
                <li v-for="f in forecast" v-bind:key="f.minTemperature">
                    {{f.minTemperature | celsius}}
                </li>
            </ul>
        </div>
    </div>
</template>

<script>
export default {
  name: "CityDetail",
  props: ["city"],
  filters: {
    celsius: function(value) {
      if (!value) return "";
        return value.toString() + ' °C';
    }
  },
  data() {
    return {
      cityName: "",
      zipCode: "",
      currentTemp: 0,
      forecast: [],
      moisture: 0
    };
  }
};
</script>

<style>
</style>