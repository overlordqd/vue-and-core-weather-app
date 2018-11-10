<template>
    <div>
        <h3>Your recent searches</h3>
        <ul>
            <history-item v-for="record in searchHistory" :key="record.city.name" :item="record"></history-item>
        </ul>
        <b-button @click="clearHistory">Clear history</b-button>
    </div>
</template>

<script>
// eslint-disable-next-line
import moment from 'moment';
import HistoryItem from './HistoryItem'

export default {
    name: "HistoryComponent",
    props: ['searchHistory'],
    components: { HistoryItem },
    methods: {
        clearHistory(){
            this.$emit('clear-history-requested');
        }
    }
};
</script>

<style>
</style>