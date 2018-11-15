<template>
  <div>
      <ul class="list-group list-group-flush">
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