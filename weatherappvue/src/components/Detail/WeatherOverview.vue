<template>
    <div v-show="this.loading < 2">
        <h3>Current weather for <span v-text="city.name"></span></h3>
        <div class="row mt-3 pr-3">
          <div class="col">
            <h1>{{currentTemp.temperature | celsius}}</h1>
          </div>
          <div class="col">
            <div><label>Wind speed:</label> {{currentTemp.windSpeed}} kph</div>
            <div><label>Humidity:</label> {{currentTemp.humidity}} %</div>  
          </div>
          <div class="col-md-3">
            <weather-icon :currentTemp="this.currentTemp"></weather-icon>
          </div>
        </div>

        <h3 class="mt-3">Forecast for next five days</h3>
        <forecast-list v-if="forecastData && forecastData.length" v-bind:forecast="forecastData"></forecast-list>        
    </div>
</template>

<script>
import { HTTP } from "../../http-common";
import ForecastList from './ForecastList';
import WeatherIcon from './WeatherIcon';

export default {
  name: 'WeatherOverview',
  props: { city: {} },
  components: { ForecastList, WeatherIcon },
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