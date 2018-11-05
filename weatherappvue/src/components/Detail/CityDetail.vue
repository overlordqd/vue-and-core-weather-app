<template>
    <div v-show="this.loading < 2">
        <h4>Current weather for <span v-text="city.city"></span></h4>
        <label for="currentTemp">Current temperature: </label>
        <p>{{currentTemp.tempC | celsius}}</p>

        <div v-show="forecast && forecast.length" class="com-sm-offset-3" >
            <label>5 days forecast</label>
            <ul>
                <li v-for="f in forecast" v-bind:key="f.minTemperature">
                    {{f.dateTimeIso | moment("dddd, MMMM Do YYYY")}} {{f.maxTempC | celsius}} / {{f.minTempC | celsius}}
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
  watch: {
    city() {
      var app = this;
      if(!app.city.id)
      {
        return;
      }
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
          app.currentTemp = response.data;
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
      currentTemp: {},
      forecast: [],
      loading: 0
    };
  }
};
</script>

<style>
</style>