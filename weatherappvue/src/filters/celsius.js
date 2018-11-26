import Vue from 'vue';

Vue.filter('celsius', function(value) {
    if (!value && value != 0) 
      return '';
    return `${value} °C`;
  });