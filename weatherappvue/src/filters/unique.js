import Vue from 'vue';

Vue.filter('unique', function(arr, key) {
    if (arr == null) {
            return [];
          }
    var output = []
    var usedKeys = {}
    for (var i = 0; i < arr.length; i++) {
        if (!usedKeys[arr[i][key]]) {
            usedKeys[arr[i][key]] = true
            output.push(arr[i])
        }
    }
    return output
});