<template>
  <div class="history">
    <div class="row" v-show="this.searchHistory && this.searchHistory.length">
        <div class="col-sm-12 col-md-6 offset-md-3 col-lg-6 lg-offset-3">
            <history-component @clear-history-requested="clearHistory"></history-component>
        </div>
    </div>
  </div>
</template>

<script>
import { storage } from "../storage"
import HistoryComponent from '../components/History/HistoryComponent'
export default {
  name: `History`,
  mixins: [storage],
  components: { HistoryComponent },
  mounted() {
    this.initLocalStorage();
  }
};
</script>