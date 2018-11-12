import Vue from 'vue';

Vue.filter('celsius', function(value) {
    if (!value) 
      return "";
    return value.toString() + " °C";
  });