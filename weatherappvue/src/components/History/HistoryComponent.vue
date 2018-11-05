<template>
    <div>
        <h3>Your recent searches</h3>
        <ul>
            <li v-for="c in searchHistory" v-bind:key="c.id">
                {{ c.city }}
            </li>
        </ul>
    </div>
</template>

<script>
export default {
  name: "HistoryComponent",
  props: ['searchHistory']
};
</script>

<style>
</style>