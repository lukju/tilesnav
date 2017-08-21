import * as gulp from 'gulp';
import * as browserSync from 'browser-sync';
import * as historyApiFallback from 'connect-history-api-fallback/lib';
import {CLIOptions} from 'aurelia-cli';
import * as project from '../aurelia.json';
import build from './build';
import watch from './watch';

let serve = gulp.series(
    build,
    done => {
        browserSync({
            open: false,
            port: 9000,
            logLevel: 'silent',
            proxy: {
                target: 'localhost:5000'
            }
        }, function (err, bs) {
            let urls = bs.options.get('urls').toJS();
            log(`Application Available At: ${urls.local}`);
            log(`BrowserSync Available At: ${urls.ui}`);
            done();
        });
    }
);

function log(message) {
  console.log(message);
}

function reload() {
  log('Refreshing the browser');
  browserSync.reload();
}

let run;

if (CLIOptions.hasFlag('watch')) {
  run = gulp.series(
    serve,
    done => { watch(reload); done(); }
  );
} else {
  run = serve;
}

export default run;
