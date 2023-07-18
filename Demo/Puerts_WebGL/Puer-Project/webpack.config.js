module.exports = {
    mode: 'production',

    target: 'node16',
    entry: {
        'math.gl': '@math.gl/core'
    },
    output: {
        filename: '[name].gen.mjs',
        path: __dirname + '/out/external',
        library: {
            type: 'module'
        }
    },
    experiments: { outputModule: true },
    optimization: { minimize: false },
    externals: [
        'fs',
        'crypto',
        'dns',
        'http',
        'http2',
        'https',
        'net',
        'os',
        'path',
        'querystring',
        'stream',
        'repl',
        'readline',
        'tls',
        'dgram',
        'url',
        'v8',
        'vm',
        'zlib',
        'util',
        'assert',
        'events',
        'tty'
    ].reduce((prev, v) => { prev[v] = 'commonjs ' + v; return prev }, {})
}