<template>
  <div class="form-group">
    <label class="mt-2" for="city">Enter the city name you desire, or the zip code...</label>
    <input id="city" class="form-control" type="text" :value="search" 
      @keydown="keydown" v-debounce:250="inputChanged">
  </div>
</template>

<script>
export default {
  name: 'SearchInput',
  props: { searchInput: String },
  methods: {
    inputChanged: function(newVal){
      this.$emit('input', newVal);
    },
    keydown: function(event){
      if(event.keyCode != 8)
        return;

      this.$emit('backspace');
    }
  },
  computed: {
    search: function() {
      return this.searchInput;
    }
  },
  data: function() {
    return { input: this.searchInput };
  }
};
</script>
<style lang="scss">
@import "@/assets/sass/styles.scss";
</style>
