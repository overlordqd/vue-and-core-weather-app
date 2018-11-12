<template>
    <div>
        <h4>Your recent searches</h4>
        <div>
            <ul class="list-group list-group-flush">
                <history-item v-for="record in searchHistory" :key="record.city.name" :item="record"></history-item>
            </ul>
            <button type="button" class="btn btn-primary btn-block" @click="clearHistory">Clear history</button>
        </div>
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