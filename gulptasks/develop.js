var gulp = require('gulp'),
    browserSync = require('browser-sync').create()
    config = require('../config'),
    runSequence = require('run-sequence');
    
gulp.task('browser-sync', function() {
    browserSync.init({
        server: {
            baseDir: './' + config.web_path
        },
        open: false
    });  
});

gulp.task('html-watch', function(done) {
    gulp.watch(config.web_app_path + '/**/*.html', browserSync.reload);
});

gulp.task('js-watch', function(done) {
    gulp.watch(config.web_app_path + '/**/*.js', browserSync.reload);
});

gulp.task('css-watch', function () {
  gulp.watch(config.web_path + '/css/**/*.css', browserSync.reload);
});

gulp.task('watch', function(done){
    runSequence(['ts-watch', 'js-watch', 'html-watch', 'sass-watch', 'css-watch'], done);
});

gulp.task('develop', function(done) {
    runSequence('ts-compile', 'sass', 'browser-sync', 'watch', done);
});