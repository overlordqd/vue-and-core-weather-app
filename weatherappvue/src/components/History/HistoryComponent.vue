<template>
    <div>
        <slot name="title">
            <h5 class="mt-3">Recent queries</h5>
        </slot>
        <div>
            <ul class="list-group list-group-flush">
                <history-item v-for="record in limitedSearchHistory" :key="record.city.name" :item="record"></history-item>
            </ul>
            <button v-if="!this.limit" type="button" class="btn btn-primary btn-block mt-4" @click="clearHistory">Clear history</button>
        </div>
    </div>
</template>

<script>
// eslint-disable-next-line
import moment from 'moment';
import { storage } from "../../storage"
import HistoryItem from './HistoryItem'

export default {
    name: "HistoryComponent",
    mixins: [storage],
    props: {
        limit: Number
    },
    mounted() {
        this.initLocalStorage();
    },
    components: { HistoryItem },
    methods: {
        clearHistory(){
            this.$emit('clear-history-requested');
        }
    },
    computed: {
        limitedSearchHistory: function(){
            if(this.limit)
                return this.searchHistory.slice(0, this.limit);
            return this.searchHistory; 
        }
    }
};
</script>