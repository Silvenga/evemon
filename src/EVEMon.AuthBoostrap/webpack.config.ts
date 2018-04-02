const { AureliaPlugin } = require('aurelia-webpack-plugin');
import * as HtmlWebpackPlugin from 'html-webpack-plugin';
import * as webpack from 'webpack';
import * as path from 'path';

const outputDirectory = path.resolve(__dirname, 'dist');
const sourceDirectory = path.resolve(__dirname, 'src');
const nodeModuleDirectory = path.resolve(__dirname, 'node_modules');

// This is from https://github.com/masterjeef/aurelia-boilerplate

const webpackConfig: webpack.Configuration = {
    entry: 'aurelia-bootstrapper',
    context: path.resolve(__dirname),
    target: 'web',
    output: {
        path: outputDirectory,
        publicPath: '/',
        filename: '[name].bundle.js',
        chunkFilename: '[name].chunk.js'
    },
    devtool: 'source-map',
    watch: true,
    module: {
        rules: [
            {
                test: /\.html?$/,
                use: 'html-loader'
            },
            {
                test: /\.ts?$/,
                use: [
                    { loader: 'babel-loader' },
                    { loader: 'ts-loader' }
                ]
            },
            {
                test: /\.(scss)$/,
                use: [{
                    loader: 'style-loader',
                }, {
                    loader: 'css-loader',
                }, {
                    loader: 'postcss-loader',
                    options: {
                        plugins: function () {
                            return [
                                require('precss'),
                                require('autoprefixer')
                            ];
                        }
                    }
                }, {
                    loader: 'sass-loader'
                }]
            },
            { test: /\.(jpg|png|gif|woff2|woff)$/, use: ["file-loader"] },
            { test: /\.(svg)$/, use: ["url-loader"] },
        ]
    },
    resolve: {
        extensions: ['.ts', '.js'],
        modules: [sourceDirectory, nodeModuleDirectory]
    },
    devServer: {
        inline: true,
        contentBase: '/',
        port: 8080
    },
    plugins: [
        new AureliaPlugin(),
        new HtmlWebpackPlugin({
            template: 'index.html',
            metadata: {}
        }),
    ]
}

export default webpackConfig;