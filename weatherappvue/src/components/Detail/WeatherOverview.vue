<template>
    <div v-show="this.loading < 2">
        <h4>Current weather for <span v-text="city.name"></span></h4>
        <p>{{currentTemp.tempC | celsius}}</p>

        <forecast-list v-if="forecastData && forecastData.length" v-bind:forecast="forecastData"></forecast-list>        
    </div>
</template>

<script>
import { HTTP } from "../../http-common";
import ForecastList from './ForecastList';

export default {
  name: 'WeatherOverview',
  props: { city: {} },
  components: { ForecastList },
  methods: {
    getForecast: function(){
      var app = this;

      HTTP.get(`/weather/forecast?city=${app.city.name},de`)
        .then(response => {
          app.forecastData = response.data;
          app.loading--;
        })
        .catch(e => {
          app.loading--;
          window.console.log(e);
        });
    },
    getCurrentWeather: function(){
      var app = this;
      
      HTTP.get(`/weather/current?city=${app.city.name},de`)
        .then(response => {
          app.currentTemp = response.data;
          app.loading--;

          this.$emit('weather-data-fetched', response.data);
        })
        .catch(e => {
          app.loading--;
          window.console.log(e);
        });
    }
  },
  watch: {
    city() {
      if(!this.city.id)
        return;
      this.loading = 2;
      
      this.getForecast();
      this.getCurrentWeather();
    }
  },
  data() {
    return {
      currentTemp: {},
      forecastData: [],
      loading: 0
    };
  }
};
</script>