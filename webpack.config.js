const path = require('path');
const webpack = require('webpack');

module.exports = {
  entry: {
    app: ["./src/js/chat.js"]
  },
  output: {
    filename: "js/[name].[contenthash].js",
    path: path.resolve(__dirname, 'wwwroot/'),
  },
  plugins: [
    new webpack.ProvidePlugin({
      $: 'jquery',
      jQuery: 'jquery',
      'window.jQuery': 'jquery',
    })
  ] 
};