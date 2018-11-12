<template>
  <li class="list-group-item">
    <span>
      {{item.dateTimeIso | moment("dddd, MMM Do")}}
    </span>
    <span>{{item.maxTempC | celsius}} / {{item.minTempC | celsius}}</span>
  </li>
</template>

<script>
export default {
  name: 'ForecastItem',
  props: { item: Object }
};
</script>

<style>
</style>