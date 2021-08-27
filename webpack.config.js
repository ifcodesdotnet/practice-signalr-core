const path = require('path');
const webpack = require('webpack');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const CssMinimizerPlugin = require('css-minimizer-webpack-plugin');

module.exports = {
  entry: {
        login: './src/js/login.js',
        chat: './src/js/chat.js',
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
        }),
        new MiniCssExtractPlugin({
            filename: "css/[name].[contenthash].css",
        })
    ], module: {
        rules: [
            {
                test: /\.css$/,
                use: [
                    MiniCssExtractPlugin.loader,
                    "css-loader",
                ]
            },
            {
                test: /(\.png|\.gif|\.ttf|\.eot|\.woff|\.svg)/,
                loader: "file-loader",
                enforce: "pre",
                options: {
                    name: 'fonts/[contenthash].[ext]',
                    context: 'src'
                }
            },
        ]
    },
    optimization: {
        minimizer: [
            new CssMinimizerPlugin(),
        ],
    },
};;