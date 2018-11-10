<template>
  <li>
      {{item.dateTimeIso | moment("dddd, MMMM Do YYYY")}} {{item.maxTempC | celsius}} / {{item.minTempC | celsius}}
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