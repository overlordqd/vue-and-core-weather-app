module.exports = {
    configureWebpack: {
        devtool: 'source-map'
      },
    css: 
        { loaderOptions: 
            { sass: 
                { data: `@import "@/assets/sass/styles.scss";`
                } 
            } 
        },
  } 