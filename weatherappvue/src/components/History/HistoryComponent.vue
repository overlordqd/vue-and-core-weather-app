<template>
    <div>
        <h3>Your recent searches</h3>
        <ul>
            <li v-for="c in searchHistory" v-bind:key="c.id">
                <a v-bind:title="'Last accessed: ' + ($options.filters.moment(c.lastAccessed, ' DD-MM-YYYY HH:mm'))">
                    {{ c.city.city }}, {{ c.weather.tempC }}
                </a>
            </li>
        </ul>
        <button @click="clearHistory">Clear history</button>
    </div>
</template>

<script>
// eslint-disable-next-line
import moment from "moment";
export default {
    name: "HistoryComponent",
    props: ['searchHistory'],
    methods: {
        clearHistory(){
            this.$emit('clear-history-requested');
        }
    }
};
</script>

<style>
</style>