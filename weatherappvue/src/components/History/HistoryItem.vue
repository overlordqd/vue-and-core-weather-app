<template>
    <li>
        <a :title="lastAccessed">
            {{ item.city.name }}, {{ item.weather.tempC }}
        </a>
    </li>
</template>

<script>
// eslint-disable-next-line
import moment from "moment";
export default {
    name: "HistoryComponent",
    props: {
        item: {}
    },
    methods: {
        clearHistory(){
            this.$emit('clear-history-requested');
        },
        getLastAccessed(){
           
        }
    },
    computed: {
        lastAccessed(){
            return `Last accessed: ${moment(this.item.lastAccessed).format('DD-MM-YYYY HH:mm:ss')}`;
        }
    }
};
</script>

<style>
</style>