<template>
    <img :src="iconUrl(currentTemp.icon)" :alt="currentTemp.weatherEvent">
</template>


<script>
export default {
  name: 'WeatherIcon',
  props: { currentTemp: Object },
  methods: {
    iconUrl: function(icon){
        if(!icon)
            return '';
        return `https://cdn.aerisapi.com/wxicons/v2/${icon}`;
    },
  }
};
</script>