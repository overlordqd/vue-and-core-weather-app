<template>
  <li>
    <a @click="selectCity(city)">
      {{city.name}} {{city.zip}}
    </a>
  </li>
</template>

<script>
export default {
  name: 'SearchResultItem',
  props: { city: Object },
  methods: {
    selectCity: function(city) {
      this.$emit('city-selected', city);
    }
  }
};
</script>