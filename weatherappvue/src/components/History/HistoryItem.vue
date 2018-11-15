<template>
    <li class="list-group-item" @click="toggle">
        <a>
            <span v-show="toggleIndex == 0">
                {{ toggleData[toggleIndex] }}
            </span>
            <span v-show="toggleIndex > 0">
                <sup>{{ toggleData[0] }}</sup> {{ toggleData[toggleIndex] }}
            </span>
        </a>
    </li>
</template>

<script>
// eslint-disable-next-line
import moment from "moment";

export default {
    name: 'HistoryItem',
    data() {
        return {
            toggleIndex: 0,
            toggleData: [this.item.city.name,
                        `Temp: ${this.$options.filters.celsius(this.item.weather.tempC)}`, 
                        `Humidity: ${this.item.weather.humidity}%`,
                        this.lastAccessed()]
        }
    },
    props: {
        item: {}
    },
    methods: {
        clearHistory(){
            this.$emit('clear-history-requested');
        },
        toggle: function(){
            this.toggleIndex = (this.toggleIndex + 1) % this.toggleData.length;
        },
        lastAccessed(){
            return `Last accessed: ${moment(this.item.lastAccessed).format('MMM D YYYY HH:mm')}`;
        }
    }
};
</script>