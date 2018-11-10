<template>
  <div class="com-sm-offset-3" >
      <label>5 days forecast</label>
      <ul>
          <forecast-item v-for="record in forecast" :key="record.city" :item="record"></forecast-item>
      </ul>
  </div>
</template>

<script>
import ForecastItem from './ForecastItem';

export default {
  name: 'ForecastList',
  props: { forecast: Array },
  components: { ForecastItem }
};
</script>

<style>
</style>