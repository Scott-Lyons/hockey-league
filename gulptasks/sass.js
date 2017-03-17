var gulp = require('gulp'),
    sass = require('gulp-sass'),
    config = require('../config');
 
gulp.task('sass', function () {
  return gulp.src(config.web_path + '/sass/**/*.scss')
    .pipe(sass().on('error', sass.logError))
    .pipe(gulp.dest(config.web_path + '/css'));
});
 
gulp.task('sass-watch', function () {
  gulp.watch(config.web_path + '/sass/**/*.scss', ['sass']);
});