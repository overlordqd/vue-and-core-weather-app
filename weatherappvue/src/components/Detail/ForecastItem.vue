<template>
  <li class="list-group-item">
    <div class="row">
      <div class="col">
        {{item.date | moment("MMM D, dddd")}}
      </div>
      <div class="col">
        {{item.temperatureMax | celsius}}<br> 
        {{item.temperatureMin | celsius}}
      </div>
      <div class="col">
        {{item.humidityMax}} %<br>
        {{item.humidityMin}} %
      </div>
      <div class="col">
        <weather-icon :currentTemp="this.item"></weather-icon>
      </div>
    </div>
  </li>
</template>

<script>
import WeatherIcon from './WeatherIcon';
export default {
  name: 'ForecastItem',
  props: { item: Object },
  components: { WeatherIcon }
};
</script>

<style>
.list-group-item { padding-left: 0px; }
.forecast-item-date { width:150px; }
</style>
