<template>
    <div class="col-sm-4 col-sm-offset-2" v-show="this.loading < 2">
        <h4>Current weather for <span v-text="city.city"></span></h4>
        <label for="currentTemp">Current temperature: </label>
        <p v-text="$options.filters.celsius(currentTemp)"></p>

        <div v-show="forecast && forecast.length" class="com-sm-offset-3" >
            <label>5 days forecast</label>
            <ul>
                <li v-for="f in forecast" v-bind:key="f.minTemperature">
                    temp min: {{f.minTempC | celsius}}
                    temp max: {{f.maxTempC | celsius}}
                </li>
            </ul>
        </div>
    </div>
</template>

<script>
import { HTTP } from "../../http-common";
export default {
  name: "CityDetail",
  props: ["city"],
  filters: {
    celsius: function(value) {
      if (!value) return "";
      return value.toString() + " °C";
    }
  },
  watch: {
    city() {
      var app = this;
      app.loading = 2;
      HTTP.get("/weather/forecast?city=" + app.city.city + ",de")
        .then(response => {
          app.forecast = response.data;
          app.loading--;
        })
        .catch(e => {
            app.loading--;
          console.log(e);
        });
        HTTP.get("/weather/current?city=" + app.city.city + ",de")
        .then(response => {
          app.currentTemp = response.data.tempC;
          app.loading--;
        })
        .catch(e => {
            app.loading--;
          console.log(e);
        });
    }
  },
  data() {
    return {
      cityName: "",
      zipCode: "",
      currentTemp: 0,
      forecast: [],
      moisture: 0,
      loading: 0
    };
  }
};
</script>

<style>
</style>